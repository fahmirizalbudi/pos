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
    public partial class DialogPelanggan : Form
    {
        public DialogPelanggan()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            if (kondisi == "ubah")
            {
                DB.crud($"UPDATE tpelanggan SET Nama_Pelanggan = '{txtnama.Text}', Alamat = '{txtalamat.Text}' WHERE IDP = '{idp}'");
            }
            else
            {
                DB.crud($"INSERT INTO tpelanggan SELECT null, '{txtnama.Text}', '{txtalamat.Text}'");
            }
            this.Close();
            KF.FPelanggan.tampilPelanggan();
        }

        public string kondisi = "baru";
        public string idp;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
