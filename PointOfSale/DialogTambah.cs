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
    public partial class DialogTambah : Form
    {
        public DialogTambah()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            if (kondisi == "ubah")
            {
                DB.crud($"UPDATE tkasir SET Nama_Kasir = '{txtnama.Text}', Username = '{txtusername.Text}', Password = '{txtpassword.Text}', Hak = '{cmbhak.Text}', NO_TLP = '{txttelepon.Text}' WHERE IDK = '{idk}'");
            }
            else
            {
                DB.crud($"INSERT INTO tkasir SELECT null, '{txtnama.Text}', '{txtusername.Text}', '{txtpassword.Text}', '{cmbhak.Text}', '{txttelepon.Text}'");
            }
            this.Close();
            KF.FKasir.tampilKasir();
        }

        public string kondisi = "baru";
        public string idk;

        private void cmbhak_DropDown(object sender, EventArgs e)
        {
            cmbhak.Items.Clear();
            cmbhak.Items.Add("Kasir");
            cmbhak.Items.Add("Admin");
        }

        private void DialogTambah_Load(object sender, EventArgs e)
        {
        }
    }
}
