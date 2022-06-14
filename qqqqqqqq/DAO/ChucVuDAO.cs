
using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class ChucVuDAO
    {
        private static ChucVuDAO instance;

        public static ChucVuDAO Instance
        {
            get { if (instance == null) instance = new ChucVuDAO(); return ChucVuDAO.instance; }
            private set { ChucVuDAO.instance = value; }
        }
        public ChucVuDAO() { }

        public List<chucvu> loadchucvu()
        {
            string str = "exec pr_chucvu";
            List<chucvu> list = new List<chucvu>();

            DataTable data = Dataprovider.Instance.ExecuteQuery(str);

            foreach (DataRow item in data.Rows)
            {
                chucvu cv = new chucvu(item);
                list.Add(cv);

            }
            return list;
        }

        public DataTable tenchucvu(int id)
        {
            string str = "EXEC pr_tencv '"+id+"'";
            List<chucvu> list = new List<chucvu>();

            DataTable data = Dataprovider.Instance.ExecuteQuery(str);


            return data;
        }

     

        public bool checknhanvien(int id)
        {
            string str = "exec pr_checkqlnhanvien '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return Convert.ToBoolean(data.Rows[0][0].ToString());
        }


        public bool checkbanhang(int id)
        {
            string str = "exec pr_checkbanhang '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return Convert.ToBoolean(data.Rows[0][0].ToString());
        }

        public bool checkphache(int id)
        {
            string str = "exec pr_checkphache '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return Convert.ToBoolean(data.Rows[0][0].ToString());
        }
        public bool checkthucdon(int id)
        {
            string str = "exec pr_checkthucdon '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return Convert.ToBoolean(data.Rows[0][0].ToString());
        }



        public bool checkhethong(int id)
        {
            string str = "exec pr_checkhethong '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return Convert.ToBoolean(data.Rows[0][0].ToString());
        }

        public bool checkthongke(int id)
        {
            string str = "exec pr_checkthongke '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return Convert.ToBoolean(data.Rows[0][0].ToString());
        }












        public DataTable viewchucvu()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_loadchucvu");
            return data;
        }

        public void insertchucvu(string tennv, int luong, bool banhang, bool phache, bool thucdon,  bool nhanvien, bool hethong, bool thongke)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_insertchucvu N'"+tennv+"', '" + luong + "','" + banhang + "','" + phache + "','" + thucdon + "','" + nhanvien + "','" + hethong + "','" + thongke + "'");
        }

        public void updatechucvu(int macv, string tennv, int luong, bool banhang, bool phache, bool thucdon, bool nhanvien, bool hethong, bool thongke)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_updatechucvu  '" + macv + "',N'" + tennv + "', '" + luong + "','" + banhang + "','" + phache + "','" + thucdon + "','" + nhanvien + "','" + hethong + "','" + thongke + "'");
        }
        public DataTable checkxoacv(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_ktxoachucvu '"+id+"'");
            return data;
        }
        public void xoacv(int id)
        {
            Dataprovider.Instance.ExecuteQuery("exec xoacv '" + id + "'");
        }
    }
}
