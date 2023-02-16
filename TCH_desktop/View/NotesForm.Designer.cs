namespace TCH_desktop.View
{
    partial class NotesForm
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
            this.notesTextBox = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Label();
            this.addNotes = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.notesTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Заметки в пути ";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.notesTextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.notesTextBox.Location = new System.Drawing.Point(10, 37);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(803, 298);
            this.notesTextBox.TabIndex = 0;
            this.notesTextBox.Text = "Используйте \';\' в качестве разделителя между отдельными записями";
            this.notesTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notesTextBox_MouseClick);
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
            // addNotes
            // 
            this.addNotes.AutoSize = true;
            this.addNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNotes.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addNotes.ForeColor = System.Drawing.Color.GreenYellow;
            this.addNotes.Location = new System.Drawing.Point(714, 362);
            this.addNotes.Name = "addNotes";
            this.addNotes.Size = new System.Drawing.Size(109, 22);
            this.addNotes.TabIndex = 2;
            this.addNotes.Text = "Добавить";
            this.addNotes.Click += new System.EventHandler(this.addNotes_Click);
            this.addNotes.MouseEnter += new System.EventHandler(this.labelMouseEnter);
            this.addNotes.MouseLeave += new System.EventHandler(this.labelMouseLeave);
            // 
            // NotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(850, 400);
            this.Controls.Add(this.addNotes);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТЧ: Заметки в пути";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label cancelButton;
        private Label addNotes;
        private RichTextBox notesTextBox;
    }
}