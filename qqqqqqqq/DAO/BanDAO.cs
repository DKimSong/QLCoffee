using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class BanDAO
    {
        private static BanDAO instance;

        public static BanDAO Instance
        {
            get { if (instance == null) instance = new BanDAO(); return BanDAO.instance; }
            private set { BanDAO.instance = value; }
         }
        private BanDAO() { }

        public List<table> loadbanList()
        {

            List<table> tableList = new List<table>();
            DataTable data = Dataprovider.Instance.ExecuteQuery("EXEC dbo.[_LoadBan]");
            foreach (DataRow item in data.Rows)
            {
                table _table = new table(item);
                tableList.Add(_table);
            }
            return tableList;
        }

        public DataTable htban()
        {
           
            DataTable data = Dataprovider.Instance.ExecuteQuery("EXEC htban");
            return data;
        }
        public string getten(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_tenban '"+id+"'");
            return data.Rows[0][0].ToString();
        }
        public int getidloaiban(int id)
        {

            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_loaiban '" + id + "'");
            return int.Parse(data.Rows[0][0].ToString());
        }

        public int getstt(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_stt '" + id + "'");
            return int.Parse(data.Rows[0][0].ToString());
        }
        public DataTable loadcbloaiban()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_cbloaiban");
            return data;
        }
        public void editban(string name, int maloai, int stt, int id)
        {
            Dataprovider.Instance.ExecuteQuery("EXEC pr_updateban '"+name+"','"+maloai+"','"+stt+"','"+id+"'");
        }
        public bool checktrangthai(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_trangthaiban '"+id+"'");
            if (int.Parse(data.Rows[0][0].ToString()) == 2)
                return true;
            else
                return false;
        }

        public void xoaban(int id)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_xoaban '"+id+"'");
        }

        public int maxstt()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_maxstt");
            return int.Parse(data.Rows[0][0].ToString());
        }

        public void themban(int maloai, string ten, int stt)
        {
            Dataprovider.Instance.ExecuteQuery("EXEC pr_themban '" + maloai + "','" + ten + "','" + stt + "'");
        }

        public DataTable search(string ten)
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("EXEC pr_searchban N'"+ten+"'");
            return data;
        }

    }
}
