using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class taikhoanDAO
    {
         private static taikhoanDAO instance;

        public static taikhoanDAO Instance
        {
            get { if (instance == null) instance = new taikhoanDAO(); return taikhoanDAO.instance; }
            private set { taikhoanDAO.instance = value; }
        }
        public taikhoanDAO() { }

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
        public DataTable loadtaikhoan()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_loadtaikhoan");
            return data;
        }
        public void deleteAcc(string user)
        {
            Dataprovider.Instance.ExecuteQuery("exec deleteAcc '" + user + "'");
        }
        public bool checkUser(string user)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_checkUser '" + user + "'");
            if (data.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void AddACC(string user, string pass, string cmnd)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_addAcc '"+user+"','"+cmnd+"','"+pass+"'");
        }
        public bool checkpassEdit(string user, string pass)
        {
            pass = MD5Hash(pass);
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_checkpassedit '" + user + "', '" + pass + "'");
            if (data.Rows.Count > 0)
                return true;
            else
                return false;
        }


        public void editPass(string user, string pass)
        {
            pass = MD5Hash(pass);
            Dataprovider.Instance.ExecuteQuery("exec pr_editpass '" + user + "', '" + pass + "'");
        }
    }
}
