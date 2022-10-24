using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master.enums;
using Swordie;

namespace SwordieLauncher
{
    public partial class Form1 : Form
    {
        private Client client;
        
        public Form1()
        {
            InitializeComponent();
            try
            {
                this.client = new Client();
                bool connected = this.client.Connect();
                if (!connected)
                {
                    MessageBox.Show("Server is offline. Try again later.", "Launcher");
                    System.Environment.Exit(0);
                    Application.Exit();
                    return;
                }
                this.FormClosing += Form1_FormClosing;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool opened = LaunchMapleAsync().Result;
            if (opened)
            {
                passwordTextBox.Clear();
                this.WindowState = FormWindowState.Minimized;
            }
        }



        private static String sDllPath = "v206.dll"; // dll name


        private static uint CREATE_SUSPENDED = 0x00000004;

        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }


        public struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }



        public struct SECURITY_ATTRIBUTES
        {
            public int length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;

        }

        [DllImport("kernel32.dll")]
        static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
                        bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment,
                        string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);


        private static int GetProcessId(String proc)
        {
            int processID = -1;
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName == proc)
                {
                    processID = (int)processes[i].Id;

                    break;
                }
            }

            return processID;
        }


        private static InjectResponse Inject(String exe, String dllPath)
        {
            int processID = GetProcessId(exe);
            if (processID == -1)
            {
                return InjectResponse.FAILED_GET_PROCESS_ID;
            }

            IntPtr pLoadLibraryAddress = GetProcAddress(GetModuleHandle("Kernel32.dll"), "LoadLibraryA");
            if (pLoadLibraryAddress == (IntPtr)0)
            {
                return InjectResponse.FAILED_LOADING_KERNEL_LoadLibraryA;
            }

            IntPtr processHandle = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, (uint)processID);
            if (processHandle == (IntPtr)0)
            {
                return InjectResponse.FAILED_OPENPROCESS;
            }

            IntPtr lpAddress = VirtualAllocEx(processHandle, (IntPtr)null, (IntPtr)dllPath.Length, (0x1000 | 0x2000), 0X40);
            if (lpAddress == (IntPtr)0)
            {
                return InjectResponse.FAILED_ALLOCATING_MEMORY_FOR_DLL;
            }

            byte[] bytes = Encoding.ASCII.GetBytes(dllPath);
            if (WriteProcessMemory(processHandle, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
            {
                return InjectResponse.FAILED_WRITTING_PROCESS_MEMORY;
            }

            if (CreateRemoteThread(processHandle, (IntPtr)null, (IntPtr)0, pLoadLibraryAddress, lpAddress, 0, (IntPtr)null) == (IntPtr)0)
            {
                return InjectResponse.FAILED_CREATEREMOTETHREAD;
            }

            CloseHandle(processHandle);

            return InjectResponse.SUCCESS;
        }



        async Task<bool> LaunchMapleAsync()
        {
            STARTUPINFO si = new STARTUPINFO();
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;
            bool successAuthAndLaunching = false;

            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Type your username and password.");
                return false;
            }

            string token = await this.GetToken(username, password);
            if (token.Length == 0)
            {
                MessageBox.Show("Invalid username/password combination.");
                return false;
            }

            try
            {
                if (!File.Exists("Maplestory.exe"))
                {
                    MessageBox.Show("Make sure this launcher is in the Maplestory folder.");

                    return false;
                }

                bool bCreateProc = CreateProcess("MapleStory.exe", $" WebStart {token}", IntPtr.Zero, IntPtr.Zero, false, CREATE_SUSPENDED, IntPtr.Zero, null, ref si, out pi);


                if (bCreateProc)
                {
                    InjectResponse bInject = Inject("MapleStory", sDllPath);
                    switch (bInject)
                    {
                        case InjectResponse.FAILED_GET_PROCESS_ID:
                        case InjectResponse.FAILED_LOADING_KERNEL_LoadLibraryA:
                        case InjectResponse.FAILED_OPENPROCESS:
                            MessageBox.Show("Failed getting process. Please, try again.");
                            break;
                        case InjectResponse.FAILED_ALLOCATING_MEMORY_FOR_DLL:
                        case InjectResponse.FAILED_WRITTING_PROCESS_MEMORY:
                        case InjectResponse.FAILED_CREATEREMOTETHREAD:
                            MessageBox.Show("Failed injecting dll. Please, try again.");
                            break;
                        case InjectResponse.SUCCESS:
                            ResumeThread(pi.hThread);
                            CloseHandle(pi.hThread);
                            CloseHandle(pi.hProcess);
                            successAuthAndLaunching = true;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Failed running Maplestory. \nDisable your antivirus or add Maplestoy.exe to the exluded list.");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Could not start Maplestory.exe! Make sure the file is in your game folder and that this program is ran as admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }



            return successAuthAndLaunching;

        }



        private Task<string> GetToken(string username, string pwd)
        {
            this.client.Send(OutPackets.AuthRequest(username, pwd));
            return Task.FromResult(Handlers.getAuthTokenFromInput(this.client.Receive()));
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            new Form2() { client = this.client }.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
