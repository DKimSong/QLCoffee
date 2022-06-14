using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
   public class table
    {


        public table(int id, string ten, string loaiban, string trangthai)
        {
            this.ID = id;
            this.Ten = ten;
            this.Loaiban = loaiban;
            this.Trangthai = trangthai;
        }
        public table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Ten = row["ten"].ToString();
            this.Loaiban = row["tenloai"].ToString();
            this.Trangthai = row["TENTRANGTHAI"].ToString();
        }
        private int iD;
        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private string loaiban;

        public string Loaiban
        {
            get { return loaiban; }
            set { loaiban = value; }
        }
        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
       
    }
}
