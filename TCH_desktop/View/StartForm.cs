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
    public partial class StartForm : Form
    {
        AuthForm authForm;

        public StartForm(AuthForm authForm)
        {
            InitializeComponent();

            this.authForm = authForm;
            this.Show();
            this.authForm.Hide();
        }
    }
}
