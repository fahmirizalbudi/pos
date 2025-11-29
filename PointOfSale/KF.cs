using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace PointOfSale
{
    class KF
    {
        public static Form1 Form1 = new Form1();
        public static FTransaksi FTransaksi = new FTransaksi() { TopLevel = false, TopMost = true };
        public static FKasir FKasir = new FKasir() { TopLevel = false, TopMost = true };
        public static FPelanggan FPelanggan = new FPelanggan() { TopLevel = false, TopMost = true };
        public static FMenu FMenu = new FMenu() { TopLevel = false, TopMost = true };
        public static FLapKasir FLapKasir = new FLapKasir() { TopLevel = false, TopMost = true };
        public static FLapJual FLapJual = new FLapJual() { TopLevel = false, TopMost = true };
        public static FBeranda FBeranda = new FBeranda() { TopLevel = false, TopMost = true };
        public static String IDK = null;
        public static String Nama = null;

        public static void untukform(Form formapa, Panel pnlapa)
        {
            pnlapa.Controls.Clear();
            pnlapa.Controls.Add(formapa);
            formapa.FormBorderStyle = FormBorderStyle.None;
            formapa.Dock = DockStyle.Fill;
            formapa.Show();
            formapa.ActiveControl = null;
        }

        public static void untukRounded(Control ctrlapa, int kiriatas, int kananatas, int kananbawah, int kiribawah)
        {
            int borderRadius = 10;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, kiriatas, kiriatas), 180, 90);
            path.AddLine(borderRadius, 0, ctrlapa.Width - borderRadius, 0);
            path.AddArc(new Rectangle(ctrlapa.Width - kananatas, 0, kananatas, kananatas), 270, 90);
            path.AddLine(ctrlapa.Width, borderRadius, ctrlapa.Width, ctrlapa.Height - borderRadius);
            path.AddArc(new Rectangle(ctrlapa.Width - kananbawah, ctrlapa.Height - kananbawah, kananbawah, kananbawah), 0, 90);
            path.AddLine(ctrlapa.Width - borderRadius, ctrlapa.Height, borderRadius, ctrlapa.Height);
            path.AddArc(new Rectangle(0, ctrlapa.Height - kiribawah, kiribawah, kiribawah), 90, 90);
            path.AddLine(0, ctrlapa.Height - borderRadius, 0, borderRadius);
            path.CloseFigure();
            ctrlapa.Region = new Region(path);
        }


        public static Image UbahGambarGambar(Image gmbr, int targetLebar, int targetTinggi)
        {
            float ratioX = (float)targetLebar / gmbr.Width;
            float ratioY = (float)targetTinggi / gmbr.Height;
            float ratio;
            ratio = Math.Max(ratioX, ratioY);
            int lebarBaru = (int)(gmbr.Width * ratio);
            int tinggiBaru = (int)(gmbr.Height * ratio);

            int posX = (targetLebar - lebarBaru) / 2;
            int posY = (targetTinggi - tinggiBaru) / 2;

            Bitmap b = new Bitmap(targetLebar, targetTinggi);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(gmbr, posX, posY, lebarBaru, tinggiBaru);
            }
            return b;
        }

        public static string jadiRupiah(int besarannya)
        {
            CultureInfo culture = new CultureInfo("id-ID");
            string formatRupiah = besarannya.ToString("C0", culture);
            return formatRupiah;
        }
    }
}
