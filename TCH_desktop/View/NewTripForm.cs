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
            backToStartForm.BackColor = Color.DimGray;
        }

        private void backToStartForm_MouseLeave(object sender, EventArgs e)
        {
            backToStartForm.ForeColor = Color.YellowGreen;
            backToStartForm.BackColor = SystemColors.InfoText;
        }

        private void saveDataTrip_MouseEnter(object sender, EventArgs e)
        {
            saveDataTrip.ForeColor = Color.Yellow;
            saveDataTrip.BackColor = Color.DimGray;
        }

        private void saveDataTrip_MouseLeave(object sender, EventArgs e)
        {
            saveDataTrip.ForeColor = Color.YellowGreen;
            saveDataTrip.BackColor = SystemColors.InfoText;
        }

        #endregion

        private void addLocomotive_MouseEnter(object sender, EventArgs e)
        {
            addLocomotive.ForeColor = Color.Yellow;
            addLocomotive.BackColor = Color.DimGray;
        }

        private void addLocomotive_MouseLeave(object sender, EventArgs e)
        {
            addLocomotive.ForeColor = Color.YellowGreen;
            addLocomotive.BackColor = SystemColors.InfoText;
        }

        private void addPassedStations_MouseEnter(object sender, EventArgs e)
        {
            addPassedStations.ForeColor = Color.Yellow;
            addPassedStations.BackColor = Color.DimGray;
        }

        private void addPassedStations_MouseLeave(object sender, EventArgs e)
        {
            addPassedStations.ForeColor = Color.YellowGreen;
            addPassedStations.BackColor = SystemColors.InfoText;
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
    }
}
