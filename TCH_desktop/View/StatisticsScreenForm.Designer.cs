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
            this.closeScreen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 716);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Экран Статистики ";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label closeScreen;
    }
}