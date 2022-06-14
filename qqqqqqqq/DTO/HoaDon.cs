using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
    public class HoaDon
    {
        public HoaDon(int mahd, DateTime tgvao, DateTime tgra, int idban, int Tongtien, Boolean checkout, float giamgia = 0)
        {
            this.Mahd = mahd;
            this.Tgvao = tgvao;
            this.Tgra = tgra;
            this.Idban = idban;
            this.Tongtien = tongtien;
            this.Checkout = checkout;
            this.User = user;
            this.Giamgia = giamgia;

        }
        public HoaDon(DataRow row)
        {
            this.mahd = (int)row["MAHD"];


            var kttgvao = row["TGVAO"];
            if (kttgvao.ToString() != "")
                this.tgvao = (DateTime?)row["TGVAO"];
         


            var kttgra = row["TGRA"];
            if (kttgra.ToString() != "")
                this.tgra = (DateTime?)row["TGRA"];

            this.idban = (int)row["MABAN"];
            this.tongtien = (int)row["TONGTIEN"];
            this.checkout = (Boolean)row["checkout"];
            this.user = (string)row["USERNAME"];
         //   this.giamgia = (int)row["GIAMGIA"];
        }
        private int mahd;
        private float giamgia;

        public float Giamgia
        {
            get { return giamgia; }
            set { giamgia = value; }
        }
        public int Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }
        private int maban;

        public int Maban
        {
            get { return maban; }
            set { maban = value; }
        }
        private DateTime? tgvao;

        public DateTime? Tgvao
        {
            get { return tgvao; }
            set { tgvao = value; }
        }
        private DateTime? tgra;

        public DateTime? Tgra
        {
            get { return tgra; }
            set { tgra = value; }
        }
        private int idban;

        public int Idban
        {
            get { return idban; }
            set { idban = value; }
        }
        private int tongtien;

        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        private Boolean checkout;

        public Boolean Checkout
        {
            get { return checkout; }
            set { checkout = value; }
        }

       

       
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }



    }
}
