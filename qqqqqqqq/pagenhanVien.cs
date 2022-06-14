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

namespace qqqqqqqq
{
    public partial class pagenhanVien : UserControl
    {
        
        public pagenhanVien()
        {
            InitializeComponent();
            loaddgvnhanvien();
            Properties.Settings.Default.showCreateNv = false;
            loaddkca();
            loaddgvchamcong();
            loadthuongphat();
            btn_luu.Enabled = false;
            btnxoa.Enabled = false;
            loaddgvluong();
        }

        private void loaddgvluong()
        {
            dgvluong.DataSource = DangKiCaDAO.Instance.luong(dtpluong.Value);
            dgvluong.Columns["luongcmnd"].DisplayIndex = 0;
            dgvluong.Columns["luongtennv"].DisplayIndex = 1;
            dgvluong.Columns["luongsongaylam"].DisplayIndex = 2;
            dgvluong.Columns["luongthuongphat"].DisplayIndex = 3;
            dgvluong.Columns["luongluong"].DisplayIndex = 4;
            dgvluong.Columns["luongtongluong"].DisplayIndex = 5;
        }

        private void loadthuongphat()
        {
            dgvthuongphat.DataSource = DangKiCaDAO.Instance.thuongphatHome();
            if (dgvthuongphat.RowCount > 0)
            {
                Properties.Settings.Default.cmndthuongphat = dgvthuongphat.Rows[0].Cells["Column12"].Value.ToString();

                if (dgvthuongphat.Rows[0].Cells["Column15"].Value == null)
                    this.dgvthuongphat.Columns["Column15"].Visible = false;
                if (dgvthuongphat.Rows[0].Cells["Column14"].Value == null)
                    this.dgvthuongphat.Columns["Column14"].Visible = false;
                if (dgvthuongphat.Rows[0].Cells["Column16"].Value == null)
                    this.dgvthuongphat.Columns["Column16"].Visible = false;

            }
        }

        private void loaddgvchamcong()
        {
            dgvchamcong.DataSource =  DangKiCaDAO.Instance.loadchamcong();
          
        }

        private void loaddkca()
        {
            dgvdk.DataSource = DangKiCaDAO.Instance.listDkca();
        }
       
        public void loaddgvnhanvien()
        {
            
            //dgvnhanvien.Columns["Column9"].DefaultCellStyle.BackColor = Color.White;
            //dgvnhanvien.Columns["Column8"].DefaultCellStyle.BackColor = Color.White;
            dgvnhanvien.Refresh();
            dgvnhanvien.DataSource = nhanvienDAO.Instance.loadNhanvien();
   
         //   dgvnhanvien.Columns.Add("duong", "ten");
         //   dgvnhanvien.Columns["duong"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         //   dgvnhanvien.Columns["duong"].DefaultCellStyle.BackColor = System.Drawing.Color.White;
         //   dgvnhanvien.Columns["duong"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         //   dgvnhanvien.Columns["duong"].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
         //   dgvnhanvien.Columns["duong"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
         //   dgvnhanvien.Columns["duong"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Red;

         //   dgvnhanvien.Columns["duong"].DefaultCellStyle = dgvnhanvien.Columns["duong"].DefaultCellStyle;
         //  // this.Columns[1].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         //   dgvnhanvien.Columns["duong"].Frozen = true;
         //   dgvnhanvien.Columns["duong"].HeaderText = "  Sửa";
         //   dgvnhanvien.Columns["duong"].Name = "Column9";
         ////   dgvnhanvien.Columns["duong"].ReadOnly = true;
         //   dgvnhanvien.Columns["duong"].Resizable = System.Windows.Forms.DataGridViewTriState.True;
         // //  dgvnhanvien.Columns["duong"].Text = "Sửa";
         // //  dgvnhanvien.Columns["duong"].UseColumnTextForButtonValue = true;
         //   dgvnhanvien.Columns["duong"].Width = 50;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            themnhanvien frm = new themnhanvien();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.ShowDialog();
        }

