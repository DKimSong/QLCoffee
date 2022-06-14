using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class htHoaDonDAO
    {
        private static htHoaDonDAO instance;

        public static htHoaDonDAO Instance
        {
            get { if (instance == null) instance = new htHoaDonDAO(); return htHoaDonDAO.instance; }
            private set { htHoaDonDAO.instance = value; }

        }
        private htHoaDonDAO() { }

        public List<htHoadon> Hoadonban(int id)
        {
            List<htHoadon> hoadon = new List<htHoadon>();
            string query = "exec pr_hoadonban '"+id+"'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
       
            foreach(DataRow item in data.Rows){
                htHoadon hd = new htHoadon(item);
                hoadon.Add(hd);
            }


            return hoadon;
        }
    }
}
