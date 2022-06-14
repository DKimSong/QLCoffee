using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class nhanvienDAO
    {
        private static nhanvienDAO instance;

        public static nhanvienDAO Instance
        {
            get { if (instance == null) instance = new nhanvienDAO(); return nhanvienDAO.instance; }
            private set { nhanvienDAO.instance = value; }
        }

        public nhanvienDAO() { }

        public List<NhanVien> loadNhanvien()
        {
            string str = "exec pr_nhanvien";
            List<NhanVien> list = new List<NhanVien>();

            DataTable data = Dataprovider.Instance.ExecuteQuery(str);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                list.Add(nv);

            }
            return list;
        }

        public DataTable loadnhanvienedit(string id)
        {
            string str = "SELECT *FROM dbo.NHANVIEN WHERE CMND = '"+id+"'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(str);
            return data;
        }

        public DataTable loadnhanvieninfo(string id)
        {
            string str = "EXEC pr_nhanvieninfo '"+id+"'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(str);
            return data;
        }
        public void suanhanvien(string idnew, string id)
        {
            string str = "EXEC pr_suanhanvien '"+idnew+"', '"+id+"'";
        
         Dataprovider.Instance.ExecuteQuery(str);
   
        }
        public DataTable cmnd(string id)
        {
            string str = "EXEC pr_cmnd '"+id+"'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(str);
            return data;
        }
        public DataTable cmndbackup(string id)
        {
            string str = "EXEC pr_cmndbackup '" + id + "'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(str);
            return data;
        }
        public DataTable xoanv(string id)
        {
            string str = "EXEC pr_xoanv '" + id + "'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(str);
            return data;
        }

        public DataTable search(string str)
        {
            string query = "EXEC pr_searchnv N'" + str + "'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable khoiphuc(string str)
        {
            string query = "EXEC pr_backupnv '" + str + "'";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable loadnhanvien()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_loadnhanvien");
            return data;
        }

    }
}
