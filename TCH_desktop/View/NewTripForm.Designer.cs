namespace TCH_desktop.View
{
    partial class NewTripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTripForm));
            this.backToStartForm = new System.Windows.Forms.Label();
            this.saveDataTrip = new System.Windows.Forms.Label();
            this.NewTripFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.arrivalTimePicker = new System.Windows.Forms.DateTimePicker();
            this.departureTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addLocomotive = new System.Windows.Forms.Label();
            this.addPassedStations = new System.Windows.Forms.Label();
            this.addSpeedLimits = new System.Windows.Forms.Label();
            this.addNotes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.brakeTestInfo = new System.Windows.Forms.Label();
            this.trainTailCar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.trainSpecificLength = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trainAxles = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.trainMass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trainNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.arrivalTrafficLight = new System.Windows.Forms.ComboBox();
            this.departureTrafficLight = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.arrivalStation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.departureStation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.attendanceTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backToStartForm
            // 
            this.backToStartForm.AutoSize = true;
            this.backToStartForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToStartForm.Location = new System.Drawing.Point(23, 760);
            this.backToStartForm.Name = "backToStartForm";
            this.backToStartForm.Size = new System.Drawing.Size(62, 20);
            this.backToStartForm.TabIndex = 0;
            this.backToStartForm.Text = "Отмена";
            this.backToStartForm.Click += new System.EventHandler(this.backToStartForm_Click);
            this.backToStartForm.MouseEnter += new System.EventHandler(this.backToStartForm_MouseEnter);
            this.backToStartForm.MouseLeave += new System.EventHandler(this.backToStartForm_MouseLeave);
            // 
            // saveDataTrip
            // 
            this.saveDataTrip.AutoSize = true;
            this.saveDataTrip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveDataTrip.Location = new System.Drawing.Point(657, 760);
            this.saveDataTrip.Name = "saveDataTrip";
            this.saveDataTrip.Size = new System.Drawing.Size(142, 20);
            this.saveDataTrip.TabIndex = 1;
            this.saveDataTrip.Text = "Сохранить Данные";
            this.saveDataTrip.MouseEnter += new System.EventHandler(this.saveDataTrip_MouseEnter);
            this.saveDataTrip.MouseLeave += new System.EventHandler(this.saveDataTrip_MouseLeave);
            // 
            // arrivalTimePicker
            // 
            this.arrivalTimePicker.CustomFormat = "   HH:MM";
            this.arrivalTimePicker.Enabled = false;
            this.arrivalTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrivalTimePicker.Location = new System.Drawing.Point(675, 266);
            this.arrivalTimePicker.Name = "arrivalTimePicker";
            this.arrivalTimePicker.ShowUpDown = true;
            this.arrivalTimePicker.Size = new System.Drawing.Size(142, 25);
            this.arrivalTimePicker.TabIndex = 40;
            this.NewTripFormToolTip.SetToolTip(this.arrivalTimePicker, "Время прибытия поезда на станцию назначения");
            // 
            // departureTimePicker
            // 
            this.departureTimePicker.CalendarFont = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departureTimePicker.CustomFormat = "   HH:MM";
            this.departureTimePicker.Enabled = false;
            this.departureTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.departureTimePicker.Location = new System.Drawing.Point(56, 266);
            this.departureTimePicker.Name = "departureTimePicker";
            this.departureTimePicker.ShowUpDown = true;
            this.departureTimePicker.Size = new System.Drawing.Size(142, 25);
            this.departureTimePicker.TabIndex = 39;
            this.NewTripFormToolTip.SetToolTip(this.departureTimePicker, "Время отправления поезда со станции отправления");
            // 
            // addLocomotive
            // 
            this.addLocomotive.AutoSize = true;
            this.addLocomotive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addLocomotive.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addLocomotive.ForeColor = System.Drawing.Color.YellowGreen;
            this.addLocomotive.Location = new System.Drawing.Point(706, 56);
            this.addLocomotive.Name = "addLocomotive";
            this.addLocomotive.Size = new System.Drawing.Size(22, 20);
            this.addLocomotive.TabIndex = 32;
            this.addLocomotive.Text = "+";
            this.addLocomotive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NewTripFormToolTip.SetToolTip(this.addLocomotive, "Добавьте локомотив, на котором совершалась поездка");
            this.addLocomotive.MouseEnter += new System.EventHandler(this.addLocomotive_MouseEnter);
            this.addLocomotive.MouseLeave += new System.EventHandler(this.addLocomotive_MouseLeave);
            // 
            // addPassedStations
            // 
            this.addPassedStations.AutoSize = true;
            this.addPassedStations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addPassedStations.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPassedStations.ForeColor = System.Drawing.Color.GreenYellow;
            this.addPassedStations.Location = new System.Drawing.Point(428, 550);
            this.addPassedStations.Name = "addPassedStations";
            this.addPassedStations.Size = new System.Drawing.Size(22, 20);
            this.addPassedStations.TabIndex = 57;
            this.addPassedStations.Text = "+";
            this.addPassedStations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NewTripFormToolTip.SetToolTip(this.addPassedStations, "Добавьте ключевые станции и время их проследования");
            this.addPassedStations.MouseEnter += new System.EventHandler(this.addPassedStations_MouseEnter);
            this.addPassedStations.MouseLeave += new System.EventHandler(this.addPassedStations_MouseLeave);
            // 
            // addSpeedLimits
            // 
            this.addSpeedLimits.AutoSize = true;
            this.addSpeedLimits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addSpeedLimits.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addSpeedLimits.ForeColor = System.Drawing.Color.GreenYellow;
            this.addSpeedLimits.Location = new System.Drawing.Point(428, 592);
            this.addSpeedLimits.Name = "addSpeedLimits";
            this.addSpeedLimits.Size = new System.Drawing.Size(22, 20);
            this.addSpeedLimits.TabIndex = 59;
            this.addSpeedLimits.Text = "+";
            this.addSpeedLimits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NewTripFormToolTip.SetToolTip(this.addSpeedLimits, "Добавьте ограничения скорости");
            this.addSpeedLimits.MouseEnter += new System.EventHandler(this.addSpeedLimits_MouseEnter);
            this.addSpeedLimits.MouseLeave += new System.EventHandler(this.addSpeedLimits_MouseLeave);
            // 
            // addNotes
            // 
            this.addNotes.AutoSize = true;
            this.addNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNotes.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addNotes.ForeColor = System.Drawing.Color.GreenYellow;
            this.addNotes.Location = new System.Drawing.Point(428, 637);
            this.addNotes.Name = "addNotes";
            this.addNotes.Size = new System.Drawing.Size(22, 20);
            this.addNotes.TabIndex = 61;
            this.addNotes.Text = "+";
            this.addNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NewTripFormToolTip.SetToolTip(this.addNotes, "Добавьте станции, где останавливался поезд");
            this.addNotes.MouseEnter += new System.EventHandler(this.addNotes_MouseEnter);
            this.addNotes.MouseLeave += new System.EventHandler(this.addNotes_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.addNotes);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.addSpeedLimits);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.addPassedStations);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.brakeTestInfo);
            this.groupBox1.Controls.Add(this.trainTailCar);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.trainSpecificLength);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.trainAxles);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.trainMass);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.trainNumber);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.arrivalTrafficLight);
            this.groupBox1.Controls.Add(this.departureTrafficLight);
            this.groupBox1.Controls.Add(this.arrivalTimePicker);
            this.groupBox1.Controls.Add(this.departureTimePicker);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.arrivalStation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.departureStation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.addLocomotive);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.attendanceTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 716);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новая поездка";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.GreenYellow;
            this.label16.Location = new System.Drawing.Point(331, 635);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 22);
            this.label16.TabIndex = 60;
            this.label16.Text = "Заметки:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.GreenYellow;
            this.label15.Location = new System.Drawing.Point(291, 591);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 22);
            this.label15.TabIndex = 58;
            this.label15.Text = "Ограничения:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.GreenYellow;
            this.label14.Location = new System.Drawing.Point(281, 548);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 22);
            this.label14.TabIndex = 56;
            this.label14.Text = "Проследовали:";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(497, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(251, 25);
            this.label13.TabIndex = 55;
            this.label13.Text = "станция прибытия";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(194, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(250, 25);
            this.label12.TabIndex = 54;
            this.label12.Text = "станция отправления";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // brakeTestInfo
            // 
            this.brakeTestInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brakeTestInfo.Location = new System.Drawing.Point(62, 494);
            this.brakeTestInfo.Name = "brakeTestInfo";
            this.brakeTestInfo.Size = new System.Drawing.Size(745, 25);
            this.brakeTestInfo.TabIndex = 53;
            this.brakeTestInfo.Text = "информация о пробе тормозов";
            this.brakeTestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainTailCar
            // 
            this.trainTailCar.Location = new System.Drawing.Point(365, 441);
            this.trainTailCar.Name = "trainTailCar";
            this.trainTailCar.Size = new System.Drawing.Size(207, 25);
            this.trainTailCar.TabIndex = 52;
            this.trainTailCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.GreenYellow;
            this.label11.Location = new System.Drawing.Point(308, 439);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 27);
            this.label11.TabIndex = 51;
            this.label11.Text = "ХВ:";
            // 
            // trainSpecificLength
            // 
            this.trainSpecificLength.Location = new System.Drawing.Point(365, 398);
            this.trainSpecificLength.Name = "trainSpecificLength";
            this.trainSpecificLength.Size = new System.Drawing.Size(207, 25);
            this.trainSpecificLength.TabIndex = 50;
            this.trainSpecificLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.GreenYellow;
            this.label10.Location = new System.Drawing.Point(308, 396);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 27);
            this.label10.TabIndex = 49;
            this.label10.Text = "УД:";
            // 
            // trainAxles
            // 
            this.trainAxles.Location = new System.Drawing.Point(365, 355);
            this.trainAxles.Name = "trainAxles";
            this.trainAxles.Size = new System.Drawing.Size(207, 25);
            this.trainAxles.TabIndex = 48;
            this.trainAxles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.GreenYellow;
            this.label9.Location = new System.Drawing.Point(295, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 27);
            this.label9.TabIndex = 47;
            this.label9.Text = "Оси:";
            // 
            // trainMass
            // 
            this.trainMass.Location = new System.Drawing.Point(365, 311);
            this.trainMass.Name = "trainMass";
            this.trainMass.Size = new System.Drawing.Size(205, 25);
            this.trainMass.TabIndex = 46;
            this.trainMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.GreenYellow;
            this.label8.Location = new System.Drawing.Point(269, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 27);
            this.label8.TabIndex = 45;
            this.label8.Text = "Масса:";
            // 
            // trainNumber
            // 
            this.trainNumber.Location = new System.Drawing.Point(365, 266);
            this.trainNumber.Name = "trainNumber";
            this.trainNumber.Size = new System.Drawing.Size(205, 25);
            this.trainNumber.TabIndex = 44;
            this.trainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trainNumber.Leave += new System.EventHandler(this.trainNumber_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.GreenYellow;
            this.label7.Location = new System.Drawing.Point(230, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 27);
            this.label7.TabIndex = 43;
            this.label7.Text = "N поезда:";
            // 
            // arrivalTrafficLight
            // 
            this.arrivalTrafficLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrivalTrafficLight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.arrivalTrafficLight.Enabled = false;
            this.arrivalTrafficLight.FormattingEnabled = true;
            this.arrivalTrafficLight.Location = new System.Drawing.Point(675, 299);
            this.arrivalTrafficLight.Name = "arrivalTrafficLight";
            this.arrivalTrafficLight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.arrivalTrafficLight.Size = new System.Drawing.Size(142, 26);
            this.arrivalTrafficLight.TabIndex = 42;
            // 
            // departureTrafficLight
            // 
            this.departureTrafficLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.departureTrafficLight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departureTrafficLight.Enabled = false;
            this.departureTrafficLight.FormattingEnabled = true;
            this.departureTrafficLight.Location = new System.Drawing.Point(56, 299);
            this.departureTrafficLight.Name = "departureTrafficLight";
            this.departureTrafficLight.Size = new System.Drawing.Size(142, 26);
            this.departureTrafficLight.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.GreenYellow;
            this.label6.Location = new System.Drawing.Point(701, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 22);
            this.label6.TabIndex = 38;
            this.label6.Text = "Прибытие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.GreenYellow;
            this.label5.Location = new System.Drawing.Point(66, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 37;
            this.label5.Text = "Отправление";
            // 
            // arrivalStation
            // 
            this.arrivalStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrivalStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.arrivalStation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.arrivalStation.FormattingEnabled = true;
            this.arrivalStation.Location = new System.Drawing.Point(498, 126);
            this.arrivalStation.Name = "arrivalStation";
            this.arrivalStation.Size = new System.Drawing.Size(250, 31);
            this.arrivalStation.TabIndex = 36;
            this.arrivalStation.SelectedIndexChanged += new System.EventHandler(this.arrivalStation_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.GreenYellow;
            this.label4.Location = new System.Drawing.Point(459, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 31);
            this.label4.TabIndex = 35;
            this.label4.Text = "-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // departureStation
            // 
            this.departureStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.departureStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departureStation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departureStation.FormattingEnabled = true;
            this.departureStation.Location = new System.Drawing.Point(194, 126);
            this.departureStation.Name = "departureStation";
            this.departureStation.Size = new System.Drawing.Size(250, 31);
            this.departureStation.TabIndex = 34;
            this.departureStation.SelectedIndexChanged += new System.EventHandler(this.departureStation_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(51, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 29);
            this.label3.TabIndex = 33;
            this.label3.Text = "Маршрут:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.GreenYellow;
            this.label2.Location = new System.Drawing.Point(590, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 22);
            this.label2.TabIndex = 31;
            this.label2.Text = "Локомотив:";
            // 
            // attendanceTimePicker
            // 
            this.attendanceTimePicker.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.attendanceTimePicker.CalendarTitleForeColor = System.Drawing.Color.GreenYellow;
            this.attendanceTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attendanceTimePicker.CustomFormat = "дата: dd-MM-yyyy, время: HH:MM";
            this.attendanceTimePicker.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.attendanceTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.attendanceTimePicker.Location = new System.Drawing.Point(100, 50);
            this.attendanceTimePicker.Name = "attendanceTimePicker";
            this.attendanceTimePicker.Size = new System.Drawing.Size(350, 29);
            this.attendanceTimePicker.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 29;
            this.label1.Text = "Явка:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NewTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveDataTrip);
            this.Controls.Add(this.backToStartForm);
            this.ForeColor = System.Drawing.Color.GreenYellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewTripForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ТЧ: Новая поездка";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.NewTripForm_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label backToStartForm;
        private Label saveDataTrip;
        private ToolTip NewTripFormToolTip;
        private GroupBox groupBox1;
        private TextBox trainTailCar;
        private Label label11;
        private TextBox trainSpecificLength;
        private Label label10;
        private TextBox trainAxles;
        private Label label9;
        private TextBox trainMass;
        private Label label8;
        private TextBox trainNumber;
        private Label label7;
        private ComboBox arrivalTrafficLight;
        private ComboBox departureTrafficLight;
        private DateTimePicker arrivalTimePicker;
        private DateTimePicker departureTimePicker;
        private Label label6;
        private Label label5;
        private ComboBox arrivalStation;
        private Label label4;
        private ComboBox departureStation;
        private Label label3;
        private Label addLocomotive;
        private Label label2;
        private DateTimePicker attendanceTimePicker;
        private Label label1;
        private Label brakeTestInfo;
        private Label label13;
        private Label label12;
        private Label addPassedStations;
        private Label label14;
        private Label addSpeedLimits;
        private Label label15;
        private Label label16;
        private Label addNotes;
    }
}