        private void dongform(object sender, FormClosedEventArgs e)
        {
            loaddgvnhanvien();
            loaddkca();
            this.Show();
        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int r = e.RowIndex;
            if (r >= 0)
            {
                Properties.Settings.Default.id = dgvnhanvien.Rows[r].Cells["cmnd"].Value.ToString();
            }
            int c = e.ColumnIndex;
            if ((r >= 0 && c >= 0) )
            {
               // MessageBox.Show(r + "   " + c);

                // MessageBox.Show(r + "" +c);
                string str = dgvnhanvien.Rows[r].Cells[c].Value.ToString();
                //MessageBox.Show(str);
                if (str.CompareTo(dgvnhanvien.Rows[r].Cells["sua"].Value.ToString()) == 0)
                {
                    suanhanvien frm = new suanhanvien();
                    frm.FormClosed += new FormClosedEventHandler(dongform);
                    frm.ResetText();
                    frm.ShowDialog();

                }


                if (str.CompareTo(dgvnhanvien.Rows[r].Cells["xoa"].Value.ToString()) == 0)
                {
                    try
                    {
                        if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                          //  Dataprovider.Instance.ExecuteQuery("exec pr_xoanv '" + Properties.Settings.Default.id.ToString() + "'");
                            nhanvienDAO.Instance.xoanv(Properties.Settings.Default.id.ToString());
                            loaddgvnhanvien();
                            loaddgvchamcong();
                            loaddkca();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Lỗi! không xóa được nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
               

                    // MessageBox.Show(r + "" +c);
                  //  string strt = dgvnhanvien.Rows[r].Cells[c].Value.ToString();
                if (str.CompareTo(dgvnhanvien.Rows[r].Cells["ct"].Value.ToString()) == 0)
                    {
                       // MessageBox.Show(r+"   "+c);
                        ctnhanvien frm = new ctnhanvien();
                        frm.ResetText();
                        frm.ShowDialog();

                    }

                
            }
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

            DataTable data = nhanvienDAO.Instance.search(txtsearch.Text);
            dgvnhanvien.DataSource = data;
     
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            loaddgvnhanvien();
        }

        private void txtsearch_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void tabNavigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvdk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
  
                Properties.Settings.Default.tennhanvien = dgvdk.Rows[r].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                Properties.Settings.Default.maca = int.Parse(dgvdk.Rows[r].Cells["Column1"].Value.ToString());
                Properties.Settings.Default.cmndca = (dgvdk.Rows[r].Cells["dataGridViewTextBoxColumn1"].Value.ToString());
                dangkica frm = new dangkica();
                frm.FormClosed += new FormClosedEventHandler(dongformdkca);
                frm.ResetText();
                frm.ShowDialog();
            }
        }

        private void dongformdkca(object sender, FormClosedEventArgs e)
        {
            loaddkca();
            loaddgvchamcong();
            this.Show();
        }
    

        private void dgvnhanvien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
          
            
        }

        private void dgvnhanvien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvchamcong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Lỗi! Dữ liệu không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

          
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn lưu bản chấm công này ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            for (int i = 0; i < dgvchamcong.Rows.Count ; i++)
            {

                float cong;
                if (dgvchamcong.Rows[i].Cells["column9"].Value.ToString().Equals(""))
                {
                    cong = 0;

                }
                else
                    cong = float.Parse(dgvchamcong.Rows[i].Cells["Column9"].Value.ToString());
                
                string cmnd = dgvchamcong.Rows[i].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
                DateTime ngay = dateTimePicker1.Value;
                string ghichu = dgvchamcong.Rows[i].Cells["Column11"].Value.ToString();
                float thoigianlam = cong;
                int maca = int.Parse(dgvchamcong.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
                DateTime thoigianbatdau = Convert.ToDateTime(dgvchamcong.Rows[i].Cells["dataGridViewTextBoxColumn8"].Value.ToString());
                if (dgvchamcong.Rows[i].Cells["column9"].Value.ToString().Equals("") == false)
                DangKiCaDAO.Instance.chamcong(cmnd, ngay, ghichu, thoigianlam, maca, thoigianbatdau);
               
            }
            
            loaddgvchamcong();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            xemcong frm = new xemcong();
            frm.FormClosed += new FormClosedEventHandler(dongformxemcong);
            frm.ShowDialog();
        }

