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
    public partial class themban : Form
    {
        public themban()
        {
            InitializeComponent();
            loadcomboloai();
            txtstt.Text = (BanDAO.Instance.maxstt() + 1).ToString();
        }

        private void loadcomboloai()
        {
            cbloaiban.DataSource = BanDAO.Instance.loadcbloaiban();
            cbloaiban.DisplayMember = "tenloai";
            cbloaiban.ValueMember = "maloaiban";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                errorMessage.Clear();
                string tenban = txttenban.Text.Trim();
                string stt = txtstt.Text.Trim();
                if (string.IsNullOrEmpty(tenban))
                {
                    errorMessage.SetError(txttenban, "Bạn cần nhập tên bàn !");
                    txttenban.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(stt))
                {
                    errorMessage.SetError(txtstt, "Bạn cần nhập số thứ tự !");
                    txtstt.Focus();
                    return;
                }

                BanDAO.Instance.themban((int)cbloaiban.SelectedValue, tenban, int.Parse(stt));
                MessageBox.Show("Đã Thêm Thành Công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Không thêm được bàn! Vui lòng kiểm tra lại thông tin. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Properties.Settings.Default.themban_ = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
