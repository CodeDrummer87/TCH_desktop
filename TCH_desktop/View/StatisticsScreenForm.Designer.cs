﻿namespace TCH_desktop.View
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
    }
}