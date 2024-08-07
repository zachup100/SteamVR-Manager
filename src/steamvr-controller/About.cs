using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamvr_controller
{
    public partial class About : Form
    {

        public About()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("") { UseShellExecute = true });
        }
    }
}
