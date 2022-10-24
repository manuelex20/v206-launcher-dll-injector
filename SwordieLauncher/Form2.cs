using Master.enums;
using Swordie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SwordieLauncher
{
    public partial class Form2 : Form
    {

        public Client client;

        public Form2()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.usernameInfoLabel.Text = "";
            this.passwordInfoLabel.Text = "";
            this.emailInfoLabel.Text = "";
            string text1 = this.usernameTextBox.Text;
            string text2 = this.passwordTextBox.Text;
            string text3 = this.emailTextBox.Text;
            passwordTextBox.Text = "";
            if (text1.Length < 4)
            {
                this.usernameInfoLabel.Text = "Username must be at least 4 characters long.";
            }
            else if (text2.Length < 6)
            {
                this.passwordInfoLabel.Text = "Password must be at least 6 characters long.";
            }
            else if (text3 == null || text3.Equals("") || !this.IsValid(text3))
            {
                this.emailInfoLabel.Text = "Email is invalid.";
            }
            else
            {
                CreateResponse request = this.sendAccountCreateRequest(text1, text2, text3).Result;
                switch (request)
                {
                    case CreateResponse.SUCCESS:
                        int num1 = (int)MessageBox.Show("Account successfully created!", "Account creation success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                    case CreateResponse.NAME_TAKEN:
                        int num2 = (int)MessageBox.Show("Account name already taken!", "Account creation error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    case CreateResponse.IP_ALREADY_CREATED:
                        int num3 = (int)MessageBox.Show("This IP has already created an account!", "Account creation error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    case CreateResponse.UNKNOWN_ERROR:
                        int num4 = (int)MessageBox.Show("Unknown error: client and server info are mismatched.", "Account creation error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                }
            }
        }



        private Task<CreateResponse> sendAccountCreateRequest(string username, string password, string email)
        {
            this.client.Send(OutPackets.CreateAccountRequest(username, password, email));
            InPacket inPacket = this.client.Receive();
            inPacket.readInt();
            int num = (int)inPacket.readShort();
            return Task.FromResult((CreateResponse)inPacket.readByte());
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
