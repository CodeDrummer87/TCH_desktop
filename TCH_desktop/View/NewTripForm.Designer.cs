﻿namespace TCH_desktop.View
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
            this.removeLocomotive = new System.Windows.Forms.Label();
            this.directionSwitchCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.elRecoveryFactorTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.elRecoveryRequiredValue = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.elAmountRequiredValue = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.electricityFactorTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.distanceTextBox = new System.Windows.Forms.TextBox();
            this.trainType = new System.Windows.Forms.Panel();
            this.doubleTrain = new System.Windows.Forms.RadioButton();
            this.singleLoco = new System.Windows.Forms.RadioButton();
            this.freightTrain = new System.Windows.Forms.RadioButton();
            this.removeNotes = new System.Windows.Forms.Label();
            this.notesInfo = new System.Windows.Forms.Label();
            this.removeSpeedLimits = new System.Windows.Forms.Label();
            this.speedLimitsInfo = new System.Windows.Forms.Label();
            this.removePastStations = new System.Windows.Forms.Label();
            this.pastStationsInfo = new System.Windows.Forms.Label();
            this.brakeTestInfo = new System.Windows.Forms.Label();
            this.removeBrakeTest = new System.Windows.Forms.Label();
            this.addBrakeTest = new System.Windows.Forms.Label();
            this.addBrakeTestLabel = new System.Windows.Forms.Label();
            this.locoNumber = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.trainType.SuspendLayout();
            this.SuspendLayout();
            // 
            // backToStartForm
            // 
            this.backToStartForm.AutoSize = true;
            this.backToStartForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToStartForm.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backToStartForm.Location = new System.Drawing.Point(23, 760);
            this.backToStartForm.Name = "backToStartForm";
            this.backToStartForm.Size = new System.Drawing.Size(87, 22);
            this.backToStartForm.TabIndex = 0;
            this.backToStartForm.Text = "Отмена";
            this.backToStartForm.Click += new System.EventHandler(this.backToStartForm_Click);
            this.backToStartForm.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.backToStartForm.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // saveDataTrip
            // 
            this.saveDataTrip.AutoSize = true;
            this.saveDataTrip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveDataTrip.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveDataTrip.Location = new System.Drawing.Point(657, 760);
            this.saveDataTrip.Name = "saveDataTrip";
            this.saveDataTrip.Size = new System.Drawing.Size(212, 22);
            this.saveDataTrip.TabIndex = 1;
            this.saveDataTrip.Text = "Сохранить Поездку";
            this.saveDataTrip.Click += new System.EventHandler(this.saveDataTrip_Click);
            this.saveDataTrip.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.saveDataTrip.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // arrivalTimePicker
            // 
            this.arrivalTimePicker.CustomFormat = "   HH:mm";
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
            this.departureTimePicker.CustomFormat = "   HH:mm";
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
            this.addLocomotive.Click += new System.EventHandler(this.addLocomotive_Click);
            this.addLocomotive.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addLocomotive.MouseLeave += new System.EventHandler(this.labelMouseLeave);
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
            this.addPassedStations.Click += new System.EventHandler(this.addPassedStations_Click);
            this.addPassedStations.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addPassedStations.MouseLeave += new System.EventHandler(this.labelMouseLeave);
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
            this.addSpeedLimits.Click += new System.EventHandler(this.addSpeedLimits_Click);
            this.addSpeedLimits.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addSpeedLimits.MouseLeave += new System.EventHandler(this.labelMouseLeave);
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
            this.addNotes.Click += new System.EventHandler(this.addNotes_Click);
            this.addNotes.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addNotes.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // removeLocomotive
            // 
            this.removeLocomotive.AutoSize = true;
            this.removeLocomotive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeLocomotive.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeLocomotive.ForeColor = System.Drawing.Color.Red;
            this.removeLocomotive.Location = new System.Drawing.Point(830, 58);
            this.removeLocomotive.Name = "removeLocomotive";
            this.removeLocomotive.Size = new System.Drawing.Size(19, 17);
            this.removeLocomotive.TabIndex = 63;
            this.removeLocomotive.Text = "X";
            this.removeLocomotive.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NewTripFormToolTip.SetToolTip(this.removeLocomotive, "Отвязать локомотив от текущей поездки");
            this.removeLocomotive.Visible = false;
            this.removeLocomotive.Click += new System.EventHandler(this.removeLocomotive_Click);
            this.removeLocomotive.MouseEnter += new System.EventHandler(this.anotherLabelMouseEnter);
            this.removeLocomotive.MouseLeave += new System.EventHandler(this.anotherLabelMouseLeave);
            // 
            // directionSwitchCheckBox
            // 
            this.directionSwitchCheckBox.AutoSize = true;
            this.directionSwitchCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.directionSwitchCheckBox.Enabled = false;
            this.directionSwitchCheckBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.directionSwitchCheckBox.ForeColor = System.Drawing.Color.Silver;
            this.directionSwitchCheckBox.Location = new System.Drawing.Point(586, 265);
            this.directionSwitchCheckBox.Name = "directionSwitchCheckBox";
            this.directionSwitchCheckBox.Size = new System.Drawing.Size(78, 25);
            this.directionSwitchCheckBox.TabIndex = 88;
            this.directionSwitchCheckBox.Text = "Ч<~>Н";
            this.NewTripFormToolTip.SetToolTip(this.directionSwitchCheckBox, "Поставьте галочку, если поезд менял направление в пути следования");
            this.directionSwitchCheckBox.UseVisualStyleBackColor = true;
            this.directionSwitchCheckBox.CheckedChanged += new System.EventHandler(this.directionSwitchCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.directionSwitchCheckBox);
            this.groupBox1.Controls.Add(this.elRecoveryFactorTextBox);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.elRecoveryRequiredValue);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.elAmountRequiredValue);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.electricityFactorTextBox);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.distanceTextBox);
            this.groupBox1.Controls.Add(this.trainType);
            this.groupBox1.Controls.Add(this.removeNotes);
            this.groupBox1.Controls.Add(this.notesInfo);
            this.groupBox1.Controls.Add(this.removeSpeedLimits);
            this.groupBox1.Controls.Add(this.speedLimitsInfo);
            this.groupBox1.Controls.Add(this.removePastStations);
            this.groupBox1.Controls.Add(this.pastStationsInfo);
            this.groupBox1.Controls.Add(this.brakeTestInfo);
            this.groupBox1.Controls.Add(this.removeBrakeTest);
            this.groupBox1.Controls.Add(this.addBrakeTest);
            this.groupBox1.Controls.Add(this.addBrakeTestLabel);
            this.groupBox1.Controls.Add(this.removeLocomotive);
            this.groupBox1.Controls.Add(this.locoNumber);
            this.groupBox1.Controls.Add(this.addNotes);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.addSpeedLimits);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.addPassedStations);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
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
            this.groupBox1.Text = " Новая поездка ";
            // 
            // elRecoveryFactorTextBox
            // 
            this.elRecoveryFactorTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.elRecoveryFactorTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.elRecoveryFactorTextBox.Location = new System.Drawing.Point(710, 439);
            this.elRecoveryFactorTextBox.Name = "elRecoveryFactorTextBox";
            this.elRecoveryFactorTextBox.Size = new System.Drawing.Size(77, 25);
            this.elRecoveryFactorTextBox.TabIndex = 86;
            this.elRecoveryFactorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elRecoveryFactorTextBox.TextChanged += new System.EventHandler(this.CalcElectricityRecoveryRequired);
            this.elRecoveryFactorTextBox.Enter += new System.EventHandler(this.ClearTextBox);
            this.elRecoveryFactorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPressForFactor);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(710, 424);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 15);
            this.label21.TabIndex = 85;
            this.label21.Text = "Коэфф-т";
            // 
            // elRecoveryRequiredValue
            // 
            this.elRecoveryRequiredValue.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.elRecoveryRequiredValue.ForeColor = System.Drawing.Color.Yellow;
            this.elRecoveryRequiredValue.Location = new System.Drawing.Point(712, 383);
            this.elRecoveryRequiredValue.Name = "elRecoveryRequiredValue";
            this.elRecoveryRequiredValue.Size = new System.Drawing.Size(72, 25);
            this.elRecoveryRequiredValue.TabIndex = 84;
            this.elRecoveryRequiredValue.Text = "0";
            this.elRecoveryRequiredValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(700, 353);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 18);
            this.label20.TabIndex = 83;
            this.label20.Text = "Рекуперация";
            // 
            // elAmountRequiredValue
            // 
            this.elAmountRequiredValue.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.elAmountRequiredValue.ForeColor = System.Drawing.Color.Yellow;
            this.elAmountRequiredValue.Location = new System.Drawing.Point(88, 383);
            this.elAmountRequiredValue.Name = "elAmountRequiredValue";
            this.elAmountRequiredValue.Size = new System.Drawing.Size(72, 25);
            this.elAmountRequiredValue.TabIndex = 82;
            this.elAmountRequiredValue.Text = "0";
            this.elAmountRequiredValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(56, 353);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 18);
            this.label19.TabIndex = 81;
            this.label19.Text = "Расчёт Эл.Энергии";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(83, 424);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 15);
            this.label18.TabIndex = 80;
            this.label18.Text = "Коэфф-т";
            // 
            // electricityFactorTextBox
            // 
            this.electricityFactorTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.electricityFactorTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.electricityFactorTextBox.Location = new System.Drawing.Point(83, 439);
            this.electricityFactorTextBox.Name = "electricityFactorTextBox";
            this.electricityFactorTextBox.Size = new System.Drawing.Size(77, 25);
            this.electricityFactorTextBox.TabIndex = 79;
            this.electricityFactorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.electricityFactorTextBox.TextChanged += new System.EventHandler(this.CalcElectricityAmount);
            this.electricityFactorTextBox.Enter += new System.EventHandler(this.ClearTextBox);
            this.electricityFactorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPressForFactor);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(702, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 15);
            this.label17.TabIndex = 78;
            this.label17.Text = "расстояние, км";
            // 
            // distanceTextBox
            // 
            this.distanceTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.distanceTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.distanceTextBox.Location = new System.Drawing.Point(704, 123);
            this.distanceTextBox.Name = "distanceTextBox";
            this.distanceTextBox.Size = new System.Drawing.Size(145, 31);
            this.distanceTextBox.TabIndex = 77;
            this.distanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.distanceTextBox.TextChanged += new System.EventHandler(this.CalcElectricityIndicators);
            this.distanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPress);
            this.distanceTextBox.Leave += new System.EventHandler(this.distanceTextBox_Leave);
            // 
            // trainType
            // 
            this.trainType.Controls.Add(this.doubleTrain);
            this.trainType.Controls.Add(this.singleLoco);
            this.trainType.Controls.Add(this.freightTrain);
            this.trainType.ForeColor = System.Drawing.Color.GreenYellow;
            this.trainType.Location = new System.Drawing.Point(66, 166);
            this.trainType.Name = "trainType";
            this.trainType.Size = new System.Drawing.Size(735, 43);
            this.trainType.TabIndex = 76;
            // 
            // doubleTrain
            // 
            this.doubleTrain.AutoSize = true;
            this.doubleTrain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doubleTrain.Location = new System.Drawing.Point(240, 14);
            this.doubleTrain.Name = "doubleTrain";
            this.doubleTrain.Size = new System.Drawing.Size(209, 22);
            this.doubleTrain.TabIndex = 2;
            this.doubleTrain.TabStop = true;
            this.doubleTrain.Text = "Сдвоенный поезд";
            this.doubleTrain.UseVisualStyleBackColor = true;
            this.doubleTrain.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // singleLoco
            // 
            this.singleLoco.AutoSize = true;
            this.singleLoco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.singleLoco.Location = new System.Drawing.Point(469, 14);
            this.singleLoco.Name = "singleLoco";
            this.singleLoco.Size = new System.Drawing.Size(257, 22);
            this.singleLoco.TabIndex = 1;
            this.singleLoco.Text = "Следование резервом";
            this.singleLoco.UseVisualStyleBackColor = true;
            this.singleLoco.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // freightTrain
            // 
            this.freightTrain.AutoSize = true;
            this.freightTrain.Checked = true;
            this.freightTrain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.freightTrain.Location = new System.Drawing.Point(17, 14);
            this.freightTrain.Name = "freightTrain";
            this.freightTrain.Size = new System.Drawing.Size(197, 22);
            this.freightTrain.TabIndex = 0;
            this.freightTrain.TabStop = true;
            this.freightTrain.Text = "Грузовой поезд";
            this.freightTrain.UseVisualStyleBackColor = true;
            this.freightTrain.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // removeNotes
            // 
            this.removeNotes.AutoSize = true;
            this.removeNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeNotes.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeNotes.ForeColor = System.Drawing.Color.Red;
            this.removeNotes.Location = new System.Drawing.Point(554, 638);
            this.removeNotes.Name = "removeNotes";
            this.removeNotes.Size = new System.Drawing.Size(19, 17);
            this.removeNotes.TabIndex = 75;
            this.removeNotes.Text = "X";
            this.removeNotes.Click += new System.EventHandler(this.removeNotes_Click);
            this.removeNotes.MouseEnter += new System.EventHandler(this.anotherLabelMouseEnter);
            this.removeNotes.MouseLeave += new System.EventHandler(this.anotherLabelMouseLeave);
            // 
            // notesInfo
            // 
            this.notesInfo.AutoSize = true;
            this.notesInfo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.notesInfo.ForeColor = System.Drawing.Color.Yellow;
            this.notesInfo.Location = new System.Drawing.Point(459, 637);
            this.notesInfo.Name = "notesInfo";
            this.notesInfo.Size = new System.Drawing.Size(89, 18);
            this.notesInfo.TabIndex = 74;
            this.notesInfo.Text = "Описание";
            // 
            // removeSpeedLimits
            // 
            this.removeSpeedLimits.AutoSize = true;
            this.removeSpeedLimits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeSpeedLimits.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeSpeedLimits.ForeColor = System.Drawing.Color.Red;
            this.removeSpeedLimits.Location = new System.Drawing.Point(554, 596);
            this.removeSpeedLimits.Name = "removeSpeedLimits";
            this.removeSpeedLimits.Size = new System.Drawing.Size(19, 17);
            this.removeSpeedLimits.TabIndex = 73;
            this.removeSpeedLimits.Text = "X";
            this.removeSpeedLimits.Click += new System.EventHandler(this.removeSpeedLimits_Click);
            this.removeSpeedLimits.MouseEnter += new System.EventHandler(this.anotherLabelMouseEnter);
            this.removeSpeedLimits.MouseLeave += new System.EventHandler(this.anotherLabelMouseLeave);
            // 
            // speedLimitsInfo
            // 
            this.speedLimitsInfo.AutoSize = true;
            this.speedLimitsInfo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.speedLimitsInfo.ForeColor = System.Drawing.Color.Yellow;
            this.speedLimitsInfo.Location = new System.Drawing.Point(459, 594);
            this.speedLimitsInfo.Name = "speedLimitsInfo";
            this.speedLimitsInfo.Size = new System.Drawing.Size(89, 18);
            this.speedLimitsInfo.TabIndex = 72;
            this.speedLimitsInfo.Text = "Описание";
            this.speedLimitsInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // removePastStations
            // 
            this.removePastStations.AutoSize = true;
            this.removePastStations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removePastStations.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removePastStations.ForeColor = System.Drawing.Color.Red;
            this.removePastStations.Location = new System.Drawing.Point(554, 554);
            this.removePastStations.Name = "removePastStations";
            this.removePastStations.Size = new System.Drawing.Size(19, 17);
            this.removePastStations.TabIndex = 71;
            this.removePastStations.Text = "X";
            this.removePastStations.Click += new System.EventHandler(this.removePastStations_Click);
            this.removePastStations.MouseEnter += new System.EventHandler(this.anotherLabelMouseEnter);
            this.removePastStations.MouseLeave += new System.EventHandler(this.anotherLabelMouseLeave);
            // 
            // pastStationsInfo
            // 
            this.pastStationsInfo.AutoSize = true;
            this.pastStationsInfo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pastStationsInfo.ForeColor = System.Drawing.Color.Yellow;
            this.pastStationsInfo.Location = new System.Drawing.Point(459, 552);
            this.pastStationsInfo.Name = "pastStationsInfo";
            this.pastStationsInfo.Size = new System.Drawing.Size(89, 18);
            this.pastStationsInfo.TabIndex = 70;
            this.pastStationsInfo.Text = "Описание";
            this.pastStationsInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // brakeTestInfo
            // 
            this.brakeTestInfo.AutoSize = true;
            this.brakeTestInfo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brakeTestInfo.ForeColor = System.Drawing.Color.Yellow;
            this.brakeTestInfo.Location = new System.Drawing.Point(459, 509);
            this.brakeTestInfo.Name = "brakeTestInfo";
            this.brakeTestInfo.Size = new System.Drawing.Size(89, 18);
            this.brakeTestInfo.TabIndex = 68;
            this.brakeTestInfo.Text = "Описание";
            this.brakeTestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // removeBrakeTest
            // 
            this.removeBrakeTest.AutoSize = true;
            this.removeBrakeTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeBrakeTest.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeBrakeTest.ForeColor = System.Drawing.Color.Red;
            this.removeBrakeTest.Location = new System.Drawing.Point(554, 512);
            this.removeBrakeTest.Name = "removeBrakeTest";
            this.removeBrakeTest.Size = new System.Drawing.Size(19, 17);
            this.removeBrakeTest.TabIndex = 67;
            this.removeBrakeTest.Text = "X";
            this.removeBrakeTest.Visible = false;
            this.removeBrakeTest.Click += new System.EventHandler(this.removeBrakeTest_Click);
            this.removeBrakeTest.MouseEnter += new System.EventHandler(this.anotherLabelMouseEnter);
            this.removeBrakeTest.MouseLeave += new System.EventHandler(this.anotherLabelMouseLeave);
            // 
            // addBrakeTest
            // 
            this.addBrakeTest.AutoSize = true;
            this.addBrakeTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBrakeTest.Enabled = false;
            this.addBrakeTest.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addBrakeTest.ForeColor = System.Drawing.Color.GreenYellow;
            this.addBrakeTest.Location = new System.Drawing.Point(428, 509);
            this.addBrakeTest.Name = "addBrakeTest";
            this.addBrakeTest.Size = new System.Drawing.Size(22, 20);
            this.addBrakeTest.TabIndex = 66;
            this.addBrakeTest.Text = "+";
            this.addBrakeTest.Click += new System.EventHandler(this.addBrakeTest_Click);
            this.addBrakeTest.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addBrakeTest.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // addBrakeTestLabel
            // 
            this.addBrakeTestLabel.AutoSize = true;
            this.addBrakeTestLabel.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addBrakeTestLabel.ForeColor = System.Drawing.Color.GreenYellow;
            this.addBrakeTestLabel.Location = new System.Drawing.Point(171, 507);
            this.addBrakeTestLabel.Name = "addBrakeTestLabel";
            this.addBrakeTestLabel.Size = new System.Drawing.Size(250, 22);
            this.addBrakeTestLabel.TabIndex = 65;
            this.addBrakeTestLabel.Text = "Добавить пробу тормозов:";
            // 
            // locoNumber
            // 
            this.locoNumber.AutoSize = true;
            this.locoNumber.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.locoNumber.ForeColor = System.Drawing.Color.Yellow;
            this.locoNumber.Location = new System.Drawing.Point(734, 58);
            this.locoNumber.Name = "locoNumber";
            this.locoNumber.Size = new System.Drawing.Size(90, 18);
            this.locoNumber.TabIndex = 62;
            this.locoNumber.Text = "ВЛ10-824";
            this.locoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.locoNumber.Visible = false;
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
            this.label13.Location = new System.Drawing.Point(440, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(251, 25);
            this.label13.TabIndex = 55;
            this.label13.Text = "станция прибытия";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(156, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(250, 25);
            this.label12.TabIndex = 54;
            this.label12.Text = "станция отправления";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // trainTailCar
            // 
            this.trainTailCar.Location = new System.Drawing.Point(365, 441);
            this.trainTailCar.MaxLength = 8;
            this.trainTailCar.Name = "trainTailCar";
            this.trainTailCar.Size = new System.Drawing.Size(207, 25);
            this.trainTailCar.TabIndex = 52;
            this.trainTailCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trainTailCar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPress);
            this.trainTailCar.Leave += new System.EventHandler(this.trainTailCar_Leave);
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
            this.trainSpecificLength.MaxLength = 3;
            this.trainSpecificLength.Name = "trainSpecificLength";
            this.trainSpecificLength.Size = new System.Drawing.Size(207, 25);
            this.trainSpecificLength.TabIndex = 50;
            this.trainSpecificLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trainSpecificLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPress);
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
            this.trainAxles.MaxLength = 3;
            this.trainAxles.Name = "trainAxles";
            this.trainAxles.Size = new System.Drawing.Size(207, 25);
            this.trainAxles.TabIndex = 48;
            this.trainAxles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trainAxles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPress);
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
            this.trainMass.MaxLength = 5;
            this.trainMass.Name = "trainMass";
            this.trainMass.Size = new System.Drawing.Size(205, 25);
            this.trainMass.TabIndex = 46;
            this.trainMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trainMass.TextChanged += new System.EventHandler(this.CalcElectricityIndicators);
            this.trainMass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPress);
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
            this.trainNumber.MaxLength = 5;
            this.trainNumber.Name = "trainNumber";
            this.trainNumber.Size = new System.Drawing.Size(205, 25);
            this.trainNumber.TabIndex = 44;
            this.trainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trainNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkKeyPress);
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
            this.arrivalStation.Location = new System.Drawing.Point(441, 124);
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
            this.label4.Location = new System.Drawing.Point(412, 124);
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
            this.departureStation.Location = new System.Drawing.Point(156, 124);
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
            this.label3.Location = new System.Drawing.Point(25, 124);
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
            this.attendanceTimePicker.CustomFormat = "дата: dd-MM-yyyy, время: HH:mm";
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
            this.Load += new System.EventHandler(this.NewTripForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.trainType.ResumeLayout(false);
            this.trainType.PerformLayout();
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
        private Label label13;
        private Label label12;
        private Label addPassedStations;
        private Label label14;
        private Label addSpeedLimits;
        private Label label15;
        private Label label16;
        private Label addNotes;
        private Label locoNumber;
        private Label removeLocomotive;
        private Label addBrakeTestLabel;
        private Label addBrakeTest;
        private Label removeBrakeTest;
        private Label brakeTestInfo;
        private Label pastStationsInfo;
        private Label removePastStations;
        private Label removeSpeedLimits;
        private Label speedLimitsInfo;
        private Label removeNotes;
        private Label notesInfo;
        public Panel trainType;
        public RadioButton singleLoco;
        public RadioButton freightTrain;
        public RadioButton doubleTrain;
        private TextBox distanceTextBox;
        private Label label17;
        private TextBox electricityFactorTextBox;
        private Label label18;
        private Label elAmountRequiredValue;
        private Label label19;
        private Label label20;
        private Label elRecoveryRequiredValue;
        private TextBox elRecoveryFactorTextBox;
        private Label label21;
        private CheckBox directionSwitchCheckBox;
    }
}