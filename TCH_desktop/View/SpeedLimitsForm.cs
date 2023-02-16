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

        private void ClearInputField()
        {
            if (limitsTextBox.Text == "Используйте ';' в качестве разделителя между отдельными записями")
                limitsTextBox.Text = String.Empty;
        }

        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.limits = String.Empty;
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

        private void addSpeedLimits_Click(object sender, EventArgs e)
        {
            ClearInputField();
            tripForm.limits = limitsTextBox.Text.Trim();

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        private void limitsTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ClearInputField();
            limitsTextBox.ForeColor = SystemColors.WindowText;
            limitsTextBox.Font = new("Lucida Console", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
        }

        #endregion
    }
}
