using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
    public class ThucDon
    {

        public ThucDon(int maloaitd, int matd, string tentd, int gia, bool trangthai)
        {
            this.Maloaitd = maloaitd;
            this.Matd = matd;
            this.Tentd = tentd;
            this.Gia = gia;
            this.Trangthai = trangthai;
         
        }

        public ThucDon(DataRow row)
        {
            this.Maloaitd = (int)row["maloaitd"];
            this.Matd = (int)row["MATD"];
            this.Tentd = row["TENTD"].ToString();
            this.Gia = (int)row["GIA"];
            this.Trangthai = (bool)row["trangthai"];
       
        }
        private bool trangthai;

        public bool Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        private byte hinh;

        public byte Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        private int maloaitd;

        public int Maloaitd
        {
            get { return maloaitd; }
            set { maloaitd = value; }
        }
        private int matd;

        public int Matd
        {
            get { return matd; }
            set { matd = value; }
        }
        private string tentd;

        public string Tentd
        {
            get { return tentd; }
            set { tentd = value; }
        }
        private int gia;

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }




    }
}
