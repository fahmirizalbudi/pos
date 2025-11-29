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
    public partial class FLapKasir : Form
    {
        public FLapKasir()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DB.crud("SELECT IDK, Nama_Kasir, Username, NO_TLP, Hak FROM `tkasir`;");
            CRLapKasir laporan = new CRLapKasir();
            laporan.SetDataSource(DB.ds.Tables[0]);
            crystalReportViewer1.ReportSource = laporan;
            crystalReportViewer1.Refresh();
        }
    }
}
