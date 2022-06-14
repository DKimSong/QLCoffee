using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qqqqqqqq.DAO;
using System.Security.Cryptography;

namespace qqqqqqqq
{
    public partial class page_hethong : UserControl
    {
        public page_hethong()
        {
            InitializeComponent();
            loaddata();
            loadca();
            loaddgvchucvu();
            loadcbnhanvien();
            loaddgvtaikhoan();
        
        }

        private void loaddgvtaikhoan()
        {
            dgvtaikhoan.DataSource = taikhoanDAO.Instance.loadtaikhoan();
        }

        private void loadcbnhanvien()
        {
            cbnhanvien.DataSource = nhanvienDAO.Instance.loadnhanvien();
            cbnhanvien.DisplayMember = "tennv";
            cbnhanvien.ValueMember = "cmnd";
           
        
        }

        private void loaddgvchucvu()
        {
            dgvchucvu.DataSource = ChucVuDAO.Instance.viewchucvu();
        }

        private void loadca()
        {
            dgvca.DataSource = CaDAO.Instance.listca();
            btn_luu.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void loaddata()
        {
            dgvloadban.DataSource = BanDAO.Instance.htban();
            //dgvloadban.Columns["sua"].DisplayIndex = 1;
            //dgvloadban.Columns["xoa"].DisplayIndex = 5;
        }

       

        private void dgvloadban_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                int c = e.ColumnIndex;

                if (r >= 0)
                {
                    Properties.Settings.Default.idban = int.Parse(dgvloadban.Rows[r].Cells["Column1"].Value.ToString());

                    if (c == 5)
                    {
                        suaban frm = new suaban();
                        frm.FormClosed += new FormClosedEventHandler(dongform);
                        frm.ShowDialog();
                    }
                    if (c == 6)
                    {
                        if (BanDAO.Instance.checktrangthai(Properties.Settings.Default.idban) != true)
                        {
                            MessageBox.Show("Bàn đang có khách ! không thể xóa. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (MessageBox.Show("Bạn có thật sự muốn xóa bàn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            BanDAO.Instance.xoaban(Properties.Settings.Default.idban);

                            loaddata();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dongform(object sender, FormClosedEventArgs e)
        {
            loaddata();
            this.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            themban frm = new themban();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.ShowDialog();
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Nhập tên tìm kiếm")
                txtsearch.Text = "";
            txtsearch.ForeColor = Color.Black;
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
                txtsearch.Text = "Nhập tên tìm kiếm";
            txtsearch.ForeColor = Color.Gray;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (txtsearch.ForeColor == Color.Gray)
            {
                return;
            }

            DataTable data = BanDAO.Instance.search(txtsearch.Text);
            dgvloadban.DataSource = data;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnthem.Text = "        Làm mới";
                btn_luu.Enabled = true;
                btnxoa.Enabled = true;
                int r = e.RowIndex;
                if (r >= 0)
                {
                    txttenca.Text = dgvca.Rows[r].Cells["tenca"].Value.ToString();
                    mtxtbd.Text = dgvca.Rows[r].Cells["thoigianbd"].Value.ToString();
                    mtxtkt.Text = dgvca.Rows[r].Cells["thoigiankt"].Value.ToString();
                    Properties.Settings.Default.macaCa = int.Parse(dgvca.Rows[r].Cells["maca"].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                btnthem.Text = btnthem.Text == "        Thêm" ? btnthem.Text = "        Làm mới" : btnthem.Text = "        Thêm";
                if (btnthem.Text == "        Thêm")
                {
                    btn_luu.Enabled = false;
                    btnxoa.Enabled = false;
                    txttenca.Text = "";


                }
                else if (btnthem.Text == "        Làm mới")
                {
                    btn_luu.Enabled = true;
                    btnxoa.Enabled = true;


                    errorMessage.Clear();
                    string ten = txttenca.Text.Trim();
                    string tgbd = mtxtbd.Text.Trim();
                    string tgktkt = mtxtkt.Text.Trim();
                    if (string.IsNullOrEmpty(ten))
                    {
                        errorMessage.SetError(txttenca, "Bạn cần nhập tên chức vụ !");
                        txttenca.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(tgbd))
                    {
                        errorMessage.SetError(mtxtbd, "Bạn cần nhập lương ! ");
                        mtxtkt.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(tgktkt))
                    {
                        errorMessage.SetError(mtxtkt, "Bạn cần nhập lương ! ");
                        mtxtkt.Focus();
                        return;
                    }
                    else { 
                    CaDAO.Instance.themca(txttenca.Text, mtxtbd.Text, mtxtkt.Text);
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadca();
                        }
                }
            }
            catch
            {
                MessageBox.Show("Không thêm được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void tabNavigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                errorMessage.Clear();
                string ten = txttenca.Text.Trim();
                string tgbd = mtxtbd.Text.Trim();
                string tgktkt = mtxtkt.Text.Trim();
                if (string.IsNullOrEmpty(ten))
                {
                    errorMessage.SetError(txttenca, "Bạn cần nhập tên chức vụ !");
                    txttenca.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(tgbd))
                {
                    errorMessage.SetError(mtxtbd, "Bạn cần nhập lương ! ");
                    mtxtkt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(tgktkt))
                {
                    errorMessage.SetError(mtxtkt, "Bạn cần nhập lương ! ");
                    mtxtkt.Focus();
                    return;
                }

                else
                {
                    CaDAO.Instance.suaca(txttenca.Text, mtxtbd.Text, mtxtkt.Text, Properties.Settings.Default.macaCa);
                    MessageBox.Show("Lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadca();
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn có thật sự muốn xóa ca này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    CaDAO.Instance.deleteCa(Properties.Settings.Default.macaCa);
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadca();
                }


               
            }
            catch
            {
                MessageBox.Show("Không xóa được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvchucvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnthemcv.Text = "Làm mới";
                btnluucv.Enabled = true;
                btnxoacv.Enabled = true;
                int r = e.RowIndex;
                if (r >= 0)
                {
                    Properties.Settings.Default.macv = int.Parse(dgvchucvu.Rows[r].Cells["macv"].Value.ToString());
                    txttencv.Text = dgvchucvu.Rows[r].Cells["tencv"].Value.ToString();
                    txtluong.Text = dgvchucvu.Rows[r].Cells["luong"].Value.ToString();
                    ckbanhang.Checked = Convert.ToBoolean(dgvchucvu.Rows[r].Cells["banhang"].Value);
                    ckhethong.Checked = Convert.ToBoolean(dgvchucvu.Rows[r].Cells["hethong"].Value);
                    cknhanvien.Checked = Convert.ToBoolean(dgvchucvu.Rows[r].Cells["qlnhanvien"].Value);
                    ckphache.Checked = Convert.ToBoolean(dgvchucvu.Rows[r].Cells["phache"].Value);
                    ckthongke.Checked = Convert.ToBoolean(dgvchucvu.Rows[r].Cells["thongke"].Value);
                    ckthucdon.Checked = Convert.ToBoolean(dgvchucvu.Rows[r].Cells["thucdon"].Value);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {

             



                btnthemcv.Text = btnthemcv.Text == "Thêm" ? btnthemcv.Text = "Làm mới" : btnthemcv.Text = "Thêm";
                if (btnthemcv.Text == "Thêm")
                {
                    btnluucv.Enabled = false;
                    btnxoacv.Enabled = false;
                    txtluong.Text = "";
                    txttencv.Text = "";


                }
                else if (btnthemcv.Text == "Làm mới")
                {
                    btnluucv.Enabled = true;
                    btnxoacv.Enabled = true;

                    errorMessage.Clear();
                    string ten = txttencv.Text.Trim();
                    string luong = txtluong.Text.Trim();

                    if (string.IsNullOrEmpty(ten))
                    {
                        errorMessage.SetError(txttencv, "Bạn cần nhập tên chức vụ !");
                        txttencv.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(luong))
                    {
                        errorMessage.SetError(txtluong, "Bạn cần nhập lương ! ");
                        txtluong.Focus();
                        return;
                    }
                    else
                    {


                        ChucVuDAO.Instance.insertchucvu(txttencv.Text, int.Parse(txtluong.Text), ckbanhang.Checked, ckphache.Checked, ckthucdon.Checked, cknhanvien.Checked, ckhethong.Checked, ckthongke.Checked);
                        MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        loaddgvchucvu();
                    }

                }
            }
            catch
            {
                MessageBox.Show("Không thêm được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnluucv_Click(object sender, EventArgs e)
        {
            try
            {
                errorMessage.Clear();
                string ten = txttencv.Text.Trim();
                string luong = txtluong.Text.Trim();

                if (string.IsNullOrEmpty(ten))
                {
                    errorMessage.SetError(txttencv, "Bạn cần nhập tên chức vụ !");
                    txttencv.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(luong))
                {
                    errorMessage.SetError(txtluong, "Bạn cần nhập lương ! ");
                    txtluong.Focus();
                    return;
                }
                else
                {

                    if (MessageBox.Show("Sau khi sửa bạn phải đăng xuất để hoàn tất việc sửa đổi !", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ChucVuDAO.Instance.updatechucvu(Properties.Settings.Default.macv, txttencv.Text, int.Parse(txtluong.Text), ckbanhang.Checked, ckphache.Checked, ckthucdon.Checked, cknhanvien.Checked, ckhethong.Checked, ckthongke.Checked);
                        MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Application.Restart();
                    }




                   
                }
            }
            catch
            {
                  MessageBox.Show("Không sửa được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void btnxoacv_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable data = ChucVuDAO.Instance.checkxoacv(Properties.Settings.Default.macv);
                if (data.Rows.Count == 0)
                {
                    ChucVuDAO.Instance.xoacv(Properties.Settings.Default.macv);
                    loaddgvchucvu();
                }


                else
                    MessageBox.Show("Tồn tại nhân viên mang chức vụ này ! Không xóa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabNavigationPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvtaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                int c = e.ColumnIndex;
                if (r >= 0 && c == 0)
                {
                    string user = dgvtaikhoan.Rows[r].Cells["username"].Value.ToString();
                    if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        MessageBox.Show(Properties.Settings.Default.user + " "+ user);
                        if (user == Properties.Settings.Default.user)
                        {
                            if (MessageBox.Show("Bạn muốn xóa chính tài khoản của bạn ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                taikhoanDAO.Instance.deleteAcc(user);
                                loaddgvtaikhoan();
                                Application.Restart();
                            }
                        }
                        else
                        {
                            taikhoanDAO.Instance.deleteAcc(user);
                            loaddgvtaikhoan();

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            try
            {
                errorMessage.Clear();
                string ten = txtuser.Text.Trim();
                string pass = txtpass.Text.Trim();

                if (string.IsNullOrEmpty(ten))
                {
                    errorMessage.SetError(txtuser, "Bạn cần nhập tên đăng nhập !");
                    txtuser.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(pass))
                {
                    errorMessage.SetError(txtpass, "Bạn cần mật khẩu ! ");
                    txtpass.Focus();
                    return;
                }
                if (pass.Length <= 5)
                {
                    errorMessage.SetError(txtpass, "Mật khẩu phải ít nhất 6 kí tự ! ");
                    txtpass.Focus();
                    return;
                }
                if (taikhoanDAO.Instance.checkUser(ten))
                {
                    errorMessage.SetError(txtuser, "Tên tài khoản đã tồn tại ! ");
                    txtpass.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        pass = MD5Hash(pass);
                        taikhoanDAO.Instance.AddACC(ten, pass, (cbnhanvien.SelectedValue.ToString()));
                        loaddgvtaikhoan();
                        MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        loadcbnhanvien();
                        txtuser.Text = "";
                        txtpass.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtsearch.ForeColor == Color.Gray)
                {
                    return;
                }

                DataTable data = BanDAO.Instance.search(txtsearch.Text);
                dgvloadban.DataSource = data;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            if (Properties.Settings.Default.themnv_ == false)
            {
                loadcbnhanvien();
                Properties.Settings.Default.themnv_ = true;
            }

        }
       
        }

      
    
}
