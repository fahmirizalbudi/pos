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
    public partial class FPelanggan : Form
    {
        public FPelanggan()
        {
            InitializeComponent();
        }

        public void tampilPelanggan(string cari = null)
        {
            dataGridView1.Rows.Clear();
            DB.crud($"SELECT * FROM tpelanggan WHERE Nama_Pelanggan LIKE '%{cari}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idk = baris["IDP"].ToString();
                string nama = baris["Nama_Pelanggan"].ToString();
                string alamat = baris["Alamat"].ToString();
                dataGridView1.Rows.Add(idk, nama, alamat);
            }
        }

        private void FPelanggan_Load(object sender, EventArgs e)
        {
            dataGridViewImageColumn4.DefaultCellStyle.Padding = new Padding(0, 0, 25, 0);
            Column5.DefaultCellStyle.Padding = new Padding(0, 0, 15, 0);
            tampilPelanggan();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            KF.untukRounded(dataGridView1, 20, 20, 20, 20);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(
                    e.Value?.ToString(),
                    e.CellStyle.Font,
                    new SolidBrush(Color.FromArgb(255, 87, 87, 87)),
                    e.CellBounds,
                    sf
                );

                e.Handled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogPelanggan dp = new DialogPelanggan();
            dp.StartPosition = FormStartPosition.CenterParent;
            dp.ShowDialog(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx_baris = e.RowIndex;
            int idx_kolom = e.ColumnIndex;
            String idx_id = dataGridView1.Rows[idx_baris].Cells[0].Value.ToString();

            if (idx_kolom == 3)
            {
                DB.crud($"SELECT * FROM tpelanggan WHERE IDP = {idx_id}");
                DataRow baris = DB.ds.Tables[0].Rows[0];
                DialogPelanggan dp = new DialogPelanggan();
                dp.txtnama.Text = baris["Nama_Pelanggan"].ToString();
                dp.txtalamat.Text = baris["Alamat"].ToString();
                dp.kondisi = "ubah";
                dp.idp = baris["IDP"].ToString();
                dp.titel.Text = "Edit Pelanggan";
                dp.StartPosition = FormStartPosition.CenterParent;
                dp.ShowDialog(this);
            }
            else if (idx_kolom == 4)
            {
                DialogHapus dh = new DialogHapus();
                dh.tombolHapus += (s, ev) =>
                {
                    DB.crud($"DELETE FROM tpelanggan WHERE IDP = '{idx_id}'");
                    tampilPelanggan();
                };
                dh.StartPosition = FormStartPosition.CenterParent;
                dh.ShowDialog(this);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            tampilPelanggan(txtsearch.Text);
        }
    }
}
