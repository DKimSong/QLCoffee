using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
   public  class NhanVien
    {
       public NhanVien(string cmnd, string tennv, string diachi, string gioitinh, string sdt, string mail, string chucvu, bool trangthai)
       {
           this.Cmnd = cmnd;
           this.Tennv = tennv;
           this.Diachi = diachi;
           this.Gioitinh = Gioitinh;
           this.Sdt = sdt;
           this.Mail = mail;
           this.Chucvu = chucvu;
           this.Trangthai = trangthai;

       }

       public NhanVien(DataRow row)
       {
           this.Cmnd = row["CMND"].ToString();
           this.Tennv = row["tennv"].ToString();
           this.Diachi = row["diachi"].ToString();
           this.Gioitinh = row["gioitinh"].ToString();
           this.Sdt = row["sdt"].ToString();
           this.Mail = row["gmail"].ToString();
           this.Chucvu = row["tencv"].ToString(); ;
           this.Trangthai = (bool)row["trangthai"];
       }

        private string cmnd;

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }
        private string tennv;

        public string Tennv
        {
            get { return tennv; }
            set { tennv = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string gioitinh;

        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        private string chucvu;

        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
        private bool trangthai;

        public bool Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
