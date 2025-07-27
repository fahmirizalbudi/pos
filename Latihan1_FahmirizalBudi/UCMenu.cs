using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan1_FahmirizalBudi
{
    public partial class UCMenu : UserControl
    {
        public UCMenu()
        {
            InitializeComponent();
        }

        public void gambarnya(string lokasi)
        {
            Image gambarawal = Image.FromFile(lokasi);
            Image UbahUkuran = KF.UbahGambarGambar(gambarawal, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = UbahUkuran;
        }

        private void UCMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
