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
    public partial class DialogHapus : Form
    {
        public DialogHapus()
        {
            InitializeComponent();
        }

        public event EventHandler tombolHapus;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tombolHapus?.Invoke(this, null);
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
