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
            this.tripsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backToStartForm = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tripsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tripsTable);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 716);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Все поездки ";
            // 
            // tripsTable
            // 
            this.tripsTable.ColumnCount = 5;
            this.tripsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.92593F));
            this.tripsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.07407F));
            this.tripsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tripsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tripsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tripsTable.Controls.Add(this.label1, 0, 0);
            this.tripsTable.Controls.Add(this.label2, 1, 0);
            this.tripsTable.Controls.Add(this.label3, 2, 0);
            this.tripsTable.Controls.Add(this.label4, 3, 0);
            this.tripsTable.Controls.Add(this.label5, 4, 0);
            this.tripsTable.ForeColor = System.Drawing.Color.Wheat;
            this.tripsTable.Location = new System.Drawing.Point(22, 100);
            this.tripsTable.Name = "tripsTable";
            this.tripsTable.RowCount = 1;
            this.tripsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.8F));
            this.tripsTable.Size = new System.Drawing.Size(832, 40);
            this.tripsTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Явка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(106, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Маршрут";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(401, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Номер поезда";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(559, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "Масса поезда";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(703, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 40);
            this.label5.TabIndex = 4;
            this.label5.Text = "Локомотив";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox1.ResumeLayout(false);
            this.tripsTable.ResumeLayout(false);
            this.tripsTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label backToStartForm;
        private TableLayoutPanel tripsTable;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}