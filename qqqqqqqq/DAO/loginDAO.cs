using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class loginDAO
    {
        private static loginDAO instance;

        public static loginDAO Instance
        {
            get { if (instance == null) instance = new loginDAO(); return loginDAO.instance; }
            private set { loginDAO.instance = value; }
        }

       
        private loginDAO()
        {

        }


        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }


        public bool checklogin(string username, string pass)
        {
            pass = MD5Hash(pass);
            string sql = "EXEC pr_checklogin '"+username+"', '"+pass+"'";
            DataTable table = new DataTable();
            table = Dataprovider.Instance.ExecuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                Properties.Settings.Default.chucvu = int.Parse(table.Rows[0][1].ToString());
                Properties.Settings.Default.tencv = (table.Rows[0][2].ToString());
            }
            return table.Rows.Count > 0;

        }

   

       

    }
}
