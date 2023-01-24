namespace TCH_desktop.View
{
    public partial class PhotoSliderForm : Form
    {
        private TripInfoForm tripInfoForm;

        private int currentIndex;
        private string[] files;

        public PhotoSliderForm(TripInfoForm tripInfoForm, string directoryPath)
        {
            InitializeComponent();

            this.tripInfoForm = tripInfoForm;

            currentIndex = 0;
            if (Directory.Exists(directoryPath))
                files = Directory.GetFiles(directoryPath);

            mainSpace.ImageLocation = files[0];
        }

        private int GetIndex(int index) => 
            index > files.Count() - 1 ? 0 : index < 0 ? files.Count() - 1 : index;


        #region Interactive

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_hover;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            tripInfoForm.Enabled = true;
            tripInfoForm.Opacity = 85;
            Close();
            Dispose();
        }

        private void arrowRight_MouseEnter(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right_hover;
        }

        private void arrowRight_MouseLeave(object sender, EventArgs e)
        {
            arrowRight.Image = Properties.Resources.side_right;
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            currentIndex = GetIndex(++currentIndex);
            mainSpace.ImageLocation = files[currentIndex];
        }

        private void arrowLeft_MouseEnter(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left_hover;
        }

        private void arrowLeft_MouseLeave(object sender, EventArgs e)
        {
            arrowLeft.Image = Properties.Resources.side_left;
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            currentIndex = GetIndex(--currentIndex);
            mainSpace.ImageLocation = files[currentIndex];
        }

        private void addButton_MouseEnter(object sender, EventArgs e)
        {
            addButton.Image = Properties.Resources.add_hover;
        }

        private void addButton_MouseLeave(object sender, EventArgs e)
        {
            addButton.Image = Properties.Resources.add;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_MouseEnter(object sender, EventArgs e)
        {
            removeButton.Image = Properties.Resources.remove_hover;
        }

        private void removeButton_MouseLeave(object sender, EventArgs e)
        {
            removeButton.Image = Properties.Resources.remove;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
