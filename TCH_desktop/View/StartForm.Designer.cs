namespace TCH_desktop.View
{
    partial class StartForm
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
            this.exitButton = new System.Windows.Forms.Label();
            this.infoAboutCurrentUser = new System.Windows.Forms.Label();
            this.tripsMenu = new System.Windows.Forms.Label();
            this.infoMenu = new System.Windows.Forms.Label();
            this.studyMenu = new System.Windows.Forms.Label();
            this.personDataMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Lucida Console", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitButton.Location = new System.Drawing.Point(1163, 9);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(24, 22);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "-";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // infoAboutCurrentUser
            // 
            this.infoAboutCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.infoAboutCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.infoAboutCurrentUser.Location = new System.Drawing.Point(22, 18);
            this.infoAboutCurrentUser.Name = "infoAboutCurrentUser";
            this.infoAboutCurrentUser.Size = new System.Drawing.Size(1081, 25);
            this.infoAboutCurrentUser.TabIndex = 1;
            this.infoAboutCurrentUser.Text = "информация о текущем пользователе";
            this.infoAboutCurrentUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tripsMenu
            // 
            this.tripsMenu.BackColor = System.Drawing.Color.Transparent;
            this.tripsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tripsMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tripsMenu.Location = new System.Drawing.Point(49, 280);
            this.tripsMenu.Name = "tripsMenu";
            this.tripsMenu.Size = new System.Drawing.Size(200, 30);
            this.tripsMenu.TabIndex = 2;
            this.tripsMenu.Text = "ПОЕЗДКИ";
            this.tripsMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tripsMenu.MouseEnter += new System.EventHandler(this.tripsMenu_MouseEnter);
            this.tripsMenu.MouseLeave += new System.EventHandler(this.tripsMenu_MouseLeave);
            // 
            // infoMenu
            // 
            this.infoMenu.BackColor = System.Drawing.Color.Transparent;
            this.infoMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.infoMenu.Location = new System.Drawing.Point(49, 330);
            this.infoMenu.Name = "infoMenu";
            this.infoMenu.Size = new System.Drawing.Size(200, 30);
            this.infoMenu.TabIndex = 3;
            this.infoMenu.Text = "ИНФОРМАЦИЯ";
            this.infoMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoMenu.MouseEnter += new System.EventHandler(this.infoMenu_MouseEnter);
            this.infoMenu.MouseLeave += new System.EventHandler(this.infoMenu_MouseLeave);
            // 
            // studyMenu
            // 
            this.studyMenu.BackColor = System.Drawing.Color.Transparent;
            this.studyMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studyMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.studyMenu.Location = new System.Drawing.Point(49, 380);
            this.studyMenu.Name = "studyMenu";
            this.studyMenu.Size = new System.Drawing.Size(200, 30);
            this.studyMenu.TabIndex = 4;
            this.studyMenu.Text = "УЧЁБА";
            this.studyMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.studyMenu.MouseEnter += new System.EventHandler(this.studyMenu_MouseEnter);
            this.studyMenu.MouseLeave += new System.EventHandler(this.studyMenu_MouseLeave);
            // 
            // personDataMenu
            // 
            this.personDataMenu.BackColor = System.Drawing.Color.Transparent;
            this.personDataMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personDataMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.personDataMenu.Location = new System.Drawing.Point(49, 430);
            this.personDataMenu.Name = "personDataMenu";
            this.personDataMenu.Size = new System.Drawing.Size(200, 30);
            this.personDataMenu.TabIndex = 5;
            this.personDataMenu.Text = "ЛИЧНЫЕ ДАННЫЕ";
            this.personDataMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.personDataMenu.MouseEnter += new System.EventHandler(this.personDataMenu_MouseEnter);
            this.personDataMenu.MouseLeave += new System.EventHandler(this.personDataMenu_MouseLeave);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::TCH_desktop.Properties.Resources.start_form_background_image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.personDataMenu);
            this.Controls.Add(this.studyMenu);
            this.Controls.Add(this.infoMenu);
            this.Controls.Add(this.tripsMenu);
            this.Controls.Add(this.infoAboutCurrentUser);
            this.Controls.Add(this.exitButton);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label exitButton;
        private Label infoAboutCurrentUser;
        private Label tripsMenu;
        private Label infoMenu;
        private Label studyMenu;
        private Label personDataMenu;
    }
}