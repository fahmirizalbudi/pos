using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel3.Visible = false;
            this.DoubleBuffered = true;
            typeof(Control)
            .GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(flowLayoutPanel1, true, null);
            typeof(Control)
            .GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(flowLayoutPanel2, true, null);
            typeof(Control)
            .GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(flowLayoutPanel3, true, null);
        }

        public void pembagianHak(String hak)
        {
            guna2Button2.Visible = hak.ToLower() == "admin" || hak.ToLower() == "petugas" ? true : false; // Data
            guna2Button7.Visible = hak.ToLower() == "admin" || hak.ToLower() == "kasir" ? true : false; // Transaksi
            guna2Button10.Visible = true; //hak.ToLower() == "admin" ? true : false; // Laporan (semua)
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void tampil()
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel3.Visible = false;
            guna2Button1.Checked = true;
            KF.untukform(KF.FBeranda, panelKonten);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            KF.untukform(KF.FTransaksi, panelKonten);
            KF.FTransaksi.tampilKeranjang(KF.IDK);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            KF.untukform(KF.FKasir, panelKonten);
            KF.FKasir.tampilKasir();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            KF.untukform(KF.FPelanggan, panelKonten);
            KF.FPelanggan.tampilPelanggan();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            KF.untukform(KF.FMenu, panelKonten);
            KF.FMenu.tampilMenu();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Yakin ingin Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                FLogin login = new FLogin();
                login.Show();
            }
        }

        public void buka(Guna.UI2.AnimatorNS.Animator transition, Control control)
        {
            control.Visible = false;
            transition.Show(control);
            control.Visible = true;
        }

        public void tutup(Guna.UI2.AnimatorNS.Animator transition, Control control)
        {
            control.Visible = true;
            transition.Hide(control);
            control.Visible = false;
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Visible)
            {
                tutup(guna2Transition1, flowLayoutPanel1);
            }
            else
            {
                buka(guna2Transition1, flowLayoutPanel1);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Visible)
            {
                tutup(guna2Transition2, flowLayoutPanel2);
            }
            else
            {
                buka(guna2Transition2, flowLayoutPanel2);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel3.Visible)
            {
                tutup(guna2Transition3, flowLayoutPanel3);
            }
            else
            {
                buka(guna2Transition3, flowLayoutPanel3);
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            KF.untukform(KF.FLapKasir, panelKonten);
            KF.FMenu.tampilMenu();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            KF.untukform(KF.FLapJual, panelKonten);
            KF.FMenu.tampilMenu();
        }
    }
}
