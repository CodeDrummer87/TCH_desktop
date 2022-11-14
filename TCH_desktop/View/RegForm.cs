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
    public partial class RegForm : Form
    {
        public RegForm(AuthForm authForm)
        {
            InitializeComponent();

            authForm.Hide();
            this.Show();
        }
    }
}
