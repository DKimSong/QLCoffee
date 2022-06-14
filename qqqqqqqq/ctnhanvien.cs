using qqqqqqqq.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qqqqqqqq
{
    public partial class ctnhanvien : Form
    {
        public ctnhanvien()
        {
            InitializeComponent();
            loaddata(Properties.Settings.Default.id);
        }

        private void loaddata(string id)
        {
            DataTable data = new DataTable();
            data = nhanvienDAO.Instance.loadnhanvieninfo(id);
            lblcmnd.Text = data.Rows[0][0].ToString();
            lblten.Text = data.Rows[0][1].ToString();
            lbldiachi.Text = data.Rows[0][2].ToString();
            lblgioitinh.Text = data.Rows[0][3].ToString();
            lblsdt.Text = data.Rows[0][4].ToString();
            lblgmail.Text = data.Rows[0][5].ToString();
            lblchucvu.Text = data.Rows[0][6].ToString();
            pictureBox1.Refresh();

            MyDbContextDataContext mydb = new MyDbContextDataContext();
            NHANVIEN nv = mydb.NHANVIENs.Where(t => t.CMND == id).FirstOrDefault();
            if (nv == null) return;

            MemoryStream memoryStream = new MemoryStream((byte[])nv.ANH.ToArray());
            Image img = Image.FromStream(memoryStream);
            if (img == null)
                return;
            else
                pictureBox1.Image = img;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

