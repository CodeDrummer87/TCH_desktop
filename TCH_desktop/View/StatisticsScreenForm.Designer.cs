namespace TCH_desktop.View
{
    partial class StatisticsScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsScreenForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.locoResultLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.locoConditionLabel = new System.Windows.Forms.Label();
            this.colonLabel = new System.Windows.Forms.Label();
            this.locoSeriesLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sumWeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTravelTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.arrowRight = new System.Windows.Forms.PictureBox();
            this.arrowLeft = new System.Windows.Forms.PictureBox();
            this.trafficRouteAndCounter = new System.Windows.Forms.Label();
            this.totalTrips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeScreen = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.locoResultLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.locoConditionLabel);
            this.groupBox1.Controls.Add(this.colonLabel);
            this.groupBox1.Controls.Add(this.locoSeriesLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sumWeight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.totalTravelTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.totalTrips);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 716);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Экран Статистики ";
            // 
            // locoResultLabel
            // 
            this.locoResultLabel.AutoSize = true;
            this.locoResultLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.locoResultLabel.Location = new System.Drawing.Point(466, 304);
            this.locoResultLabel.Name = "locoResultLabel";
            this.locoResultLabel.Size = new System.Drawing.Size(65, 22);
            this.locoResultLabel.TabIndex = 12;
            this.locoResultLabel.Text = "result";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Moccasin;
            this.label7.Location = new System.Drawing.Point(195, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "локомотив серии";
            // 
            // locoConditionLabel
            // 
            this.locoConditionLabel.AutoSize = true;
            this.locoConditionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locoConditionLabel.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.locoConditionLabel.ForeColor = System.Drawing.Color.Gold;
            this.locoConditionLabel.Location = new System.Drawing.Point(109, 304);
            this.locoConditionLabel.Name = "locoConditionLabel";
            this.locoConditionLabel.Size = new System.Drawing.Size(86, 22);
            this.locoConditionLabel.TabIndex = 10;
            this.locoConditionLabel.Text = "старый";
            this.locoConditionLabel.Click += new System.EventHandler(this.locoConditionLabel_Click);
            // 
            // colonLabel
            // 
            this.colonLabel.AutoSize = true;
            this.colonLabel.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.colonLabel.ForeColor = System.Drawing.Color.Moccasin;
            this.colonLabel.Location = new System.Drawing.Point(443, 304);
            this.colonLabel.Name = "colonLabel";
            this.colonLabel.Size = new System.Drawing.Size(23, 22);
            this.colonLabel.TabIndex = 9;
            this.colonLabel.Text = ": ";
            // 
            // locoSeriesLabel
            // 
            this.locoSeriesLabel.AutoSize = true;
            this.locoSeriesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locoSeriesLabel.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.locoSeriesLabel.ForeColor = System.Drawing.Color.Gold;
            this.locoSeriesLabel.Location = new System.Drawing.Point(383, 304);
            this.locoSeriesLabel.Name = "locoSeriesLabel";
            this.locoSeriesLabel.Size = new System.Drawing.Size(65, 22);
            this.locoSeriesLabel.TabIndex = 8;
            this.locoSeriesLabel.Text = "ВЛ10";
            this.locoSeriesLabel.Click += new System.EventHandler(this.locoSeriesLabel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Moccasin;
            this.label4.Location = new System.Drawing.Point(29, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Самый";
            // 
            // sumWeight
            // 
            this.sumWeight.AutoSize = true;
            this.sumWeight.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sumWeight.Location = new System.Drawing.Point(397, 232);
            this.sumWeight.Name = "sumWeight";
            this.sumWeight.Size = new System.Drawing.Size(22, 22);
            this.sumWeight.TabIndex = 6;
            this.sumWeight.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Moccasin;
            this.label3.Location = new System.Drawing.Point(29, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тонн брутто перевезено [сумма]:";
            // 
            // totalTravelTime
            // 
            this.totalTravelTime.AutoSize = true;
            this.totalTravelTime.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalTravelTime.Location = new System.Drawing.Point(686, 57);
            this.totalTravelTime.Name = "totalTravelTime";
            this.totalTravelTime.Size = new System.Drawing.Size(22, 22);
            this.totalTravelTime.TabIndex = 4;
            this.totalTravelTime.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Moccasin;
            this.label2.Location = new System.Drawing.Point(499, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Времени в пути:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.arrowRight);
            this.panel1.Controls.Add(this.arrowLeft);
            this.panel1.Controls.Add(this.trafficRouteAndCounter);
            this.panel1.Location = new System.Drawing.Point(29, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 68);
            this.panel1.TabIndex = 2;
            // 
            // arrowRight
            // 
            this.arrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowRight.Image = ((System.Drawing.Image)(resources.GetObject("arrowRight.Image")));
            this.arrowRight.Location = new System.Drawing.Point(758, 9);
            this.arrowRight.Name = "arrowRight";
            this.arrowRight.Size = new System.Drawing.Size(50, 50);
            this.arrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.arrowRight.TabIndex = 2;
            this.arrowRight.TabStop = false;
            this.arrowRight.Click += new System.EventHandler(this.arrowRight_Click);
            this.arrowRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrowRight_MouseDown);
            this.arrowRight.MouseEnter += new System.EventHandler(this.arrowRight_MouseEnter);
            this.arrowRight.MouseLeave += new System.EventHandler(this.arrowRight_MouseLeave);
            this.arrowRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrowRight_MouseUp);
            // 
            // arrowLeft
            // 
            this.arrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowLeft.Image = ((System.Drawing.Image)(resources.GetObject("arrowLeft.Image")));
            this.arrowLeft.Location = new System.Drawing.Point(9, 9);
            this.arrowLeft.Name = "arrowLeft";
            this.arrowLeft.Size = new System.Drawing.Size(50, 50);
            this.arrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.arrowLeft.TabIndex = 1;
            this.arrowLeft.TabStop = false;
            this.arrowLeft.Click += new System.EventHandler(this.arrowLeft_Click);
            this.arrowLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrowLeft_MouseDown);
            this.arrowLeft.MouseEnter += new System.EventHandler(this.arrowLeft_MouseEnter);
            this.arrowLeft.MouseLeave += new System.EventHandler(this.arrowLeft_MouseLeave);
            this.arrowLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrowLeft_MouseUp);
            // 
            // trafficRouteAndCounter
            // 
            this.trafficRouteAndCounter.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trafficRouteAndCounter.ForeColor = System.Drawing.Color.MistyRose;
            this.trafficRouteAndCounter.Location = new System.Drawing.Point(80, 14);
            this.trafficRouteAndCounter.Name = "trafficRouteAndCounter";
            this.trafficRouteAndCounter.Size = new System.Drawing.Size(660, 40);
            this.trafficRouteAndCounter.TabIndex = 0;
            this.trafficRouteAndCounter.Text = "Маршрут Поездки";
            this.trafficRouteAndCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalTrips
            // 
            this.totalTrips.AutoSize = true;
            this.totalTrips.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalTrips.Location = new System.Drawing.Point(197, 57);
            this.totalTrips.Name = "totalTrips";
            this.totalTrips.Size = new System.Drawing.Size(22, 22);
            this.totalTrips.TabIndex = 1;
            this.totalTrips.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Moccasin;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Всего поездок: ";
            // 
            // closeScreen
            // 
            this.closeScreen.AutoSize = true;
            this.closeScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeScreen.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeScreen.Location = new System.Drawing.Point(23, 760);
            this.closeScreen.Name = "closeScreen";
            this.closeScreen.Size = new System.Drawing.Size(99, 22);
            this.closeScreen.TabIndex = 1;
            this.closeScreen.Text = "Закрыть";
            this.closeScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeScreen.Click += new System.EventHandler(this.closeScreen_Click);
            this.closeScreen.MouseEnter += new System.EventHandler(this.closeScreen_MouseEnter);
            this.closeScreen.MouseLeave += new System.EventHandler(this.closeScreen_MouseLeave);
            // 
            // StatisticsScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.closeScreen);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.GreenYellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatisticsScreenForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ТЧ: Экран Статистики";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StatisticsScreenForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label closeScreen;
        private Label label1;
        private Label totalTrips;
        private Panel panel1;
        private Label trafficRouteAndCounter;
        private PictureBox arrowLeft;
        private PictureBox arrowRight;
        private Label totalTravelTime;
        private Label label2;
        private Label sumWeight;
        private Label label3;
        private Label label7;
        private Label locoConditionLabel;
        private Label colonLabel;
        private Label locoSeriesLabel;
        private Label label4;
        private Label locoResultLabel;
    }
}