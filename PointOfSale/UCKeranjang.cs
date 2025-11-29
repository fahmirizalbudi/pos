using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class UCKeranjang : UserControl
    {
        public UCKeranjang()
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

        public event EventHandler<(String Name, int Qty)> tombolHapus;

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            tombolHapus?.Invoke(this, (this.Name, Convert.ToInt32(this.LabelQty.Text)));
            this.Parent.Controls.Remove(this);
            //KF.FTransaksi.tampilKeranjang("1");
        }

        private void LabelQty_TextChanged(object sender, EventArgs e)
        {
            
        }

        public int harganya;

        public event EventHandler<(string kondisi, int harga)> btnUbah;

        private void LabelTambahQty_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(LabelQty.Text);
            DB.crud($"SELECT stok FROM tkeranjang INNER JOIN tmenu ON tmenu.IDM = tkeranjang.IDM WHERE ID_Keranjang = '{this.Name}'");
            int stok = Convert.ToInt32(DB.ds.Tables[0].Rows[0]["stok"]);
            if (stok <= qty)
            {
                return;
            }
            DB.crud($"UPDATE tkeranjang SET QTY = QTY + 1, Subtotal = (Harga_Jual * QTY) WHERE ID_Keranjang = {this.Name}");
            LabelQty.Text = "" + (qty + 1);
            btnUbah?.Invoke(this, ("tambah", Convert.ToInt32(label1.Text)));
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
                DB.crud($"UPDATE tkeranjang SET QTY = QTY - 1, Subtotal = (Harga_Jual * QTY) WHERE ID_Keranjang = {this.Name}");
                LabelQty.Text = "" + (qty - 1);
                btnUbah?.Invoke(this, ("kurang", Convert.ToInt32(label1.Text)));
            }
        }
    }
}
