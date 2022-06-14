using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    class chebienDAO
    {
        private static chebienDAO instance;

        public static chebienDAO Instance
        {
            get { if (instance == null) instance = new chebienDAO(); return chebienDAO.instance; }
            private set { chebienDAO.instance = value; }


        }
        private chebienDAO() { }

        public DataTable htchebiensapxep()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_phache");
            return data;
        }
        public DataTable htchebien()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_phacheksapxep");
            return data;
        }

        public void chuyenphache(int id)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_chuyenPhaChe '" + id + "'");
        }
        public DataTable daphache()
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_daphache");
            return data;
        }


        public DataTable allphache()
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_allPhache");
            return data;
        }
        public void addphache(int matd, int sl, string ghichu)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_addphache '" + matd + "', '" + sl + "', '" + ghichu + "'");
        }

    }
}
