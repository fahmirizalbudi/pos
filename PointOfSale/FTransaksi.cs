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
using System.Runtime.InteropServices;

namespace PointOfSale
{
    public partial class FTransaksi : Form
    {
        public FTransaksi()
        {
            InitializeComponent();

        }


        private void BtnAllItems_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik Makanan!");
            //PanelListMenu.Controls.Clear();
            //for (int i = 1; i < 30; i++)
            //{
            //    UCMenu uc = new UCMenu();
            //    uc.Width = (int)(PanelListMenu.Width / 3) - 20;
            //    if (i % 3 == 0)
            //    {
            //        uc.Margin = new Padding(0, 0, 0, 20);
            //    } else
            //    {
            //        uc.Margin = new Padding(0, 0, 20, 20);
            //    }
            //    this.PanelListMenu.Controls.Add(uc);
            //}
        }

        private void FTransaksi_Load(object sender, EventArgs e)
        {
            string tanggal = DateTime.Now.ToString("dddd, dd MMM yyyy");
            labelTanggal.Text = tanggal;
            label4.Text = "Welcome " + KF.Nama;
        }

        public void tampilKeranjang(string idk)
        {
            PanelOrder.Controls.Clear();
            DB.crud($"SELECT tkeranjang.ID_keranjang, tmenu.Nama, tmenu.Harga_Jual, CONCAT('Rp', FORMAT(tmenu.Harga_Jual, 0)) as Harga_Jual_Format,tmenu.Pict, tkeranjang.QTY, tkeranjang.Subtotal, (SELECT SUM(tkeranjang.Subtotal) FROM tkeranjang WHERE tkeranjang.IDK = '{idk}') AS Total FROM tkeranjang INNER JOIN tmenu ON tkeranjang.IDM = tmenu.IDM WHERE tkeranjang.IDK = '{idk}';");
            PanelOrder.SuspendLayout();
            foreach (DataRow krj in DB.ds.Tables[0].Rows)
            {
                UCKeranjang kr = new UCKeranjang();
                try
                {
                    kr.gambarnya(new MemoryStream((byte[])krj["Pict"]));
                }
                catch (Exception)
                {
                    kr.GambarMenu.Image = kr.GambarMenu.Image;
                }
                kr.LabelNama.Text = "" + krj["Nama"];
                kr.label1.Text = "" + krj["Harga_Jual"];
                kr.LabelQty.Text = "" + krj["QTY"];
                kr.Width = kr.Width - 1;
                kr.Name = "" + krj["ID_Keranjang"];
                kr.tombolHapus += (sd, keranjangnya) =>
                {
                    int subtotal = Convert.ToInt32(krj["Harga_Jual"]) * (keranjangnya.Qty);
                    DB.crud($"DELETE FROM tkeranjang WHERE ID_Keranjang = '{keranjangnya.Name}'");
                    LabelTotal.Text = (Convert.ToInt32(LabelTotal.Text) - subtotal).ToString();
                };
                PanelOrder.Controls.Add(kr);
                LabelTotal.Text = krj["Total"].ToString();
            }
            PanelOrder.ResumeLayout();
        }

