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
    public partial class DialogMenu : Form
    {
        public DialogMenu()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        String pathGambar = null;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            if (kondisi == "ubah")
            {
                if (pathGambar == null)
                {
                    DB.crud($"UPDATE tmenu SET Harga_Awal = '{txthargaawal.Text}', Harga_Jual = '{txthargajual.Text}', Nama = '{txtnama.Text}', Ket = '{txtket.Text}', Stok = '{txtstok.Text}', Status = '{cmbstatus.Text}' WHERE IDM = '{idm}'; ");
                } else
                {
                    DB.crud($"CALL UBAHMENU('{pathGambar}', '{txthargaawal.Text}', '{txthargajual.Text}', '{txtnama.Text}', '{txtket.Text}', '{txtstok.Text}', '{cmbstatus.Text}', '{idm}')");
                }
            }
            else
            {
                DB.crud($"CALL MASUKMENU('{pathGambar}', '{txthargaawal.Text}', '{txthargajual.Text}', '{txtnama.Text}', '{txtket.Text}', '{txtstok.Text}', '{cmbstatus.Text}')");
            }
            this.Close();
            pathGambar = null;
            KF.FMenu.tampilMenu();
        }

        public string kondisi = "baru";
        public string idm;

        private void cmbstatus_DropDown(object sender, EventArgs e)
        {
            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("Ada");
            cmbstatus.Items.Add("Tidak Ada");
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Pilih Gambar";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String path = ofd.FileName;
                guna2PictureBox1.Image = Image.FromFile(path);
                pathGambar = path.Replace(@"\", @"\\");
            }
        }
    }
}
