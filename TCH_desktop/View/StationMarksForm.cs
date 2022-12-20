namespace TCH_desktop.View
{
    public partial class StationMarksForm : Form
    {
        NewTripForm tripForm;

        public StationMarksForm(NewTripForm tripForm_)
        {
            InitializeComponent();

            this.tripForm = tripForm_;
        }

        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
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
            cancelButton.ForeColor = Color.GreenYellow;
            cancelButton.BackColor = SystemColors.InfoText;
        }

        private void addPastStationButton_MouseEnter(object sender, EventArgs e)
        {
            addPastStationButton.ForeColor = Color.Yellow;
            addPastStationButton.BackColor = Color.DimGray;
        }

        private void addPastStationButton_MouseLeave(object sender, EventArgs e)
        {
            addPastStationButton.ForeColor = Color.GreenYellow;
            addPastStationButton.BackColor = SystemColors.InfoText;
        }

        #endregion
    }
}
