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
    public partial class themnhanvien : Form
    {
     
        public themnhanvien()
        {
            InitializeComponent();
            loadchucvu();
          
        }
        
        private void loadchucvu()
        {
            cbchucvu.DataSource = ChucVuDAO.Instance.loadchucvu();
            cbchucvu.DisplayMember = "tencv";
            cbchucvu.ValueMember = "macv";
        }

        private void btnthem_Click(object sender, EventArgs e)
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
                if (cmnd.Length < 8 || cmnd.Length > 9)
                {
                    errorMessage.SetError(txtcmnd, "Số CMND không hợp lệ !");
                    txtcmnd.Focus();
                    return;
                }
                DataTable data = nhanvienDAO.Instance.cmnd((cmnd));
                if (data.Rows.Count > 0)
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
                NHANVIEN nv = new NHANVIEN();
                nv.CMND =txtcmnd.Text;
                nv.TENNV = txtten.Text;
                nv.SDT = txtsodt.Text;
                nv.DIACHI = txtdiachi.Text;
                nv.GIOITINH = Convert.ToBoolean(cbgioitinh1.SelectedIndex);
                nv.GMAIL = txtgmail.Text;
                nv.MACHUCVU = (int)cbchucvu.SelectedValue;
                nv.TRANGTHAI = true;
                nv.ANH = stream.ToArray();
                myDB.NHANVIENs.InsertOnSubmit(nv);
                myDB.SubmitChanges();
                MessageBox.Show("Đã Thêm Thành Công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                DangKiCaDAO.Instance.themdkca(nv.CMND);
                Properties.Settings.Default.themnv_ = false;
                this.Close();
             

            }
            catch
            {
                MessageBox.Show("Không thêm được nhân viên! Vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themnhanvien_Load(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.showCreateNv != true)
            //{
            //    this.Close();
            //}

        }

        private void txtcmnd_TextChanged(object sender, EventArgs e)
        {
            String cmnd = txtcmnd.Text.Trim();
            DataTable data = nhanvienDAO.Instance.cmndbackup(cmnd);
            if (data.Rows.Count > 0)
            {
                btnkhoiphuc.Visible = true;
                txtcmnd.Text = data.Rows[0][0].ToString();
              
                    errorMessage.SetError(txtcmnd, "Số CMND của nhân viên đã nghỉ việc. Bạn có thể khôi phục nhân viên này !");
                    
                txtten.Text = data.Rows[0][1].ToString();
                txtdiachi.Text = data.Rows[0][2].ToString();
                bool p = Convert.ToBoolean(data.Rows[0][3].ToString());
                int q;
                if (p)
                    q = 0;
                else
                    q = 1;
                cbgioitinh1.SelectedIndex = q;
                txtsodt.Text = data.Rows[0][4].ToString();
                txtgmail.Text = data.Rows[0][5].ToString();
                cbchucvu.SelectedValue = int.Parse(data.Rows[0][6].ToString());
                pictureBox1.Refresh();

                MyDbContextDataContext mydb = new MyDbContextDataContext();
                NHANVIEN nv = mydb.NHANVIENs.Where(t => t.CMND == cmnd).FirstOrDefault();
                if (nv == null) return;

                MemoryStream memoryStream = new MemoryStream((byte[])nv.ANH.ToArray());
                Image img = Image.FromStream(memoryStream);
                if (img == null)
                    return;
                else
                    pictureBox1.Image = img;
               
            }
            else
            {
                btnkhoiphuc.Visible = false;
             
                txtten.Text = "";
                txtdiachi.Text = "";
                txtsodt.Text = "";
                txtgmail.Text = "";
                cbchucvu.SelectedValue = 0;
                cbgioitinh1.SelectedIndex = 0;
                this.Refresh();
            }
        }

        private void btnkhoiphuc_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvienDAO.Instance.khoiphuc(txtcmnd.Text);
                MessageBox.Show("Khôi phục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Properties.Settings.Default.themnv_ = false;
                this.Close();
            
            }
            catch
            {
                MessageBox.Show("Không khôi phục được nhân viên! Vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
   

    }


    }

