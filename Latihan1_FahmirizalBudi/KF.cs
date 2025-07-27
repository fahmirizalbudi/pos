using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Latihan1_FahmirizalBudi
{
    class KF
    {
        public static FTransaksi FTransaksi = new FTransaksi() { TopLevel = false, TopMost = true };

        public static void untukform(Form formapa, Panel pnlapa)
        {
            pnlapa.Controls.Clear();
            pnlapa.Controls.Add(formapa);
            formapa.FormBorderStyle = FormBorderStyle.None;
            formapa.Dock = DockStyle.Fill;
            formapa.Show();
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
    }
}
