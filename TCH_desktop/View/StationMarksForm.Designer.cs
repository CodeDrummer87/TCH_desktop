﻿namespace TCH_desktop.View
{
    partial class StationMarksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationMarksForm));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tabTip = new System.Windows.Forms.Label();
            this.removeEntry = new System.Windows.Forms.Label();
            this.addNewStation = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Label();
            this.addPastStationButton = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.AutoSize = true;
            this.groupBox.Controls.Add(this.tabTip);
            this.groupBox.Controls.Add(this.removeEntry);
            this.groupBox.Controls.Add(this.addNewStation);
            this.groupBox.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(826, 347);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = " Отметки о проследовании станций ";
            // 
            // tabTip
            // 
            this.tabTip.ForeColor = System.Drawing.Color.DimGray;
            this.tabTip.Location = new System.Drawing.Point(51, 92);
            this.tabTip.Name = "tabTip";
            this.tabTip.Size = new System.Drawing.Size(333, 17);
            this.tabTip.TabIndex = 2;
            this.tabTip.Text = "нажмите Tab для фиксации";
            this.tabTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tabTip.Visible = false;
            // 
            // removeEntry
            // 
            this.removeEntry.AutoSize = true;
            this.removeEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeEntry.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeEntry.ForeColor = System.Drawing.Color.Red;
            this.removeEntry.Location = new System.Drawing.Point(51, 57);
            this.removeEntry.Name = "removeEntry";
            this.removeEntry.Size = new System.Drawing.Size(19, 17);
            this.removeEntry.TabIndex = 1;
            this.removeEntry.Text = "X";
            this.removeEntry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.removeEntry.Visible = false;
            this.removeEntry.Click += new System.EventHandler(this.removeEntry_Click);
            this.removeEntry.MouseEnter += new System.EventHandler(this.removeEntry_MouseEnter);
            this.removeEntry.MouseLeave += new System.EventHandler(this.removeEntry_MouseLeave);
            // 
            // addNewStation
            // 
            this.addNewStation.AutoSize = true;
            this.addNewStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNewStation.Font = new System.Drawing.Font("Verdana", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.addNewStation.ForeColor = System.Drawing.Color.Yellow;
            this.addNewStation.Location = new System.Drawing.Point(19, 52);
            this.addNewStation.Name = "addNewStation";
            this.addNewStation.Size = new System.Drawing.Size(26, 22);
            this.addNewStation.TabIndex = 0;
            this.addNewStation.Text = "+";
            this.addNewStation.Click += new System.EventHandler(this.addNewStation_Click);
            this.addNewStation.MouseEnter += new System.EventHandler(this.addNewStation_MouseEnter);
            this.addNewStation.MouseLeave += new System.EventHandler(this.addNewStation_MouseLeave);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.ForeColor = System.Drawing.Color.GreenYellow;
            this.cancelButton.Location = new System.Drawing.Point(31, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.cancelButton.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // addPastStationButton
            // 
            this.addPastStationButton.AutoSize = true;
            this.addPastStationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addPastStationButton.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPastStationButton.ForeColor = System.Drawing.Color.GreenYellow;
            this.addPastStationButton.Location = new System.Drawing.Point(714, 362);
            this.addPastStationButton.Name = "addPastStationButton";
            this.addPastStationButton.Size = new System.Drawing.Size(109, 22);
            this.addPastStationButton.TabIndex = 2;
            this.addPastStationButton.Text = "Добавить";
            this.addPastStationButton.Click += new System.EventHandler(this.addPastStationButton_Click);
            this.addPastStationButton.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addPastStationButton.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // StationMarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(850, 400);
            this.Controls.Add(this.addPastStationButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StationMarksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТЧ: Отметки о станциях";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StationMarksForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox;
        private Label cancelButton;
        private Label addPastStationButton;
        private Label addNewStation;
        private Label removeEntry;
        private Label tabTip;
    }
}