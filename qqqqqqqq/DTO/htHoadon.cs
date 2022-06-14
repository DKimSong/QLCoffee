using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
    public class htHoadon
    {
        public htHoadon(string thucan, int count, int gia, int thanhtien,int matd,int maloaitd,string ghichu,string trangthai,int id)
        {
            this.Thucan = thucan;
            this.Count = count;
            this.Gia = gia;
            this.Thanhtien = thanhtien;
            this.Matd = matd;
            this.Maloaitd = maloaitd;
            this.Ghichu = ghichu;
            this.Trangthai = trangthai;
            this.Id = id;
        }
    
        public htHoadon(DataRow row)
        {
            this.Thucan = row["TENTD"].ToString();
            this.Count = (int)row["SOLUONG"];
            this.Gia = (int)row["GIA"];
            this.Thanhtien = (int)row["thanhtien"];
            this.Matd = (int)row["matd"];
            this.Maloaitd = (int)row["MALOAITD"];
            this.Ghichu = row["ghichu"].ToString();
            this.Trangthai = row["trangthai"].ToString();
            this.Id = (int)row["id"];
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
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


        private string thucan;

        public string Thucan
        {
            get { return thucan; }
            set { thucan = value; }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int gia;

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private int thanhtien;

        public int Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }


    }
}
