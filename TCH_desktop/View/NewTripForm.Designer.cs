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
            this.backToStartForm = new System.Windows.Forms.Label();
            this.saveDataTrip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backToStartForm
            // 
            this.backToStartForm.AutoSize = true;
            this.backToStartForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToStartForm.Location = new System.Drawing.Point(23, 760);
            this.backToStartForm.Name = "backToStartForm";
            this.backToStartForm.Size = new System.Drawing.Size(199, 20);
            this.backToStartForm.TabIndex = 0;
            this.backToStartForm.Text = "Вернуться в Главное Меню";
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
            // NewTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.saveDataTrip);
            this.Controls.Add(this.backToStartForm);
            this.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewTripForm";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NewTripForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label backToStartForm;
        private Label saveDataTrip;
    }
}