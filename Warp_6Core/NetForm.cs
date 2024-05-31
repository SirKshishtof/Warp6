using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warp_6;
using static System.Windows.Forms.DataFormats;

namespace Warp_6Core
{
    public partial class NetForm : Form
    {
        public NetForm()
        {
            InitializeComponent();
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
