using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace qqqqqqqq.DTO
{
   public class LoaiTd
    {
       public LoaiTd(int maloaitd, string tenloaitd)
       {
           this.Maloaitd = maloaitd;
           this.Tenloaitd = tenloaitd;
       }

       public LoaiTd(DataRow row)
       {
           this.Maloaitd = (int)row["maloaitd"];
           this.Tenloaitd = row["tenloaitd"].ToString();
       }


        private int maloaitd;

        public int Maloaitd
        {
            get { return maloaitd; }
            set { maloaitd = value; }
        }
        private string tenloaitd;

        public string Tenloaitd
        {
            get { return tenloaitd; }
            set { tenloaitd = value; }
        }

    }
}
