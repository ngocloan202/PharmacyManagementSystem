using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagement.View
{
    public partial class Flash : Form
    {
        public Flash()
        {
            InitializeComponent();
        }

        private void Flash_Load(object sender, EventArgs e)
        {
            timer.Interval = 3000;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}
