namespace TCH_desktop.View
{
    public partial class TripInfoForm : Form
    {
        private AllTripsForm allTripsForm;

        private bool isFinalForm;
        private bool isGrowingInWidth;
        private bool isGrowingInHeight;

        private System.Windows.Forms.Timer timer;


        public TripInfoForm(AllTripsForm allTripsForm)
        {
            InitializeComponent();

            this.Opacity = 80;
            this.allTripsForm = allTripsForm;

            this.Width = 0;
            this.Height = 0;

            isFinalForm = false;
            isGrowingInWidth = true;
            isGrowingInHeight = false;

            timer = new System.Windows.Forms.Timer { Interval = 10 };
            timer.Tick += TimerTick;
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            if (!isFinalForm)
            {
                if (isGrowingInWidth)
                {
                    this.Width += 13;
                    if (this.Width >= 1300)
                    {
                        isGrowingInWidth = false;
                        isGrowingInHeight = true;
                    }
                }
                
                if (isGrowingInHeight)
                {
                    this.Height += 8;
                    if (this.Height >= 800)
                        isFinalForm = true;
                }
            }
            else timer.Stop();
        }

        private void TripInfoForn_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
