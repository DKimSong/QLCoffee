using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DAO
{
    public class HoaDonInfoDAO
    {
        private static HoaDonInfoDAO instance;

        public static HoaDonInfoDAO Instance
        {
            get { if (instance == null) instance = new HoaDonInfoDAO(); return HoaDonInfoDAO.instance; }
            private set { HoaDonInfoDAO.instance = value; }
        }
        private HoaDonInfoDAO() { }
        public List<HoaDonInfo> thongtinHD(int id)
        {
            List<HoaDonInfo> dsHD = new List<HoaDonInfo>();
            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT *FROM dbo.CTHOADON WHERE MAHD = "+id+"");
            foreach(DataRow item in data.Rows){
                HoaDonInfo info = new HoaDonInfo(item);
                dsHD.Add(info);
            }
            return dsHD;
        }

        public void insertHdInfo(int mahd, int matd, int sl, int gia, int idct)
        {
            Dataprovider.Instance.ExecuteQuery("EXEC dbo.themcthoadon " + mahd + ", " + matd + ", " + sl + ", " + gia + ",' ','1', '"+idct+"'");
        }
        public void deletedoadoninfo(int id){
            Dataprovider.Instance.ExecuteQuery("DELETE dbo.CTHOADON WHERE MATD = "+id+"");
        }

        public DataTable ghichu_tt(int id, int matd)
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("exec pr_ghichu '" + id + "','" + matd + "'");
            return data;
        }
        public void suacthoadon(int mahd, int matd, int matd1, int soluong, int gia, string ghichu, int trangthai)
        {
            Dataprovider.Instance.ExecuteQuery("EXEC suacthoadon '"+mahd+"','"+matd+"','"+matd1+"','"+soluong+"','"+gia+"',N'"+ghichu+"','"+trangthai+"', '"+Properties.Settings.Default.idct+"'");
        }

    }
}