        private void BtnMakanan_Click(object sender, EventArgs e)
        {
            PanelListMenu.Controls.Clear();
            PanelListMenu.SuspendLayout();
            DB.crud("SELECT *, CONCAT('Rp', FORMAT(Harga_Jual, 0)) as Harga_Jual_Format FROM tmenu");
            int i = 0;
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                i += 1;
                UCMenu uc = new UCMenu();
                uc.LabelNama.Text = "" + baris["Nama"];
                uc.LabelDeskripsi.Text = "" + baris["Ket"];
                uc.LabelStatus.Text = "" + baris["Status"] == "Ada" ? "Available" : "Unavailable";
                uc.LabelHarga.Text = "" + baris["Harga_Jual_Format"];
                uc.Name = "" + baris["IDM"];
                try
                {
                    byte[] datagambar = (byte[])baris["Pict"];
                    MemoryStream ms = new MemoryStream(datagambar);
                    uc.gambarnya(ms);
                }
                catch (Exception)
                {
                    uc.GambarMenu.Image = uc.GambarMenu.Image;
                }

                uc.tombolTambah += (s, data) =>
                {
                    PanelOrder.Controls.Clear();
                    DB.crud($"SELECT Stok FROM tmenu WHERE IDM = {data.ID}");
                    if ((int)DB.ds.Tables[0].Rows[0]["Stok"] == 0)
                    {
                        MessageBox.Show("Stok Menu 0");
                        return;
                    }
                    DB.crud($"SELECT COUNT(*) as juml FROM tkeranjang WHERE IDM = {data.ID} AND IDK = '{1}'");
                    if (Convert.ToInt32(DB.ds.Tables[0].Rows[0]["juml"]) > 0)
                    {
                        DB.crud($"DELETE FROM tkeranjang WHERE IDM = '{data.ID}' AND IDK = '{1}'");
                    }
                    DB.crud($"CALL MASUKKERANJANG('{data.ID}', '{1}', '{1}', '{data.Qty}')");
                    PanelOrder.SuspendLayout();
                    foreach (DataRow krj in DB.ds.Tables[0].Rows)
                    {
                        UCKeranjang kr = new UCKeranjang();
                        try
                        {
                            kr.gambarnya(new MemoryStream((byte[])krj["Pict"]));
                        }
                        catch (Exception)
                        {
                            kr.GambarMenu.Image = kr.GambarMenu.Image;
                        }
                        kr.LabelNama.Text = "" + krj["Nama"];
                        kr.label1.Text = "" + krj["Harga_Jual"];
                        kr.LabelQty.Text = "" + krj["QTY"];
                        kr.Width = kr.Width - 1;
                        kr.Name = "" + krj["ID_Keranjang"];
                        kr.tombolHapus += (sd, keranjangnya) =>
                        {
                            int subtotal = Convert.ToInt32(krj["Harga_Jual"]) * (keranjangnya.Qty);
                            DB.crud($"DELETE FROM tkeranjang WHERE ID_Keranjang = '{keranjangnya.Name}'");
                            LabelTotal.Text = (Convert.ToInt32(LabelTotal.Text) - subtotal).ToString();
                        };
                        kr.btnUbah += (send, value) =>
                        {
                            int harga_jual = Convert.ToInt32(krj["Harga_Jual"]);
                            int harga_total = Convert.ToInt32(LabelTotal.Text);

                            if (value.kondisi == "tambah")
                            {
                                LabelTotal.Text = (harga_total + harga_jual).ToString();
                            } else
                            {
                                LabelTotal.Text = (harga_total - harga_jual).ToString();
                            }
                        };
                        PanelOrder.Controls.Add(kr);
                        LabelTotal.Text = krj["Total"].ToString();
                    }
                    PanelOrder.ResumeLayout();
                };

                uc.Width = (int)(PanelListMenu.Width / 3) - 39;
                if (i % 3 == 0)
                {
                    uc.Margin = new Padding(0, 0, 0, 20);
                }
                else
                {
                    uc.Margin = new Padding(0, 0, 20, 20);
                }

                PanelListMenu.Controls.Add(uc);
            }
            PanelListMenu.ResumeLayout();
        }

        private void BtnMinuman_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int totalnya = Convert.ToInt32(LabelTotal.Text);
                int bayar = Convert.ToInt32(Bayar.Text);
                if (bayar < totalnya)
                {
                    LabelKembali.Text = "Uang Kurang";
                }
                else
                {
                    LabelKembali.Text = (bayar - totalnya).ToString();
                }
            }
            catch (Exception)
            {
                LabelKembali.Text = "0";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Bayar.Text.Trim() != "")
                {
                    int bayar = Convert.ToInt32(Bayar.Text);
                    int kembali = Convert.ToInt32(LabelKembali.Text);
                    DB.crud($"CALL MASUKTRANS(1, {bayar}, {kembali})");
                    PanelOrder.Controls.Clear();
                    LabelTotal.Text = "0";
                    Bayar.Text = "0";
                    LabelKembali.Text = "0";
                    return;
                }
                MessageBox.Show(this, "Silahkan masukkan nominal bayar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Silahkan masukkan nominal bayar yang sesuai!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            KF.untukRounded(guna2Panel3, 20, 20, 20, 20);
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (PanelListMenu.Controls.Count > 0)
            {
                string keyword = guna2TextBox3.Text.ToLower();

                foreach (UCMenu uc in PanelListMenu.Controls)
                {
                    string namaMenu = uc.LabelNama.Text.ToLower();

                    uc.Visible = namaMenu.Contains(keyword);
                }
            }
        }
    }
}

//NAMA DB HARUSNYA DBJUALRPLA