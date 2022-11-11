using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCH_desktop.View
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.Text = "x";
            exitButton.ForeColor = Color.Red;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.Text = "o";
            exitButton.ForeColor = Color.Green;
        }
    }
}
