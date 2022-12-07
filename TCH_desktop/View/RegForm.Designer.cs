namespace TCH_desktop.View
{
    partial class RegForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegForm));
            this.exitButton = new System.Windows.Forms.Label();
            this.regFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backToAuthForm = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.starPicture = new System.Windows.Forms.PictureBox();
            this.loginInp = new System.Windows.Forms.TextBox();
            this.headerLeft = new System.Windows.Forms.Label();
            this.headerRight = new System.Windows.Forms.Label();
            this.pswdInp = new System.Windows.Forms.TextBox();
            this.confirmPswdInp = new System.Windows.Forms.TextBox();
            this.confirmEmailButton = new System.Windows.Forms.Button();
            this.codeForReg = new System.Windows.Forms.TextBox();
            this.regButton = new System.Windows.Forms.Button();
            this.currentMessage = new System.Windows.Forms.Label();
            this.developerEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.starPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitButton.Location = new System.Drawing.Point(773, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "-";
            this.regFormToolTip.SetToolTip(this.exitButton, "Закрыть");
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // backToAuthForm
            // 
            this.backToAuthForm.AutoSize = true;
            this.backToAuthForm.BackColor = System.Drawing.Color.Transparent;
            this.backToAuthForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToAuthForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.backToAuthForm.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backToAuthForm.ForeColor = System.Drawing.SystemColors.Window;
            this.backToAuthForm.Location = new System.Drawing.Point(0, 0);
            this.backToAuthForm.Name = "backToAuthForm";
            this.backToAuthForm.Size = new System.Drawing.Size(25, 23);
            this.backToAuthForm.TabIndex = 1;
            this.backToAuthForm.Text = "<";
            this.regFormToolTip.SetToolTip(this.backToAuthForm, "Вернуться к форме авторизации");
            this.backToAuthForm.Click += new System.EventHandler(this.backToAuthForm_Click);
            this.backToAuthForm.MouseEnter += new System.EventHandler(this.backToAuthForm_MouseEnter);
            this.backToAuthForm.MouseLeave += new System.EventHandler(this.backToAuthForm_MouseLeave);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(0, 43);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(407, 143);
            this.title.TabIndex = 2;
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // starPicture
            // 
            this.starPicture.BackColor = System.Drawing.Color.Transparent;
            this.starPicture.Image = global::TCH_desktop.Properties.Resources.star_icon;
            this.starPicture.Location = new System.Drawing.Point(174, 198);
            this.starPicture.Name = "starPicture";
            this.starPicture.Size = new System.Drawing.Size(51, 49);
            this.starPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.starPicture.TabIndex = 3;
            this.starPicture.TabStop = false;
            // 
            // loginInp
            // 
            this.loginInp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.loginInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginInp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.loginInp.Location = new System.Drawing.Point(28, 267);
            this.loginInp.Name = "loginInp";
            this.loginInp.PlaceholderText = "укажите email";
            this.loginInp.Size = new System.Drawing.Size(344, 27);
            this.loginInp.TabIndex = 4;
            this.loginInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // headerLeft
            // 
            this.headerLeft.BackColor = System.Drawing.Color.Transparent;
            this.headerLeft.Font = new System.Drawing.Font("Impact", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.headerLeft.Location = new System.Drawing.Point(28, 198);
            this.headerLeft.Name = "headerLeft";
            this.headerLeft.Size = new System.Drawing.Size(136, 49);
            this.headerLeft.TabIndex = 5;
            this.headerLeft.Text = "НОВЫЙ";
            this.headerLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerRight
            // 
            this.headerRight.BackColor = System.Drawing.Color.Transparent;
            this.headerRight.Font = new System.Drawing.Font("Impact", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headerRight.Location = new System.Drawing.Point(231, 198);
            this.headerRight.Name = "headerRight";
            this.headerRight.Size = new System.Drawing.Size(141, 49);
            this.headerRight.TabIndex = 6;
            this.headerRight.Text = "АККАУНТ";
            this.headerRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pswdInp
            // 
            this.pswdInp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pswdInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pswdInp.Location = new System.Drawing.Point(28, 314);
            this.pswdInp.Name = "pswdInp";
            this.pswdInp.PasswordChar = '★';
            this.pswdInp.PlaceholderText = "придумайте пароль";
            this.pswdInp.Size = new System.Drawing.Size(344, 27);
            this.pswdInp.TabIndex = 7;
            this.pswdInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // confirmPswdInp
            // 
            this.confirmPswdInp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.confirmPswdInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPswdInp.Location = new System.Drawing.Point(29, 350);
            this.confirmPswdInp.Name = "confirmPswdInp";
            this.confirmPswdInp.PasswordChar = '★';
            this.confirmPswdInp.PlaceholderText = "повторите пароль";
            this.confirmPswdInp.Size = new System.Drawing.Size(343, 27);
            this.confirmPswdInp.TabIndex = 8;
            this.confirmPswdInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.confirmPswdInp.TextChanged += new System.EventHandler(this.confirmPswdInp_TextChanged);
            // 
            // confirmEmailButton
            // 
            this.confirmEmailButton.BackColor = System.Drawing.Color.LightBlue;
            this.confirmEmailButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmEmailButton.Location = new System.Drawing.Point(75, 395);
            this.confirmEmailButton.Name = "confirmEmailButton";
            this.confirmEmailButton.Size = new System.Drawing.Size(245, 29);
            this.confirmEmailButton.TabIndex = 9;
            this.confirmEmailButton.Text = "подтвердить email";
            this.confirmEmailButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.confirmEmailButton.UseVisualStyleBackColor = false;
            this.confirmEmailButton.MouseEnter += new System.EventHandler(this.confirmEmailButton_MouseEnter);
            this.confirmEmailButton.MouseLeave += new System.EventHandler(this.confirmEmailButton_MouseLeave);
            // 
            // codeForReg
            // 
            this.codeForReg.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.codeForReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeForReg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.codeForReg.Enabled = false;
            this.codeForReg.Location = new System.Drawing.Point(29, 462);
            this.codeForReg.Name = "codeForReg";
            this.codeForReg.PlaceholderText = "код";
            this.codeForReg.Size = new System.Drawing.Size(82, 27);
            this.codeForReg.TabIndex = 10;
            this.codeForReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regButton
            // 
            this.regButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.regButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.regButton.Enabled = false;
            this.regButton.Location = new System.Drawing.Point(117, 461);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(255, 29);
            this.regButton.TabIndex = 11;
            this.regButton.Text = "создать аккаунт";
            this.regButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.regButton.UseVisualStyleBackColor = false;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            this.regButton.MouseEnter += new System.EventHandler(this.regButton_MouseEnter);
            this.regButton.MouseLeave += new System.EventHandler(this.regButton_MouseLeave);
            // 
            // currentMessage
            // 
            this.currentMessage.BackColor = System.Drawing.Color.Transparent;
            this.currentMessage.ForeColor = System.Drawing.Color.Yellow;
            this.currentMessage.Location = new System.Drawing.Point(27, 430);
            this.currentMessage.Name = "currentMessage";
            this.currentMessage.Size = new System.Drawing.Size(745, 25);
            this.currentMessage.TabIndex = 12;
            // 
            // developerEmail
            // 
            this.developerEmail.AutoSize = true;
            this.developerEmail.BackColor = System.Drawing.Color.Transparent;
            this.developerEmail.ForeColor = System.Drawing.Color.BurlyWood;
            this.developerEmail.Location = new System.Drawing.Point(481, 493);
            this.developerEmail.Name = "developerEmail";
            this.developerEmail.Size = new System.Drawing.Size(206, 20);
            this.developerEmail.TabIndex = 13;
            this.developerEmail.Text = "code.drummer87@gmail.com";
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::TCH_desktop.Properties.Resources.registration_background_image;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.developerEmail);
            this.Controls.Add(this.currentMessage);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.codeForReg);
            this.Controls.Add(this.confirmEmailButton);
            this.Controls.Add(this.confirmPswdInp);
            this.Controls.Add(this.pswdInp);
            this.Controls.Add(this.headerRight);
            this.Controls.Add(this.headerLeft);
            this.Controls.Add(this.loginInp);
            this.Controls.Add(this.starPicture);
            this.Controls.Add(this.title);
            this.Controls.Add(this.backToAuthForm);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТЧ: Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.starPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label exitButton;
        private ToolTip regFormToolTip;
        private Label backToAuthForm;
        private Label title;
        private PictureBox starPicture;
        private TextBox loginInp;
        private Label headerLeft;
        private Label headerRight;
        private TextBox pswdInp;
        private TextBox confirmPswdInp;
        private Button confirmEmailButton;
        private TextBox codeForReg;
        private Button regButton;
        private Label currentMessage;
        private Label developerEmail;
    }
}