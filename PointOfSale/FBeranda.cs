using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FBeranda : Form
    {
        public FBeranda()
        {
            InitializeComponent();
        }

        private void FBeranda_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = KF.Nama;
        }
    }
}
