using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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

            title.Text = "ТЧЭ-2\nЗСЖД";
            title.Font = LoadFont(@".\source\fonts\docker.ttf", 50, true);
            developerEmail.Font = LoadFont(@".\source\fonts\zekton.ttf", 11, true);
            loginInp.Font = pswdInp.Font = LoadFont(@".\source\fonts\zekton.ttf", 12, true);
            authButton.Font = LoadFont(@".\source\fonts\zekton.ttf", 10, true);
        }

        private void exitButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void exitButton_MouseEnter(object? sender, EventArgs e)
        {
            exitButton.Text = "x";
            exitButton.ForeColor = Color.Red;
        }

        private void exitButton_MouseLeave(object? sender, EventArgs e)
        {
            exitButton.Text = "o";
            exitButton.ForeColor = Color.Green;
        }
    
        private Font LoadFont(string path, int size, bool isBold)
        {
            PrivateFontCollection customFont = new ();
            customFont.AddFontFile(@path);

            return new Font(customFont.Families[0], size, isBold? FontStyle.Bold : FontStyle.Regular);
        }

        private void authButton_MouseEnter(object? sender, EventArgs e)
        {
            authButton.BackColor = Color.LightSkyBlue;
        }

        private void authButton_MouseLeave(object sender, EventArgs e)
        {
            authButton.BackColor = Color.LightBlue;
        }
    }
}
