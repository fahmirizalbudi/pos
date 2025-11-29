using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 120;
        }

        public void tampilMenu(string cari = null)
        {
            dataGridView1.Rows.Clear();
            DB.crud($"SELECT * FROM tmenu WHERE Nama LIKE '%{cari}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idm = baris["IDM"].ToString();
                Image pict;
                try
                {
                    MemoryStream ms = new MemoryStream((byte[])baris["Pict"]);
                    pict = KF.UbahGambarGambar(Image.FromStream(ms), 100, 100);
                }
                catch (Exception)
                {
                    pict = null;
                    
                }
                string nama = baris["Nama"].ToString();
                string harga_awal = baris["Harga_Awal"].ToString();
                string harga_jual = baris["Harga_Jual"].ToString();
                string stok = baris["Stok"].ToString();
                dataGridView1.Rows.Add(idm, pict, nama, harga_awal, harga_jual, stok);
            }
        }

        private void FMenu_Load(object sender, EventArgs e)
        {
            dataGridViewImageColumn4.DefaultCellStyle.Padding = new Padding(0, 0, 25, 0);
            Column5.DefaultCellStyle.Padding = new Padding(0, 0, 15, 0);
            Column12.DefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            tampilMenu();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogMenu dm = new DialogMenu();
            dm.StartPosition = FormStartPosition.CenterParent;
            dm.ShowDialog(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx_baris = e.RowIndex;
            int idx_kolom = e.ColumnIndex;
            String idx_id = dataGridView1.Rows[idx_baris].Cells[0].Value.ToString();

            if (idx_kolom == 6)
            {
                DB.crud($"SELECT * FROM tmenu WHERE IDM = {idx_id}");
                DataRow baris = DB.ds.Tables[0].Rows[0];
                DialogMenu dm = new DialogMenu();
                dm.txtnama.Text = baris["Nama"].ToString();
                dm.txthargaawal.Text = baris["Harga_Awal"].ToString();
                dm.txthargajual.Text = baris["Harga_Jual"].ToString();
                dm.txtket.Text = baris["Ket"].ToString();
                dm.txtstok.Text = baris["Stok"].ToString();
                dm.cmbstatus.Items.Clear();
                dm.cmbstatus.Items.Add(baris["Status"].ToString());
                dm.cmbstatus.SelectedIndex = 0;
                dm.kondisi = "ubah";
                dm.idm = baris["IDM"].ToString();
                try
                {
                    dm.guna2PictureBox1.Image = Image.FromStream(new MemoryStream((byte[])baris["Pict"]));
                }
                catch (Exception)
                {
                    dm.guna2PictureBox1.Image = dm.guna2PictureBox1.Image;
                }
                dm.titel.Text = "Edit Menu";
                dm.StartPosition = FormStartPosition.CenterParent;
                dm.ShowDialog(this);
            }
            else if (idx_kolom == 7)
            {
                DialogHapus dh = new DialogHapus();
                dh.tombolHapus += (s, ev) =>
                {
                    DB.crud($"DELETE FROM tmenu WHERE IDM = '{idx_id}'");
                    tampilMenu();
                };
                dh.StartPosition = FormStartPosition.CenterParent;
                dh.ShowDialog(this);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            tampilMenu(txtsearch.Text);
        }
    }
}
