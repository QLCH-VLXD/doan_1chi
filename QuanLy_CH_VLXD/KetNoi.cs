using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_CH_VLXD
{
    public class KetNoi
    {
        private static KetNoi instance;

        public static KetNoi Instance
        {
            get { if (instance == null) instance = new KetNoi(); return instance; }
            private set { instance = value; }
        }

        private KetNoi() { }


        public string ConnectionSTR = "Data Source=DESKTOP-CKJCBOM\\SQLEXPRESS;Initial Catalog=QL_CH_VATLIEUXAYDUNG;Integrated Security=True";



        public DataTable excuteQuery(string query)
        {


            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {

                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);
                    connection.Close();
                }
                catch
                {
                    return data;
                }
            }
            return data;
        }

        public int excuteNonQuery(string query)
        {
            int data = 0;


            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    data = cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    return data;
                }
            }
            return data;
        }

        public object excuteScalar(string query)
        {
            object data = 0;


            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    data = cmd.ExecuteScalar();
                    connection.Close();
                }
                catch
                {
                    return data;
                }
            }
            return data;
        }

        public bool KiemTra(string query)
        {
            if (excuteNonQuery(query) > 0)
                return true;
            return false;
        }

    }
}
