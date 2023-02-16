namespace TCH_desktop.View
{
    partial class SpeedLimitsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limitsTextBox = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Label();
            this.addSpeedLimits = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limitsTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ДУ-61: Ограничения и Предупреждения ";
            // 
            // limitsTextBox
            // 
            this.limitsTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.limitsTextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.limitsTextBox.Location = new System.Drawing.Point(10, 37);
            this.limitsTextBox.Name = "limitsTextBox";
            this.limitsTextBox.Size = new System.Drawing.Size(803, 298);
            this.limitsTextBox.TabIndex = 0;
            this.limitsTextBox.Text = "Используйте \';\' в качестве разделителя между отдельными записями";
            this.limitsTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.limitsTextBox_MouseClick);
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
            // addSpeedLimits
            // 
            this.addSpeedLimits.AutoSize = true;
            this.addSpeedLimits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addSpeedLimits.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addSpeedLimits.ForeColor = System.Drawing.Color.GreenYellow;
            this.addSpeedLimits.Location = new System.Drawing.Point(714, 362);
            this.addSpeedLimits.Name = "addSpeedLimits";
            this.addSpeedLimits.Size = new System.Drawing.Size(109, 22);
            this.addSpeedLimits.TabIndex = 2;
            this.addSpeedLimits.Text = "Добавить";
            this.addSpeedLimits.Click += new System.EventHandler(this.addSpeedLimits_Click);
            this.addSpeedLimits.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addSpeedLimits.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // SpeedLimitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(850, 400);
            this.Controls.Add(this.addSpeedLimits);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpeedLimitsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТЧ: Выписки из ДУ-61";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label cancelButton;
        private Label addSpeedLimits;
        private RichTextBox limitsTextBox;
    }
}