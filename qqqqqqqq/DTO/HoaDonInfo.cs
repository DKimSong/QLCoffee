using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
   public class HoaDonInfo
    {
       public HoaDonInfo(int idhd, int idtd, int sl, int giaban, string trangthai)
       {
           this.Mahd = idhd;
           this.Matd = idtd;
           this.Soluong = sl;
           this.Gia = giaban;
           this.Trangthai = trangthai;
          

       }
       public HoaDonInfo(DataRow row)
       {
           this.Mahd = (int)row["mahd"];
           this.Matd = (int)row["matd"];
           this.Soluong = (int)row["soluong"];
           this.Gia = (int)row["gia"];
           this.Trangthai = row["trangthai"].ToString();
           this.Ghichu = row["ghichu"].ToString();
     
       }
       private string trangthai;
       public string Trangthai
       {
           get { return trangthai; }
           set { trangthai = value; }
       }
        private int mahd;

        public int Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }
        private string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        private int matd;

        public int Matd
        {
            get { return matd; }
            set { matd = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private int gia;

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

    }
}
