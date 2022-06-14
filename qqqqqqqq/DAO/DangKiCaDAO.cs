using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class DangKiCaDAO
    {
         private static DangKiCaDAO instance;

        public static DangKiCaDAO Instance
        {
            get { if (instance == null) instance = new DangKiCaDAO(); return DangKiCaDAO.instance; }
            private set { DangKiCaDAO.instance = value; }
        }
        public DangKiCaDAO() {

          
        }

        public DataTable listDkca()
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_listca");
            return data;
        }

    
        public void themdkca(string cmnd)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_themdkca '" + cmnd + "'");
        }

        public void updatedkCa(int maca,string cmnd, int maca1)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_updateCa '"+maca+"', '"+cmnd+"', '"+maca1+"'");
        }

        public DataTable loadchamcong()
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_listchamcong");
            return data;
        }

        public void chamcong(string cmnd, DateTime ngay, string ghichu, float thoigianlam, int maca, DateTime thoigianbatdau)
        {
            Dataprovider.Instance.ExecuteQuery("exec chamcong '"+cmnd+"', '"+ngay+"','"+ghichu+"','"+thoigianlam+"', '"+maca+"', '"+thoigianbatdau+"'");
        }

        public DataTable xemchamcong(DateTime ngay)
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_xemchamcong '"+ngay+"'");
            return data;
        }

        public void updatechamcong(string cmnd, DateTime ngay, string ghichu, float thoigianlam)
        {
            Dataprovider.Instance.ExecuteQuery("exec updatechamcong '"+cmnd+"', '"+ngay+"','"+ghichu+"','"+thoigianlam+"'");
        }

        public DataTable thuongphatHome()
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_thuongphatHome");
            return data;
        }
        public void insertthuongphat(string cmnd, DateTime ngay, string lydo, int tien)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_insertthuongphat '" + cmnd + "', '" + ngay + "',N'" + lydo + "','" + tien + "'");
        }

        public DataTable xemthuongphat(int thang, int nam)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("exec pr_xemthuongphat '" + thang + "', '"+nam+"'");
            return data;
        }
        public void updatethuongphat(string cmnd, string lydo, DateTime ngay, int tien, string lydo1, DateTime ngay1, int tien1)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_updatethuongphat '"+cmnd+"','"+ngay+"', '"+lydo+"', '"+tien+"', '"+ngay1+"','"+lydo1+"','"+tien1+"'");
        }

        public void xoathuongphat(string cmnd, string lydo, DateTime ngay, int tien)
        {
            Dataprovider.Instance.ExecuteQuery("exec pr_xoathuongphat '"+cmnd+"', '"+ngay+"','"+lydo+"','"+tien+"' ");
        }
        public DataTable luong(DateTime date)
        {
            DataTable data=  Dataprovider.Instance.ExecuteQuery("exec pr_luong '"+date+"'");
            return data;
        }
    }
}
