namespace SwordieLauncher
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.usernameInfoLabel = new System.Windows.Forms.Label();
            this.passwordInfoLabel = new System.Windows.Forms.Label();
            this.emailInfoLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(97, 15);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(248, 22);
            this.usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(97, 82);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(248, 22);
            this.passwordTextBox.TabIndex = 1;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(97, 146);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(248, 22);
            this.emailTextBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(16, 18);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(70, 16);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username";
            this.usernameLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(16, 82);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(16, 150);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(41, 16);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "Email";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(245, 197);
            this.createButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(100, 28);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // usernameInfoLabel
            // 
            this.usernameInfoLabel.AutoSize = true;
            this.usernameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.usernameInfoLabel.Location = new System.Drawing.Point(16, 50);
            this.usernameInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameInfoLabel.Name = "usernameInfoLabel";
            this.usernameInfoLabel.Size = new System.Drawing.Size(0, 16);
            this.usernameInfoLabel.TabIndex = 7;
            
            // 
            // passwordInfoLabel
            // 
            this.passwordInfoLabel.AutoSize = true;
            this.passwordInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.passwordInfoLabel.Location = new System.Drawing.Point(16, 114);
            this.passwordInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordInfoLabel.Name = "passwordInfoLabel";
            this.passwordInfoLabel.Size = new System.Drawing.Size(0, 16);
            this.passwordInfoLabel.TabIndex = 8;
            // 
            // emailInfoLabel
            // 
            this.emailInfoLabel.AutoSize = true;
            this.emailInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.emailInfoLabel.Location = new System.Drawing.Point(16, 178);
            this.emailInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailInfoLabel.Name = "emailInfoLabel";
            this.emailInfoLabel.Size = new System.Drawing.Size(0, 16);
            this.emailInfoLabel.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 197);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 238);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emailInfoLabel);
            this.Controls.Add(this.passwordInfoLabel);
            this.Controls.Add(this.usernameInfoLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Create Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label usernameInfoLabel;
        private System.Windows.Forms.Label passwordInfoLabel;
        private System.Windows.Forms.Label emailInfoLabel;
        private System.Windows.Forms.Button button1;
    }
}