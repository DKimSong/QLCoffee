using qqqqqqqq.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qqqqqqqq
{
    public partial class suanhanvien : Form
    {
        public suanhanvien()
        {
            
            InitializeComponent();
           
            loadchucvu();
            loaddata(Properties.Settings.Default.id);
        }

        private void loadchucvu()
        {
            cbchucvu.DataSource = ChucVuDAO.Instance.loadchucvu();
            cbchucvu.DisplayMember = "tencv";
            cbchucvu.ValueMember = "macv";
        }

       

        private void loaddata(string id)
        {
            
            DataTable data = new DataTable();
            data = nhanvienDAO.Instance.loadnhanvienedit(id);
            txtcmnd.Text = data.Rows[0][0].ToString();
            txtten.Text = data.Rows[0][1].ToString();
            txtdiachi.Text = data.Rows[0][2].ToString();
            bool p = Convert.ToBoolean(data.Rows[0][3].ToString());
            int q;
            if (p)
                q = 1;
            else
                q = 0;
            cbgioitinh1.SelectedIndex = q;
            txtsodt.Text = data.Rows[0][4].ToString();
            txtgmail.Text = data.Rows[0][5].ToString();
            cbchucvu.SelectedValue =int.Parse( data.Rows[0][6].ToString());
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                errorMessage.Clear();
                string cmnd = txtcmnd.Text.Trim();
                string tennv = txtten.Text.Trim();
                string sdt = txtsodt.Text.Trim();

                if (string.IsNullOrEmpty(cmnd))
                {
                    errorMessage.SetError(txtcmnd, "Bạn cần nhập tên tài khoản !");
                    txtcmnd.Focus();
                    return;
                }
                if (cmnd.Length < 8 || cmnd.Length > 10)
                {
                    errorMessage.SetError(txtcmnd, "Số CMND không hợp lệ !");
                    txtcmnd.Focus();
                    return;
                }
         
                DataTable data =  nhanvienDAO.Instance.cmnd(cmnd);

                if (data.Rows.Count > 0 && txtcmnd.Text != Properties.Settings.Default.id.ToString())
                {
                    errorMessage.SetError(txtcmnd, "Số CMND đã tồn tại !");
                    txtcmnd.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(tennv))
                {
                    errorMessage.SetError(txtten, "Ban cần nhập tên nhân viên !");
                    txtten.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(sdt))
                {
                    errorMessage.SetError(txtsodt, "Bạn cần nhập số điện thoại !");
                    txtsodt.Focus();
                    return;
                }
                if (sdt.Length < 9)
                {
                    errorMessage.SetError(txtsodt, "Số điện thoại không hợp lệ !");
                    txtsodt.Focus();
                    return;
                }

                string diachi = txtdiachi.Text.Trim();
                if (string.IsNullOrEmpty(diachi))
                {
                    errorMessage.SetError(txtdiachi, "Bạn cần nhập địa chỉ!");
                    txtdiachi.Focus();
                    return;
                }
                string mail = txtgmail.Text.Trim();

                if (string.IsNullOrEmpty(mail))
                {
                    errorMessage.SetError(txtgmail, "Bạn cần nhập Gmail !");
                    txtgmail.Focus();
                    return;
                }
                if (mail.Contains("@") != true || mail.Length < 9)
                {
                    errorMessage.SetError(txtgmail, "Gmail không hợp lệ !");
                    txtgmail.Focus();
                    return;
                }


                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
                MyDbContextDataContext myDB = new MyDbContextDataContext();




                NHANVIEN td = myDB.NHANVIENs.Where(p => p.CMND == Properties.Settings.Default.id).FirstOrDefault();
                td.CMND = Properties.Settings.Default.id;
                td.TENNV = txtten.Text;
                td.DIACHI = txtdiachi.Text;
                td.GIOITINH = Convert.ToBoolean(cbgioitinh1.SelectedIndex);
                td.GMAIL = txtgmail.Text;
                td.TRANGTHAI = true;
                td.MACHUCVU = (int)cbchucvu.SelectedValue;
                td.ANH = stream.ToArray();
              

                myDB.SubmitChanges();
                nhanvienDAO.Instance.suanhanvien(txtcmnd.Text, Properties.Settings.Default.id);

                MessageBox.Show("Đã Sửa Thành Công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

                this.Close();

                Properties.Settings.Default.themnv_ = false;
            }
            catch
            {
                MessageBox.Show("Không sửa được nhân viên! Vui lòng kiểm tra lại thông tin. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(file))
                return;
            if (file == "openFileDialog1")
                return;
            else
            {
                Image myimage = Image.FromFile(file);
                pictureBox1.Image = myimage;

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
