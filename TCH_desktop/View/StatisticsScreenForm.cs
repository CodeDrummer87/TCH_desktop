namespace TCH_desktop.View
{
    public partial class StatisticsScreenForm : Form
    {
        private StartForm startForm;

        public StatisticsScreenForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);
        }



        #region Interactive

        private void closeScreen_MouseEnter(object sender, EventArgs e)
        {
            closeScreen.ForeColor = Color.Yellow;
            closeScreen.BackColor = Color.DimGray;
        }

        private void closeScreen_MouseLeave(object sender, EventArgs e)
        {
            closeScreen.ForeColor = Color.YellowGreen;
            closeScreen.BackColor = SystemColors.InfoText;
        }

        private void closeScreen_Click(object sender, EventArgs e)
        {
            startForm.Enabled = true;
            this.Close();
        }

        #endregion
    }
}
