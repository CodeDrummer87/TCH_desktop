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


        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.notes = String.Empty;

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            cancelButton.ForeColor = Color.Yellow;
            cancelButton.BackColor = Color.DimGray;
        }

        private void cancelButton_MouseLeave(object sender, EventArgs e)
        {
            cancelButton.ForeColor = Color.YellowGreen;
            cancelButton.BackColor = SystemColors.InfoText;
        }

        private void addNotes_MouseEnter(object sender, EventArgs e)
        {
            addNotes.ForeColor = Color.Yellow;
            addNotes.BackColor = Color.DimGray;
        }

        private void addNotes_MouseLeave(object sender, EventArgs e)
        {
            addNotes.ForeColor = Color.YellowGreen;
            addNotes.BackColor = SystemColors.InfoText;
        }

        private void addNotes_Click(object sender, EventArgs e)
        {
            tripForm.notes = notesTextBox.Text.Trim();

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        #endregion

    }
}
