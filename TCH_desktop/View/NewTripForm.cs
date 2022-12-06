using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCH_desktop.Presenter;

namespace TCH_desktop.View
{
    public partial class NewTripForm : Form
    {
        StartForm startForm;

        public NewTripForm(StartForm startForm)
        {
            InitializeComponent();

            this.startForm = startForm;
            Location = new Point(630, 120);

            backToStartForm.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);
            saveDataTrip.Font = Source.LoadFont(@".\source\fonts\zekton.ttf", 11, true);
        }

        private void backToStartForm_Click(object sender, EventArgs e)
        {
            startForm.TopMost = false;
            startForm.Opacity = 100;
            startForm.Enabled = true;
            this.Close();
        }

        #region Interactive

        private void backToStartForm_MouseEnter(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.Yellow;
        }

        private void backToStartForm_MouseLeave(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.DarkSeaGreen;
        }

        private void saveDataTrip_MouseEnter(object sender, EventArgs e)
        {
            saveDataTrip.ForeColor = Color.Yellow;
        }

        private void saveDataTrip_MouseLeave(object sender, EventArgs e)
        {
            saveDataTrip.ForeColor = Color.DarkSeaGreen;
        }

        #endregion
    }
}
