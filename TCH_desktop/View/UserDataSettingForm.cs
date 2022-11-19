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
    public partial class UserDataSettingForm : Form
    {
        StartForm startForm;

        public UserDataSettingForm(StartForm stForm)
        {
            InitializeComponent();
            startForm = stForm;

            this.Show();
        }
    }
}
