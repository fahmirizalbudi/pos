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
    public partial class FTransaksi : Form
    {
        public FTransaksi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] listGambar = { @"C:\Users\HP\Downloads\pngwing.com.png", @"C:\Users\HP\Downloads\pexels-andre-mouton-1207875.jpg" };

            for (int i = 0; i < listGambar.Length; i++)
            {
                UCMenu menu = new UCMenu();
                menu.Width = 430;
                menu.gambarnya(listGambar[i]);
                this.flowLayoutPanel1.Controls.Add(menu);
            }
            
        }
    }
}
