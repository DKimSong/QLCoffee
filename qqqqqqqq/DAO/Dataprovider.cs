using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class Dataprovider
    {
        private static Dataprovider instance;

        public static Dataprovider Instance
        {
            get { if (instance == null) instance = new Dataprovider(); return Dataprovider.instance; }
           private set { Dataprovider.instance = value; }
        }
        private Dataprovider() { 
        }

        private string strconn = @"Data Source=DESKTOP-AVAEUFC;Initial Catalog=CAFE.net;Integrated Security=True";
        public SqlConnection conn = null;
        public void openCon()
        {
            if (conn == null)
            {
                conn = new SqlConnection(strconn);

            }
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public DataTable ExecuteQuery(String sql)
        {
           
                DataTable data = new DataTable();

                using (SqlConnection connection = new SqlConnection(strconn))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    connection.Close();
                }
                return data;
            

        }

         public int ExecuteNonQuery(String sql){
            openCon();
            int data = 0;
            SqlCommand command = new SqlCommand(sql, conn);
            data = command.ExecuteNonQuery();
          conn.Close();
          return data;
        }


         public object ExecuteScalar(String sql)
         {
             openCon();
             object data = 0;
             SqlCommand command = new SqlCommand(sql, conn);
             data = command.ExecuteScalar();
             conn.Close();
             return data;
         }
        
        
    }
}
