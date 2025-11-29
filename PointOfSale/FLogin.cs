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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void FLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            DB.crud($"SELECT * FROM tkasir WHERE Username = '{txtuser.Text}' AND Password = '{txtpass.Text}'");
            int cekbaris = DB.ds.Tables[0].Rows.Count;

            if (cekbaris == 1)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];
                this.Hide();
                KF.IDK = baris["IDK"].ToString();
                KF.Nama = baris["Nama_Kasir"].ToString();
                KF.Form1.pembagianHak(baris["Hak"].ToString());
                KF.Form1.Show();
                KF.Form1.tampil();
            }
            else
            {
                guna2Panel4.Visible = true;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (txtpass.PasswordChar == '•')
            {
                txtpass.PasswordChar = default;
            }
            else
            {
                txtpass.PasswordChar = '•';
            }
        }
    }
}
