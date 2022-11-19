namespace TCH_desktop.View
{
    partial class UserDataSettingForm
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
            this.contactingTheUser = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveUserDataButton = new System.Windows.Forms.Button();
            this.personDataGroupBox = new System.Windows.Forms.GroupBox();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.patronymicInp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.firstNameInp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.surNameInp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeDataGroupBox = new System.Windows.Forms.GroupBox();
            this.columns = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.positions = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabNumberInp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.depot = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.railRoads = new System.Windows.Forms.ComboBox();
            this.userSettingFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.personDataGroupBox.SuspendLayout();
            this.employeeDataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // contactingTheUser
            // 
            this.contactingTheUser.BackColor = System.Drawing.Color.Transparent;
            this.contactingTheUser.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.contactingTheUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contactingTheUser.Location = new System.Drawing.Point(41, 31);
            this.contactingTheUser.Name = "contactingTheUser";
            this.contactingTheUser.Size = new System.Drawing.Size(1152, 111);
            this.contactingTheUser.TabIndex = 0;
            this.contactingTheUser.Text = "Пожалуйста, заполните поля ниже для дальнейшей работы программы";
            this.contactingTheUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.LightBlue;
            this.cancelButton.Location = new System.Drawing.Point(78, 626);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(378, 29);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Займусь этим в другой раз";
            this.userSettingFormToolTip.SetToolTip(this.cancelButton, "Нажав эту кнопку, работа программы будет завершена");
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveUserDataButton
            // 
            this.saveUserDataButton.BackColor = System.Drawing.Color.LightGray;
            this.saveUserDataButton.Enabled = false;
            this.saveUserDataButton.Location = new System.Drawing.Point(740, 626);
            this.saveUserDataButton.Name = "saveUserDataButton";
            this.saveUserDataButton.Size = new System.Drawing.Size(289, 29);
            this.saveUserDataButton.TabIndex = 2;
            this.saveUserDataButton.Text = "Готово";
            this.userSettingFormToolTip.SetToolTip(this.saveUserDataButton, "Сохранить данные");
            this.saveUserDataButton.UseVisualStyleBackColor = false;
            // 
            // personDataGroupBox
            // 
            this.personDataGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.personDataGroupBox.Controls.Add(this.birthDatePicker);
            this.personDataGroupBox.Controls.Add(this.label4);
            this.personDataGroupBox.Controls.Add(this.patronymicInp);
            this.personDataGroupBox.Controls.Add(this.label3);
            this.personDataGroupBox.Controls.Add(this.firstNameInp);
            this.personDataGroupBox.Controls.Add(this.label2);
            this.personDataGroupBox.Controls.Add(this.surNameInp);
            this.personDataGroupBox.Controls.Add(this.label1);
            this.personDataGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.personDataGroupBox.ForeColor = System.Drawing.Color.DarkBlue;
            this.personDataGroupBox.Location = new System.Drawing.Point(30, 203);
            this.personDataGroupBox.Name = "personDataGroupBox";
            this.personDataGroupBox.Size = new System.Drawing.Size(479, 352);
            this.personDataGroupBox.TabIndex = 3;
            this.personDataGroupBox.TabStop = false;
            this.personDataGroupBox.Text = "Личные данные";
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.Location = new System.Drawing.Point(18, 297);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(447, 34);
            this.birthDatePicker.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата Рождения";
            // 
            // patronymicInp
            // 
            this.patronymicInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patronymicInp.Location = new System.Drawing.Point(18, 227);
            this.patronymicInp.Name = "patronymicInp";
            this.patronymicInp.Size = new System.Drawing.Size(447, 34);
            this.patronymicInp.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество";
            // 
            // firstNameInp
            // 
            this.firstNameInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstNameInp.Location = new System.Drawing.Point(18, 159);
            this.firstNameInp.Name = "firstNameInp";
            this.firstNameInp.Size = new System.Drawing.Size(447, 34);
            this.firstNameInp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // surNameInp
            // 
            this.surNameInp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surNameInp.Location = new System.Drawing.Point(18, 91);
            this.surNameInp.Name = "surNameInp";
            this.surNameInp.Size = new System.Drawing.Size(447, 34);
            this.surNameInp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // employeeDataGroupBox
            // 
            this.employeeDataGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.employeeDataGroupBox.Controls.Add(this.columns);
            this.employeeDataGroupBox.Controls.Add(this.label9);
            this.employeeDataGroupBox.Controls.Add(this.positions);
            this.employeeDataGroupBox.Controls.Add(this.label8);
            this.employeeDataGroupBox.Controls.Add(this.tabNumberInp);
            this.employeeDataGroupBox.Controls.Add(this.label7);
            this.employeeDataGroupBox.Controls.Add(this.depot);
            this.employeeDataGroupBox.Controls.Add(this.label6);
            this.employeeDataGroupBox.Controls.Add(this.label5);
            this.employeeDataGroupBox.Controls.Add(this.railRoads);
            this.employeeDataGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.employeeDataGroupBox.ForeColor = System.Drawing.Color.DarkBlue;
            this.employeeDataGroupBox.Location = new System.Drawing.Point(556, 203);
            this.employeeDataGroupBox.Name = "employeeDataGroupBox";
            this.employeeDataGroupBox.Size = new System.Drawing.Size(637, 352);
            this.employeeDataGroupBox.TabIndex = 4;
            this.employeeDataGroupBox.TabStop = false;
            this.employeeDataGroupBox.Text = "Депо Приписки";
            // 
            // columns
            // 
            this.columns.FormattingEnabled = true;
            this.columns.Location = new System.Drawing.Point(375, 293);
            this.columns.Name = "columns";
            this.columns.Size = new System.Drawing.Size(244, 36);
            this.columns.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 28);
            this.label9.TabIndex = 8;
            this.label9.Text = "Колонна";
            // 
            // positions
            // 
            this.positions.FormattingEnabled = true;
            this.positions.Location = new System.Drawing.Point(17, 293);
            this.positions.Name = "positions";
            this.positions.Size = new System.Drawing.Size(315, 36);
            this.positions.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 28);
            this.label8.TabIndex = 6;
            this.label8.Text = "Должность";
            // 
            // tabNumberInp
            // 
            this.tabNumberInp.Location = new System.Drawing.Point(17, 227);
            this.tabNumberInp.Name = "tabNumberInp";
            this.tabNumberInp.Size = new System.Drawing.Size(146, 34);
            this.tabNumberInp.TabIndex = 5;
            this.tabNumberInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 28);
            this.label7.TabIndex = 4;
            this.label7.Text = "Таб.N";
            // 
            // depot
            // 
            this.depot.FormattingEnabled = true;
            this.depot.Location = new System.Drawing.Point(17, 160);
            this.depot.Name = "depot";
            this.depot.Size = new System.Drawing.Size(602, 36);
            this.depot.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "Локомотивное Депо";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Железная Дорога";
            // 
            // railRoads
            // 
            this.railRoads.FormattingEnabled = true;
            this.railRoads.Location = new System.Drawing.Point(17, 91);
            this.railRoads.Name = "railRoads";
            this.railRoads.Size = new System.Drawing.Size(602, 36);
            this.railRoads.TabIndex = 0;
            // 
            // UserDataSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.BackgroundImage = global::TCH_desktop.Properties.Resources.user_data_setting_background_image;
            this.ClientSize = new System.Drawing.Size(1234, 681);
            this.Controls.Add(this.employeeDataGroupBox);
            this.Controls.Add(this.personDataGroupBox);
            this.Controls.Add(this.saveUserDataButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.contactingTheUser);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDataSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDataSettingForm";
            this.TopMost = true;
            this.personDataGroupBox.ResumeLayout(false);
            this.personDataGroupBox.PerformLayout();
            this.employeeDataGroupBox.ResumeLayout(false);
            this.employeeDataGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label contactingTheUser;
        private Button cancelButton;
        private Button saveUserDataButton;
        private GroupBox personDataGroupBox;
        private Label label4;
        private TextBox patronymicInp;
        private Label label3;
        private TextBox firstNameInp;
        private Label label2;
        private TextBox surNameInp;
        private Label label1;
        private DateTimePicker birthDatePicker;
        private GroupBox employeeDataGroupBox;
        private ComboBox columns;
        private Label label9;
        private ComboBox positions;
        private Label label8;
        private TextBox tabNumberInp;
        private Label label7;
        private ComboBox depot;
        private Label label6;
        private Label label5;
        private ComboBox railRoads;
        private ToolTip userSettingFormToolTip;
    }
}