        private void dongformxemcong(object sender, FormClosedEventArgs e)
        {
            loaddgvchamcong();
            this.Show();
        }

        private void tabNavigationPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvthuongphat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                Properties.Settings.Default.cmndthuongphat = dgvthuongphat.Rows[r].Cells["Column12"].Value.ToString();
                if (dgvthuongphat.Columns["Column12"].Width <200  )
                {
                    btnxoa.Enabled = true;
                    btn_luu.Enabled = true;
                    btnthem.Enabled = false;
                    dtpngay.Value = Convert.ToDateTime(dgvthuongphat.Rows[r].Cells["Column14"].Value.ToString());
                    txtlydo.Text = dgvthuongphat.Rows[r].Cells["Column16"].Value.ToString();
                    mtxttien.Text = dgvthuongphat.Rows[r].Cells["Column15"].Value.ToString();
                    Properties.Settings.Default.ngaythuongphat = (dgvthuongphat.Rows[r].Cells["Column14"].Value.ToString());
                    Properties.Settings.Default.lydo = (dgvthuongphat.Rows[r].Cells["Column16"].Value.ToString());
                    Properties.Settings.Default.tien = int.Parse(dgvthuongphat.Rows[r].Cells["Column15"].Value.ToString());
                    if ((int.Parse(mtxttien.Text) < 0))
                        radiophat.Checked = true;
                    else
                        radiothuong.Checked = true;
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                int tien = Math.Abs(int.Parse(mtxttien.Text));
                if (radiothuong.Checked == false)
                    tien = -tien;
                DangKiCaDAO.Instance.insertthuongphat(Properties.Settings.Default.cmndthuongphat, dtpngay.Value, txtlydo.Text, tien);
                MessageBox.Show("Đã thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            

            dgvthuongphat.Columns.Clear();


            this.dgvthuongphat.AllowUserToAddRows = false;
            this.dgvthuongphat.AllowUserToOrderColumns = true;
            dgvthuongphat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            //  this.dgvthuongphat.AlternatingRowsDefaultCellStyle = dgvthuongphat;
            this.dgvthuongphat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvthuongphat.BackgroundColor = System.Drawing.Color.White;
            this.dgvthuongphat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvthuongphat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;


            this.dgvthuongphat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthuongphat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16});
            this.dgvthuongphat.DoubleBuffered = true;
            this.dgvthuongphat.EnableHeadersVisualStyles = false;
            this.dgvthuongphat.GridColor = System.Drawing.Color.Black;
            this.dgvthuongphat.HeaderBgColor = System.Drawing.Color.Navy;
            this.dgvthuongphat.HeaderForeColor = System.Drawing.Color.White;
            this.dgvthuongphat.Location = new System.Drawing.Point(18, 30);
            this.dgvthuongphat.Name = "dgvthuongphat";
            this.dgvthuongphat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;


            this.dgvthuongphat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            this.dgvthuongphat.RowTemplate.Height = 30;
            this.dgvthuongphat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvthuongphat.Size = new System.Drawing.Size(548, 417);
            this.dgvthuongphat.TabIndex = 3;
            this.dgvthuongphat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvthuongphat_CellClick);

          //  dgvthuongphat.DataSource = DangKiCaDAO.Instance.thuongphatHome();
            if (dgvthuongphat.Rows.Count > 0)
            Properties.Settings.Default.cmndthuongphat = dgvthuongphat.Rows[0].Cells["Column12"].Value.ToString();
          
            btnthem.Enabled = false;
            btn_luu.Enabled = true;
            btnxoa.Enabled = true; 

