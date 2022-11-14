namespace TCH_desktop.View
{
    partial class AuthForm
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
            this.components = new System.ComponentModel.Container();
            this.exitButton = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.developerEmail = new System.Windows.Forms.Label();
            this.loginInp = new System.Windows.Forms.TextBox();
            this.pswdInp = new System.Windows.Forms.TextBox();
            this.authButton = new System.Windows.Forms.Button();
            this.authFormErrorMessage = new System.Windows.Forms.Label();
            this.addAccountPicture = new System.Windows.Forms.PictureBox();
            this.authFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.addAccountPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(846, 9);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "-";
            this.authFormToolTip.SetToolTip(this.exitButton, "Закрыть");
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(12, 35);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(407, 143);
            this.title.TabIndex = 1;
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // developerEmail
            // 
            this.developerEmail.AutoSize = true;
            this.developerEmail.BackColor = System.Drawing.Color.Transparent;
            this.developerEmail.ForeColor = System.Drawing.Color.BurlyWood;
            this.developerEmail.Location = new System.Drawing.Point(580, 360);
            this.developerEmail.Name = "developerEmail";
            this.developerEmail.Size = new System.Drawing.Size(206, 20);
            this.developerEmail.TabIndex = 2;
            this.developerEmail.Text = "code.drummer87@gmail.com";
            this.authFormToolTip.SetToolTip(this.developerEmail, "Разработчик Андрей Бодров");
            // 
            // loginInp
            // 
            this.loginInp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.loginInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginInp.Location = new System.Drawing.Point(45, 208);
            this.loginInp.Name = "loginInp";
            this.loginInp.PlaceholderText = "email";
            this.loginInp.Size = new System.Drawing.Size(329, 27);
            this.loginInp.TabIndex = 3;
            this.loginInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginInp.Enter += new System.EventHandler(this.loginInp_Enter);
            // 
            // pswdInp
            // 
            this.pswdInp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pswdInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pswdInp.Location = new System.Drawing.Point(44, 252);
            this.pswdInp.Name = "pswdInp";
            this.pswdInp.PasswordChar = '★';
            this.pswdInp.PlaceholderText = "пароль";
            this.pswdInp.Size = new System.Drawing.Size(330, 27);
            this.pswdInp.TabIndex = 4;
            this.pswdInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pswdInp.Enter += new System.EventHandler(this.pswdInp_Enter);
            // 
            // authButton
            // 
            this.authButton.BackColor = System.Drawing.Color.LightBlue;
            this.authButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authButton.Location = new System.Drawing.Point(99, 295);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(220, 29);
            this.authButton.TabIndex = 5;
            this.authButton.Text = "войти";
            this.authButton.UseVisualStyleBackColor = false;
            this.authButton.Click += new System.EventHandler(this.authButton_Click);
            this.authButton.MouseEnter += new System.EventHandler(this.authButton_MouseEnter);
            this.authButton.MouseLeave += new System.EventHandler(this.authButton_MouseLeave);
            // 
            // authFormErrorMessage
            // 
            this.authFormErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.authFormErrorMessage.ForeColor = System.Drawing.Color.Yellow;
            this.authFormErrorMessage.Location = new System.Drawing.Point(99, 335);
            this.authFormErrorMessage.Name = "authFormErrorMessage";
            this.authFormErrorMessage.Size = new System.Drawing.Size(771, 25);
            this.authFormErrorMessage.TabIndex = 6;
            this.authFormErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addAccountPicture
            // 
            this.addAccountPicture.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.addAccountPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addAccountPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addAccountPicture.Image = global::TCH_desktop.Properties.Resources.account_add_avatar_person_plus_icon;
            this.addAccountPicture.Location = new System.Drawing.Point(380, 208);
            this.addAccountPicture.Name = "addAccountPicture";
            this.addAccountPicture.Size = new System.Drawing.Size(30, 30);
            this.addAccountPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addAccountPicture.TabIndex = 7;
            this.addAccountPicture.TabStop = false;
            this.authFormToolTip.SetToolTip(this.addAccountPicture, "Создать аккаунт\r\n");
            this.addAccountPicture.Click += new System.EventHandler(this.addAccountPicture_Click);
            this.addAccountPicture.MouseEnter += new System.EventHandler(this.addAccountPicture_MouseEnter);
            this.addAccountPicture.MouseLeave += new System.EventHandler(this.addAccountPicture_MouseLeave);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TCH_desktop.Properties.Resources.authorization_background_image;
            this.ClientSize = new System.Drawing.Size(882, 392);
            this.Controls.Add(this.addAccountPicture);
            this.Controls.Add(this.authFormErrorMessage);
            this.Controls.Add(this.authButton);
            this.Controls.Add(this.pswdInp);
            this.Controls.Add(this.loginInp);
            this.Controls.Add(this.developerEmail);
            this.Controls.Add(this.title);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthForm";
            ((System.ComponentModel.ISupportInitialize)(this.addAccountPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label exitButton;
        private Label title;
        private Label developerEmail;
        private TextBox loginInp;
        private TextBox pswdInp;
        private Button authButton;
        private Label authFormErrorMessage;
        private PictureBox addAccountPicture;
        private ToolTip authFormToolTip;
    }
}