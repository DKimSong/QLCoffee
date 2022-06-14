using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class ThucDonDAO
    {
        private static ThucDonDAO instance;

        public static ThucDonDAO Instance
        {
            get { if (instance == null) instance = new ThucDonDAO(); return ThucDonDAO.instance; }
           private set { ThucDonDAO.instance = value; }
        }

        public ThucDonDAO() { }

        public List<ThucDon> listThucdon(int id)
        {
            List<ThucDon> list = new List<ThucDon>();

            string query = "SELECT *FROM dbo.THUCDON WHERE maloaitd = "+id+"";

            DataTable data = Dataprovider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ThucDon thucdon = new ThucDon(item);
                list.Add(thucdon);
            }

            return list;
        }

        public int timkiemthucdon(string tentd)
        {
           DataTable data = Dataprovider.Instance.ExecuteQuery("EXEC timdoan N'"+tentd+"' ");
           int t =  int.Parse(data.Rows[0][0].ToString());
           return t;

        }

        public DataTable load_searchHome()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec load_searchHome");
            return data;
        }

    }
}
