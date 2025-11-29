using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class DB
    {
        public static MySqlConnection koneksi = new MySqlConnection("server=127.0.0.1; username=root; password = ; database=tesdbj");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(string sqlnya)
        {
            Console.WriteLine(sqlnya);
            ds.Tables.Clear();
            perintah = new MySqlCommand(sqlnya, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }

    }
}
