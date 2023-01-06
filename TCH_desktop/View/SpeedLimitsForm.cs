namespace TCH_desktop.View
{
    public partial class SpeedLimitsForm : Form
    {
        private NewTripForm tripForm;

        public SpeedLimitsForm(NewTripForm tripForm_)
        {
            InitializeComponent();

            this.tripForm = tripForm_;
        }

        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.limits = String.Empty;
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

        private void addSpeedLimits_MouseEnter(object sender, EventArgs e)
        {
            addSpeedLimits.ForeColor = Color.Yellow;
            addSpeedLimits.BackColor = Color.DimGray;
        }

        private void addSpeedLimits_MouseLeave(object sender, EventArgs e)
        {
            addSpeedLimits.ForeColor = Color.YellowGreen;
            addSpeedLimits.BackColor = SystemColors.InfoText;
        }

        private void addSpeedLimits_Click(object sender, EventArgs e)
        {
            tripForm.limits = limitsTextBox.Text.Trim();

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        #endregion

    }
}
