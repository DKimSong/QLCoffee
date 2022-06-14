using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qqqqqqqq.DTO
{
    public class chucvu
    {
        public chucvu(int macv, string tencv, int luong)
        {
            this.Macv = macv;
            this.Tencv = tencv;
            this.Luong = luong;
        }
        public chucvu(DataRow row)
        {
            this.Macv = (int)row["macv"];
            this.Tencv = row["tencv"].ToString();
            this.Luong = (int)row["luong"];
        }

        private int macv;

        public int Macv
        {
            get { return macv; }
            set { macv = value; }
        }
        private string tencv;

        public string Tencv
        {
            get { return tencv; }
            set { tencv = value; }
        }
        private int luong;

        public int Luong
        {
            get { return luong; }
            set { luong = value; }
        }

    }
}
