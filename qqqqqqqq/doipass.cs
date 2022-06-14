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
    public partial class doipass : Form
    {
        public doipass()
        {
            InitializeComponent();
            txtpasscu.UseSystemPasswordChar = true;
            txtpassmoi.UseSystemPasswordChar = true;
            txtpassmoi1.UseSystemPasswordChar = true;
        }

        private void doipass_Load(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            errorMessage.Clear();
                string passcu = txtpasscu.Text.Trim();
                string passmoi = txtpassmoi.Text.Trim();
                string passmoi1 = txtpassmoi1.Text.Trim();
                if (string.IsNullOrEmpty(passcu))
                {
                    errorMessage.SetError(txtpasscu, "Bạn cần nhập mật khẩu !");
                    txtpasscu.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(passmoi))
                {
                    errorMessage.SetError(txtpassmoi, "Bạn cần mật khẩu mới ! ");
                    txtpassmoi.Focus();
                    return;
                }
                if (passmoi.Length <= 5)
                {
                    errorMessage.SetError(txtpassmoi, "Bạn cần mật khẩu lớn hơn 5 kí tự ! ");
                    txtpassmoi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(passmoi1))
                {
                    errorMessage.SetError(txtpassmoi1, "Bạn cần mật khẩu mới ! ");
                    txtpassmoi1.Focus();
                    return;
                }
                if (passmoi.Contains(passmoi1) == false)
                {
                    errorMessage.SetError(txtpassmoi1, "Bạn cần nhập đúng mật khẩu mới ! ");
                    txtpassmoi1.Focus();
                    return;
                }
              
                if (taikhoanDAO.Instance.checkpassEdit(Properties.Settings.Default.user,passcu) ==false )
                {
                    errorMessage.SetError(txtpasscu, "Bạn cần nhập đúng mật khẩu ! ");
                    txtpassmoi1.Focus();
                    return;
                    
                }
                else
                {
                    try
                    {
                        taikhoanDAO.Instance.editPass(Properties.Settings.Default.user, passmoi);
                        MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtpasscu.UseSystemPasswordChar = false;
            else
                txtpasscu.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                txtpassmoi.UseSystemPasswordChar = false;
            else
                txtpassmoi.UseSystemPasswordChar = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                txtpassmoi1.UseSystemPasswordChar = false;
            else
                txtpassmoi1.UseSystemPasswordChar = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
