namespace TCH_desktop.View
{
    public partial class NotesForm : Form
    {
        private NewTripForm tripForm;

        public NotesForm(NewTripForm tripForm_)
        {
            InitializeComponent();
            this.tripForm = tripForm_;
        }

        private void ClearInputField()
        {
            if (notesTextBox.Text == "Используйте ';' в качестве разделителя между отдельными записями; " +
                "Для записей стоянок, укажите ключевое слово 'стоянки:' или 'остановки:' и в качестве " +
                "разделителя между временем остановки и временем отправления используйте \"||\" ")
                notesTextBox.Text = String.Empty;
        }

        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.notes = String.Empty;

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        private void labelMouseEnter(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.Yellow;
            label_.BackColor = Color.DimGray;
        }

        private void labelMouseLeave(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.YellowGreen;
            label_.BackColor = SystemColors.InfoText;
        }

        private void addNotes_Click(object sender, EventArgs e)
        {
            ClearInputField();
            tripForm.notes = notesTextBox.Text.Trim();

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        private void notesTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClearInputField();
            notesTextBox.ForeColor = SystemColors.WindowText;
            notesTextBox.Font = new("Lucida Console", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
        }

        #endregion
    }
}
