namespace TCH_desktop.View
{
    partial class LocomotivAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocomotivAddForm));
            this.cancelButton = new System.Windows.Forms.Label();
            this.addNewLocoButton = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.brakeHoldersValue = new System.Windows.Forms.Label();
            this.labl = new System.Windows.Forms.Label();
            this.brakeHoldersTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.allocationSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.locoNumberInp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.locoSeriesSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.locoTypeSelect = new System.Windows.Forms.ComboBox();
            this.locoImageBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brakeHoldersTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locoImageBox)).BeginInit();
            this.SuspendLayout();
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
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.MouseEnter += new System.EventHandler(this.cancelButton_MouseEnter);
            this.cancelButton.MouseLeave += new System.EventHandler(this.cancelButton_MouseLeave);
            // 
            // addNewLocoButton
            // 
            this.addNewLocoButton.AutoSize = true;
            this.addNewLocoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNewLocoButton.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addNewLocoButton.ForeColor = System.Drawing.Color.GreenYellow;
            this.addNewLocoButton.Location = new System.Drawing.Point(714, 362);
            this.addNewLocoButton.Name = "addNewLocoButton";
            this.addNewLocoButton.Size = new System.Drawing.Size(109, 22);
            this.addNewLocoButton.TabIndex = 1;
            this.addNewLocoButton.Text = "Добавить";
            this.addNewLocoButton.Click += new System.EventHandler(this.addNewLocoButton_Click);
            this.addNewLocoButton.MouseEnter += new System.EventHandler(this.addNewLocoButton_MouseEnter);
            this.addNewLocoButton.MouseLeave += new System.EventHandler(this.addNewLocoButton_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brakeHoldersValue);
            this.groupBox1.Controls.Add(this.labl);
            this.groupBox1.Controls.Add(this.brakeHoldersTrackBar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.allocationSelect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.locoNumberInp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.locoSeriesSelect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.locoTypeSelect);
            this.groupBox1.Controls.Add(this.locoImageBox);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 347);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить Локомотив к текущей поездке";
            // 
            // brakeHoldersValue
            // 
            this.brakeHoldersValue.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.brakeHoldersValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brakeHoldersValue.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brakeHoldersValue.Location = new System.Drawing.Point(320, 276);
            this.brakeHoldersValue.Name = "brakeHoldersValue";
            this.brakeHoldersValue.Size = new System.Drawing.Size(57, 56);
            this.brakeHoldersValue.TabIndex = 11;
            this.brakeHoldersValue.Text = "4";
            this.brakeHoldersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labl
            // 
            this.labl.AutoSize = true;
            this.labl.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labl.ForeColor = System.Drawing.Color.GreenYellow;
            this.labl.Location = new System.Drawing.Point(33, 251);
            this.labl.Name = "labl";
            this.labl.Size = new System.Drawing.Size(310, 22);
            this.labl.TabIndex = 10;
            this.labl.Text = "Количество Тормозных Башмаков:";
            // 
            // brakeHoldersTrackBar
            // 
            this.brakeHoldersTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brakeHoldersTrackBar.Location = new System.Drawing.Point(30, 276);
            this.brakeHoldersTrackBar.Maximum = 20;
            this.brakeHoldersTrackBar.Minimum = 2;
            this.brakeHoldersTrackBar.Name = "brakeHoldersTrackBar";
            this.brakeHoldersTrackBar.Size = new System.Drawing.Size(284, 56);
            this.brakeHoldersTrackBar.TabIndex = 9;
            this.brakeHoldersTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.brakeHoldersTrackBar.Value = 4;
            this.brakeHoldersTrackBar.Scroll += new System.EventHandler(this.brakeHoldersTrackBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.GreenYellow;
            this.label4.Location = new System.Drawing.Point(30, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Депо приписки:";
            // 
            // allocationSelect
            // 
            this.allocationSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.allocationSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allocationSelect.FormattingEnabled = true;
            this.allocationSelect.Location = new System.Drawing.Point(33, 210);
            this.allocationSelect.Name = "allocationSelect";
            this.allocationSelect.Size = new System.Drawing.Size(345, 25);
            this.allocationSelect.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(220, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Номер:";
            // 
            // locoNumberInp
            // 
            this.locoNumberInp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locoNumberInp.Location = new System.Drawing.Point(220, 142);
            this.locoNumberInp.Name = "locoNumberInp";
            this.locoNumberInp.Size = new System.Drawing.Size(157, 24);
            this.locoNumberInp.TabIndex = 5;
            this.locoNumberInp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.GreenYellow;
            this.label2.Location = new System.Drawing.Point(30, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Серия:";
            // 
            // locoSeriesSelect
            // 
            this.locoSeriesSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locoSeriesSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locoSeriesSelect.FormattingEnabled = true;
            this.locoSeriesSelect.Location = new System.Drawing.Point(30, 141);
            this.locoSeriesSelect.Name = "locoSeriesSelect";
            this.locoSeriesSelect.Size = new System.Drawing.Size(168, 25);
            this.locoSeriesSelect.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип локомотива: ";
            // 
            // locoTypeSelect
            // 
            this.locoTypeSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locoTypeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locoTypeSelect.FormattingEnabled = true;
            this.locoTypeSelect.Location = new System.Drawing.Point(30, 74);
            this.locoTypeSelect.Name = "locoTypeSelect";
            this.locoTypeSelect.Size = new System.Drawing.Size(347, 25);
            this.locoTypeSelect.TabIndex = 1;
            this.locoTypeSelect.SelectedIndexChanged += new System.EventHandler(this.locoTypeSelect_SelectedIndexChanged);
            // 
            // locoImageBox
            // 
            this.locoImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.locoImageBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locoImageBox.Image = global::TCH_desktop.Properties.Resources.addLocoImg;
            this.locoImageBox.Location = new System.Drawing.Point(423, 40);
            this.locoImageBox.Name = "locoImageBox";
            this.locoImageBox.Size = new System.Drawing.Size(368, 275);
            this.locoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.locoImageBox.TabIndex = 0;
            this.locoImageBox.TabStop = false;
            this.locoImageBox.Click += new System.EventHandler(this.locoImageBox_Click);
            // 
            // LocomotivAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(850, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addNewLocoButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocomotivAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТЧ: Добавить Локомотив";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LocomotivAddForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brakeHoldersTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locoImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label cancelButton;
        private Label addNewLocoButton;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox locoTypeSelect;
        private PictureBox locoImageBox;
        private Label label3;
        private TextBox locoNumberInp;
        private Label label2;
        private ComboBox locoSeriesSelect;
        private Label label4;
        private ComboBox allocationSelect;
        private TrackBar brakeHoldersTrackBar;
        private Label labl;
        private Label brakeHoldersValue;
    }
}