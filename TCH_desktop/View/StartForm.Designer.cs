﻿namespace TCH_desktop.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.exitButton = new System.Windows.Forms.Label();
            this.infoAboutCurrentUser = new System.Windows.Forms.Label();
            this.newTripMenu = new System.Windows.Forms.Label();
            this.allTripsMenu = new System.Windows.Forms.Label();
            this.personDataMenu = new System.Windows.Forms.Label();
            this.developerEmail = new System.Windows.Forms.Label();
            this.currentMessage = new System.Windows.Forms.Label();
            this.statisticsScreenMenu = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
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
            // newTripMenu
            // 
            this.newTripMenu.BackColor = System.Drawing.Color.Transparent;
            this.newTripMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newTripMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newTripMenu.Location = new System.Drawing.Point(49, 280);
            this.newTripMenu.Name = "newTripMenu";
            this.newTripMenu.Size = new System.Drawing.Size(200, 30);
            this.newTripMenu.TabIndex = 2;
            this.newTripMenu.Text = "НОВАЯ ПОЕЗДКА";
            this.newTripMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newTripMenu.Click += new System.EventHandler(this.newTripMenu_Click);
            this.newTripMenu.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.newTripMenu.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // allTripsMenu
            // 
            this.allTripsMenu.BackColor = System.Drawing.Color.Transparent;
            this.allTripsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.allTripsMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allTripsMenu.Location = new System.Drawing.Point(49, 330);
            this.allTripsMenu.Name = "allTripsMenu";
            this.allTripsMenu.Size = new System.Drawing.Size(200, 30);
            this.allTripsMenu.TabIndex = 3;
            this.allTripsMenu.Text = "ВСЕ ПОЕЗДКИ";
            this.allTripsMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.allTripsMenu.Click += new System.EventHandler(this.allTripsMenu_Click);
            this.allTripsMenu.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.allTripsMenu.MouseLeave += new System.EventHandler(this.labelMouseLeave);
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
            this.personDataMenu.Click += new System.EventHandler(this.personDataMenu_Click);
            this.personDataMenu.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.personDataMenu.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // developerEmail
            // 
            this.developerEmail.AutoSize = true;
            this.developerEmail.BackColor = System.Drawing.Color.Transparent;
            this.developerEmail.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.developerEmail.ForeColor = System.Drawing.Color.BurlyWood;
            this.developerEmail.Location = new System.Drawing.Point(883, 862);
            this.developerEmail.Name = "developerEmail";
            this.developerEmail.Size = new System.Drawing.Size(279, 22);
            this.developerEmail.TabIndex = 6;
            this.developerEmail.Text = "code.drummer87@gmail.com";
            // 
            // currentMessage
            // 
            this.currentMessage.BackColor = System.Drawing.Color.Transparent;
            this.currentMessage.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentMessage.ForeColor = System.Drawing.Color.Gold;
            this.currentMessage.Location = new System.Drawing.Point(312, 818);
            this.currentMessage.Name = "currentMessage";
            this.currentMessage.Size = new System.Drawing.Size(811, 25);
            this.currentMessage.TabIndex = 7;
            this.currentMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statisticsScreenMenu
            // 
            this.statisticsScreenMenu.BackColor = System.Drawing.Color.Transparent;
            this.statisticsScreenMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statisticsScreenMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statisticsScreenMenu.Location = new System.Drawing.Point(49, 380);
            this.statisticsScreenMenu.Name = "statisticsScreenMenu";
            this.statisticsScreenMenu.Size = new System.Drawing.Size(200, 30);
            this.statisticsScreenMenu.TabIndex = 8;
            this.statisticsScreenMenu.Text = "ЭКРАН СТАТИСТИКИ";
            this.statisticsScreenMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statisticsScreenMenu.Click += new System.EventHandler(this.statisticsScreenMenu_Click);
            this.statisticsScreenMenu.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.statisticsScreenMenu.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.BackColor = System.Drawing.Color.Transparent;
            this.birthdayLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 1.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.birthdayLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.birthdayLabel.Location = new System.Drawing.Point(40, 64);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(1122, 133);
            this.birthdayLabel.TabIndex = 9;
            this.birthdayLabel.Text = "С ДНЁМ РОЖДЕНИЯ!";
            this.birthdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.birthdayLabel.Visible = false;
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
            this.Controls.Add(this.birthdayLabel);
            this.Controls.Add(this.statisticsScreenMenu);
            this.Controls.Add(this.currentMessage);
            this.Controls.Add(this.developerEmail);
            this.Controls.Add(this.personDataMenu);
            this.Controls.Add(this.allTripsMenu);
            this.Controls.Add(this.newTripMenu);
            this.Controls.Add(this.infoAboutCurrentUser);
            this.Controls.Add(this.exitButton);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТЧ: Главное Меню";
            this.Activated += new System.EventHandler(this.StartForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label exitButton;
        private Label infoAboutCurrentUser;
        private Label newTripMenu;
        private Label allTripsMenu;
        private Label personDataMenu;
        private Label developerEmail;
        private Label currentMessage;
        private Label statisticsScreenMenu;
        private Label birthdayLabel;
    }
}