////////////

          
            int thang = dtpthang.Value.Month;
            int nam = dtpthang.Value.Year;
            dgvthuongphat.DataSource = DangKiCaDAO.Instance.xemthuongphat(thang, nam);
            DataTable data = DangKiCaDAO.Instance.xemthuongphat(thang, nam);
            if (data.Rows.Count == 0)
            {
                btnthem.Enabled = false;
                btn_luu.Enabled = false;
                btnxoa.Enabled = false;
            }

            dgvthuongphat.Columns["Column15"].Visible = true;

            dgvthuongphat.Columns["Column14"].Visible = true;

            dgvthuongphat.Columns["Column16"].Visible = true;
           dgvthuongphat.Columns["Column12"].DisplayIndex = 0;
           dgvthuongphat.Columns["Column13"].DisplayIndex = 1;
           dgvthuongphat.Columns["Column14"].DisplayIndex = 2;
           dgvthuongphat.Columns["Column15"].DisplayIndex = 3;
           dgvthuongphat.Columns["Column16"].DisplayIndex = 4;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            dgvthuongphat.Columns.Clear();


            this.dgvthuongphat.AllowUserToAddRows = false;
            this.dgvthuongphat.AllowUserToOrderColumns = true;
            dgvthuongphat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
          //  this.dgvthuongphat.AlternatingRowsDefaultCellStyle = dgvthuongphat;
            this.dgvthuongphat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvthuongphat.BackgroundColor = System.Drawing.Color.White;
            this.dgvthuongphat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvthuongphat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
       
   
            this.dgvthuongphat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthuongphat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16});
            this.dgvthuongphat.DoubleBuffered = true;
            this.dgvthuongphat.EnableHeadersVisualStyles = false;
            this.dgvthuongphat.GridColor = System.Drawing.Color.Black;
            this.dgvthuongphat.HeaderBgColor = System.Drawing.Color.Navy;
            this.dgvthuongphat.HeaderForeColor = System.Drawing.Color.White;
            this.dgvthuongphat.Location = new System.Drawing.Point(18, 30);
            this.dgvthuongphat.Name = "dgvthuongphat";
            this.dgvthuongphat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
           

            this.dgvthuongphat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
         
            this.dgvthuongphat.RowTemplate.Height = 30;
            this.dgvthuongphat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvthuongphat.Size = new System.Drawing.Size(548, 417);
            this.dgvthuongphat.TabIndex = 3;
            this.dgvthuongphat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvthuongphat_CellClick);

            dgvthuongphat.DataSource = DangKiCaDAO.Instance.thuongphatHome();
            Properties.Settings.Default.cmndthuongphat = dgvthuongphat.Rows[0].Cells["Column12"].Value.ToString();
       
            btnthem.Enabled = true;
            btn_luu.Enabled = false;
            btnxoa.Enabled = false;
           
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int tien = Math.Abs(int.Parse(mtxttien.Text));
            if (radiothuong.Checked == false)
                tien = -tien;
            DangKiCaDAO.Instance.updatethuongphat(Properties.Settings.Default.cmndthuongphat, txtlydo.Text, dtpngay.Value,tien, Properties.Settings.Default.lydo, Convert.ToDateTime(Properties.Settings.Default.ngaythuongphat), Properties.Settings.Default.tien);
            int thang = dtpthang.Value.Month;
            int nam = dtpthang.Value.Year;
            dgvthuongphat.DataSource = DangKiCaDAO.Instance.xemthuongphat(thang, nam);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DangKiCaDAO.Instance.xoathuongphat(Properties.Settings.Default.cmndthuongphat, Properties.Settings.Default.lydo, Convert.ToDateTime(Properties.Settings.Default.ngaythuongphat), Properties.Settings.Default.tien);
            int thang = dtpthang.Value.Month;
            int nam = dtpthang.Value.Year;
            dgvthuongphat.DataSource = DangKiCaDAO.Instance.xemthuongphat(thang, nam);
        }

        private void viewluong_Click(object sender, EventArgs e)
        {
            dgvluong.DataSource = DangKiCaDAO.Instance.luong(dtpluong.Value);
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtsearch.ForeColor == Color.Gray)
                {
                    return;
                }

                DataTable data = nhanvienDAO.Instance.search(txtsearch.Text);
                dgvnhanvien.DataSource = data;
     
            }
        }

 
      
       

      

      

    
    }
}
