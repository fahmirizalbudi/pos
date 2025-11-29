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
    public partial class FKasir : Form
    {
        public FKasir()
        {
            InitializeComponent();
        }

        public void tampilKasir(string cari = null)
        {
            dataGridView1.Rows.Clear();
            DB.crud($"SELECT * FROM tkasir WHERE Nama_Kasir LIKE '%{cari}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idk = baris["IDK"].ToString();
                string nama = baris["Nama_Kasir"].ToString();
                nama = char.ToUpper(nama[0]) + nama.Substring(1).ToLower();
                string hak = baris["Hak"].ToString();
                dataGridView1.Rows.Add(idk, nama, hak);
            }
        }

        private void FKasir_Load(object sender, EventArgs e)
        {
            dataGridViewImageColumn4.DefaultCellStyle.Padding = new Padding(0, 0, 25, 0);
            Column5.DefaultCellStyle.Padding = new Padding(0, 0, 15, 0);
            tampilKasir();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            tampilKasir(txtsearch.Text);
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
            DialogTambah dt = new DialogTambah();
            dt.StartPosition = FormStartPosition.CenterParent;
            dt.ShowDialog(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx_baris = e.RowIndex;
            int idx_kolom = e.ColumnIndex;
            String idx_id = dataGridView1.Rows[idx_baris].Cells[0].Value.ToString();

            if (idx_kolom == 3)
            {
                DB.crud($"SELECT * FROM tkasir WHERE IDK = {idx_id}");
                DataRow baris = DB.ds.Tables[0].Rows[0];
                DialogTambah dt = new DialogTambah();
                dt.txtnama.Text = baris["Nama_Kasir"].ToString();
                dt.txtusername.Text = baris["Username"].ToString();
                dt.txtpassword.Text = baris["Password"].ToString();
                dt.cmbhak.Items.Add(baris["Hak"].ToString());
                dt.cmbhak.SelectedIndex = 0;
                dt.txttelepon.Text = baris["NO_TLP"].ToString();
                dt.kondisi = "ubah";
                dt.idk = baris["IDK"].ToString();
                dt.titel.Text = "Edit Kasir";
                dt.StartPosition = FormStartPosition.CenterParent;
                dt.ShowDialog(this);
            } else if (idx_kolom == 4)
            {
                DialogHapus dh = new DialogHapus();
                dh.tombolHapus += (s, ev) =>
                {
                    DB.crud($"DELETE FROM tkasir WHERE IDK = '{idx_id}'");
                    tampilKasir();
                };
                dh.StartPosition = FormStartPosition.CenterParent;
                dh.ShowDialog(this);
            }
        }
    }
}
