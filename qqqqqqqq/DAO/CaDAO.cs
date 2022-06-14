using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class CaDAO
    {
         private static CaDAO instance;

        public static CaDAO Instance
        {
            get { if (instance == null) instance = new CaDAO(); return CaDAO.instance; }
            private set { CaDAO.instance = value; }
         }
        private CaDAO() { }


        public DataTable listca()
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_loadca");
            return data;
        }
        public void themca(string ten, string timebd, string kt)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_insertca N'"+ten+"', '"+timebd+"', '"+kt+"'");
        }
        public void suaca(string ten, string timebd, string kt, int maca)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_suaCa '" + maca + "', N'" + ten + "','" + timebd + "','" + kt + "'");
        }
        public void deleteCa(int maca)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_deleteCa '" + maca + "'");
        }
    }
}
