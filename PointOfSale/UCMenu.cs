using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PointOfSale
{
    public partial class UCMenu : UserControl
    {
        public UCMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public void gambarnya(MemoryStream ms)
        {
            Image gambarawal = Image.FromStream(ms);
            Image UbahUkuran = KF.UbahGambarGambar(gambarawal, GambarMenu.Width, GambarMenu.Height);
            GambarMenu.Image = UbahUkuran;
        }

        private void UCMenu_Load(object sender, EventArgs e)
        {
            KF.untukRounded(this, 20, 20, 20, 20);
        }

        private void KurangQty_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(LabelQty.Text);
            if (qty == 1)
            {
                LabelQty.Text = "1";
            }
            else
            {
                LabelQty.Text = "" + (qty - 1);
            }
        }

        private void TambahQty_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(LabelQty.Text);
            LabelQty.Text = "" + (qty + 1);
        }

        public event EventHandler<(string ID, string Nama, int Qty, Image Gambar, string Harga)> tombolTambah;

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string id = this.Name;
            string nama = this.LabelNama.Text;
            int qty = Convert.ToInt32(this.LabelQty.Text);
            Image gambar = GambarMenu.Image;
            string harga = LabelHarga.Text;
            tombolTambah?.Invoke(this, (id, nama, qty, gambar, harga));
            LabelQty.Text = "1";
        }

        private void LabelTambahQty_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(LabelQty.Text);
            DB.crud($"SELECT stok FROM tmenu WHERE IDM = '{this.Name}'");
            int stok = Convert.ToInt32(DB.ds.Tables[0].Rows[0]["stok"]);
            if (stok <= qty)
            {
                return;
            }
            LabelQty.Text = "" + (qty + 1);
        }

        private void LabelKurangQty_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(LabelQty.Text);
            if (qty == 1)
            {
                LabelQty.Text = "1";
            }
            else
            {
                LabelQty.Text = "" + (qty - 1);
            }
        }
    }
}
