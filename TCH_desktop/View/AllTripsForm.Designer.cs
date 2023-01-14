namespace TCH_desktop.View
{
    partial class AllTripsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllTripsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backToStartForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 716);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Все поездки ";
            // 
            // backToStartForm
            // 
            this.backToStartForm.AutoSize = true;
            this.backToStartForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToStartForm.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backToStartForm.Location = new System.Drawing.Point(23, 760);
            this.backToStartForm.Name = "backToStartForm";
            this.backToStartForm.Size = new System.Drawing.Size(177, 22);
            this.backToStartForm.TabIndex = 1;
            this.backToStartForm.Text = "В главное меню";
            this.backToStartForm.Click += new System.EventHandler(this.backToStartForm_Click);
            this.backToStartForm.MouseEnter += new System.EventHandler(this.backToStartForm_MouseEnter);
            this.backToStartForm.MouseLeave += new System.EventHandler(this.backToStartForm_MouseLeave);
            // 
            // AllTripsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.backToStartForm);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.GreenYellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllTripsForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ТЧ: Все поездки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AllTripsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label backToStartForm;
    }
}