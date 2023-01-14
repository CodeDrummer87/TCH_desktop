namespace TCH_desktop.View
{
    public partial class AllTripsForm : Form
    {
        private StartForm startForm;

        public AllTripsForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);
        }



        #region Interactive

        private void AllTripsForm_Load(object sender, EventArgs e)
        {

        }

        private void backToStartForm_Click(object sender, EventArgs e)
        {
            startForm.Enabled = true;
            this.Close();
        }

        private void backToStartForm_MouseEnter(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.Yellow;
            backToStartForm.BackColor = Color.DimGray;
        }

        private void backToStartForm_MouseLeave(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.GreenYellow;
            backToStartForm.BackColor = SystemColors.InfoText;
        }

        #endregion
    }
}
