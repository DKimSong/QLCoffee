using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class LoaiTDAO
    {
        private static LoaiTDAO instance;

        public static LoaiTDAO Instance
        {
            get { if (instance == null) instance = new LoaiTDAO(); return LoaiTDAO.instance; }
            private set { LoaiTDAO.instance = value; }
        }
        public LoaiTDAO() { }

        public List<LoaiTd> ListLoaitd()
        {
            List<LoaiTd> list = new List<LoaiTd>();

            string query = "SELECT *FROM dbo.LOAITHUCDON";

            DataTable data = Dataprovider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiTd loaitd = new LoaiTd(item);
                list.Add(loaitd);

            }
            return list;

        }
        public int maloaitd(int id)
        {
            string str = "exec pr_maloaitd '" + id + "'";
            DataTable data = Dataprovider.Instance.ExecuteQuery(str);
            return int.Parse(data.Rows[0][0].ToString());
        }
        public void themloaitd(string str)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_themloaitd '" + str + "'");
        }

    }
}