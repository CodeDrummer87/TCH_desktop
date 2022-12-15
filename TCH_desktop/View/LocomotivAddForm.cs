namespace TCH_desktop.View
{
    public partial class LocomotivAddForm : Form
    {
        private NewTripForm tripForm;

        public LocomotivAddForm(NewTripForm tripForm)
        {
            InitializeComponent();

            this.tripForm = tripForm;
        }


        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.Enabled = true;
            Close();
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

        private void addNewLocoButton_MouseEnter(object sender, EventArgs e)
        {
            addNewLocoButton.ForeColor = Color.Yellow;
            addNewLocoButton.BackColor = Color.DimGray;
        }

        private void addNewLocoButton_MouseLeave(object sender, EventArgs e)
        {
            addNewLocoButton.ForeColor = Color.YellowGreen;
            addNewLocoButton.BackColor = SystemColors.InfoText;
        }

        #endregion

    }
}
