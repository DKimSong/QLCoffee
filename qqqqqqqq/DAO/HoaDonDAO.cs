using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    class HoaDonDAO
    {
        private static HoaDonDAO instance;

        internal static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
          private  set { HoaDonDAO.instance = value; }
        }
        private HoaDonDAO() { }
        public int hoadonban(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT *FROM dbo.HOADON WHERE MABAN = " + id + " AND checkout = '1'");
            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd.Mahd;
            }
            return -1;
        }

        public void insertHd(int id,string username)
        {
           
                Dataprovider.Instance.ExecuteNonQuery("exec insertHD " + id + ", " + username + "");
         
 
        }

        public int maxHoadon()
        {
            try
            {
                return (int)Dataprovider.Instance.ExecuteScalar("SELECT MAX(mahd) FROM dbo.HOADON");
            }
            catch {
                return 1;
            }
        }
        public void checkout(int mahd,int tien, float giamgia)
        {
            string query = "UPDATE dbo.HOADON SET checkout = 0 ,TONGTIEN = " + tien + ",GIAMGIA = " + giamgia + ", TGRA = GETDATE() WHERE MAHD = " + mahd + " ";
            Dataprovider.Instance.ExecuteNonQuery(query);

            string query1 = "update BAN set MATRANGTHAI = 2 where id = (select MABAN from HOADON where MAHD = '"+mahd+"')";
            Dataprovider.Instance.ExecuteNonQuery(query1);
        }
        public int layMAHD(int maban)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_laymahd '" + maban + "'");
            int t = int.Parse(data.Rows[0][0].ToString());
            return t;
        }
        public DataTable chart(DateTime tg)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_chart '" + tg + "'");
            return data;
        }
    }
}
