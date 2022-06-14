using qqqqqqqq.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qqqqqqqq
{
    public partial class xemcong : Form
    {
        public xemcong()
        {
            InitializeComponent();
            loaddgv(dateTimePicker1.Value);
        }

        private void loaddgv(DateTime ngay)
        {
            dgvxemchamcong.DataSource = DangKiCaDAO.Instance.xemchamcong(ngay);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loaddgv(dateTimePicker1.Value);
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn cập nhật bản chấm công này ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            for (int i = 0; i < dgvxemchamcong.Rows.Count; i++)
            {

                float cong;
                if (dgvxemchamcong.Rows[i].Cells["column9"].Value.ToString().Equals(""))
                {
                    cong = 0;

                }
                else
                    cong = float.Parse(dgvxemchamcong.Rows[i].Cells["Column9"].Value.ToString());

                string cmnd = dgvxemchamcong.Rows[i].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
                DateTime ngay = dateTimePicker1.Value;
                string ghichu = dgvxemchamcong.Rows[i].Cells["Column11"].Value.ToString();
                float thoigianlam = cong;


                DangKiCaDAO.Instance.updatechamcong(cmnd, ngay, ghichu, cong);

            }
            loaddgv(dateTimePicker1.Value);
        }
    }
}