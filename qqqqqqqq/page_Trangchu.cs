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
using qqqqqqqq.DTO;
using System.IO;
using Bunifu.Framework.UI;

namespace qqqqqqqq
{
    public partial class page_Trangchu :UserControl
    {
        public page_Trangchu()
        {
            InitializeComponent();
            Loadcomboloai();
            loadban();

            DataTable data = ThucDonDAO.Instance.load_searchHome();
            AutoCompleteStringCollection duong = new AutoCompleteStringCollection();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                duong.Add(data.Rows[i][0].ToString());
            }
            textBox1.AutoCompleteCustomSource = duong;
        }

      

        private void btntd_click(object sender, EventArgs e)
        {
            int idtd = ((sender as Button).Tag as ThucDon).Matd;
          
        }
        private void loadban()
        {

            flpTable.Controls.Clear();

            List<table> tableList = BanDAO.Instance.loadbanList();
            foreach (table item in tableList)
            {

                Button btn = new Button()
                {
                    Width = 100,
                    Height = 100,


                };

                btn.Click += btn_click;

        
                btn.Tag = item;
                btn.Tag = item;
                btn.Image = global::qqqqqqqq.Properties.Resources.Table_48px;
                btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;

                //  btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
                btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;

                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;




                btn.BackColor = Color.White;
                btn.Text = item.Ten + "(" + item.Loaiban + ")" + Environment.NewLine + item.Trangthai;
                if (item.Trangthai == "CÓ NGƯỜI")
                    btn.BackColor = Color.Red;

                flpTable.Controls.Add(btn);


            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            int idtable = ((sender as Button).Tag as table).ID;
            dgvhoadon.Tag = (sender as Button).Tag;
            showHoadondgv(idtable);
            btnban.Text = ((sender as Button).Tag as table).Ten;
            Properties.Settings.Default.idban = idtable;
         //   Properties.Settings.Default.idhoadon = 1;
            int idhoadon = HoaDonDAO.Instance.hoadonban(idtable);
            if(idhoadon != -1)
                Properties.Settings.Default.idhoadon = idhoadon;
        }

    
  

        private void showHoadondgv(int id)
        {
    

            dgvhoadon.DataSource = htHoaDonDAO.Instance.Hoadonban(id);

            //foreach (DataGridViewRow row in dgvhoadon.Rows)
            //{
            //    row.Height = 35; //(dataGridView1.ClientRectangle.Height - dataGridView1.ColumnHeadersHeight) / dataGridView1.Rows.Count;
            //}
            
       

           int tien = dgvhoadon.Rows.Count;
           float thanhtien = 0;
           for (int i = 0; i < tien; i++)
           {
               if (int.Parse(dgvhoadon.Rows[i].Cells["Column6"].Value.ToString()) == 1)
               {
                   
                   dgvhoadon.Rows[i].Cells["Column6"].Value = "chưa phục vụ";
                  // dgvhoadon.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                
               }
               else if (int.Parse(dgvhoadon.Rows[i].Cells["Column6"].Value.ToString()) == 2)
               {

                   dgvhoadon.Rows[i].Cells["Column6"].Value = "đã phục vụ";
                  // dgvhoadon.Rows[i].DefaultCellStyle.BackColor = Color.White;
               }
               else if (int.Parse(dgvhoadon.Rows[i].Cells["Column6"].Value.ToString()) == 3)
               {

                   dgvhoadon.Rows[i].Cells["Column6"].Value = "phục vụ";
                   dgvhoadon.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
               }
               thanhtien += int.Parse(dgvhoadon.Rows[i].Cells["Column5"].Value.ToString());
               
            
           }
           txttien.Text = thanhtien.ToString();
        }
        private void Loadcomboloai()
        {
            List<LoaiTd> dsLoaitd = LoaiTDAO.Instance.ListLoaitd();
            cbloaitd.DataSource = dsLoaitd;
            cbloaitd.DisplayMember = "TENLOAITD";
             cbloaitd.ValueMember = "MALOAITD";
        }
        //private void LoadcomboTD(int id)
        //{
        //    List<ThucDon> dsthucdon = ThucDonDAO.Instance.listThucdon(id);
        //    cbthucdon.DataSource = dsthucdon;
        //    cbthucdon.DisplayMember = "TENTD";
        //    cbthucdon.ValueMember = "MALOAITD";

        //}

        private void cbloaitd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            LoaiTd selected = cb.SelectedItem as LoaiTd;
            id = selected.Maloaitd;
            cbthucdon.Properties.Items.Clear();
            cbthucdon.EditValue = null;
            imageCollection1.Images.Clear();
            //LoadcomboTD(id);

            loadcomboimage(id);
          
            
        }

        private void loadcomboimage(int id)
        {
            
         
            string str = "SELECT * FROM thucdon WHERE maloaitd = '"+id+"' and trang_thai = 1";
            DataTable datatable = new DataTable();
            datatable = Dataprovider.Instance.ExecuteQuery(str);
             
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(datatable.Rows[i]["anh"]);
                MemoryStream mem = new MemoryStream(data);
                Image img = Image.FromStream(mem);
                //   imageList1.Images.Add(img);
                imageCollection1.Images.Add(img);
                AddItems1(cbthucdon, imageCollection1, (int)datatable.Rows[i]["matd"], datatable.Rows[i]["tentd"].ToString(), i);
            }
        }

        private void AddItems1(DevExpress.XtraEditors.ImageComboBoxEdit editor, DevExpress.Utils.ImageCollection imgList, int i, string tentd, int index)
        {


            editor.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(tentd, i, index));
            editor.Properties.SmallImages = imgList;
        }


        private void btnthem_Click(object sender, EventArgs e)
        {

            try
         {
                string user = Properties.Settings.Default.user;
                table tb = dgvhoadon.Tag as table;
                if (tb == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Bạn cần chọn bàn trước khi thêm", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    return;
                }
                int idhoadon = HoaDonDAO.Instance.hoadonban(tb.ID);
                int _thucdon = (int)cbthucdon.EditValue;
                DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT gia FROM thucdon WHERE matd = " + _thucdon + "");
                int _gia = int.Parse(data.Rows[0][0].ToString());
                int _sl = (int)nupconut.Value;
                if (idhoadon == -1)
                {
                    HoaDonDAO.Instance.insertHd(tb.ID, user);
                    HoaDonInfoDAO.Instance.insertHdInfo(HoaDonDAO.Instance.maxHoadon(), _thucdon, _sl, _gia,Properties.Settings.Default.idct);
                }
                else
                {

                    HoaDonInfoDAO.Instance.insertHdInfo(idhoadon, _thucdon, _sl, _gia, Properties.Settings.Default.idct);
                   // chebienDAO.Instance.addphache(_thucdon, _sl, "");
                }
                showHoadondgv(tb.ID);


                loadban();

              


          }
            catch
           {
              MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
                Properties.Settings.Default.phache_thucdon = false;

       
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                table table = dgvhoadon.Tag as table;
                int tien = int.Parse(txttien.Text);
                float giamgia = float.Parse(txtgiamgia.Text);
                float b = tien / 100;
                float t = tien - b * giamgia;
                int tong = (int)t;


                int mahd = HoaDonDAO.Instance.hoadonban(table.ID);
                if (mahd != -1)
                {
                    if (MetroFramework.MetroMessageBox.Show(this,"Bạn thật sự muốn thanh toán cho " + table.Ten + " ! \n Tổng tiền - (Tổng Tiền * Giảm giá / 100) \n= " + tien + " - (" + tien + " * " + giamgia + "/100) = " + tong + " ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                    {
                       
                        HoaDonDAO.Instance.checkout(mahd, tong, giamgia);
                        mesage.show();
                        Properties.Settings.Default.reportMAHD = mahd;
                        report frm = new report();
                        frm.ShowDialog();
                        showHoadondgv(table.ID);
                        loadban();
                    }
                }
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this,"Không Thành Công! Vui Lòng Kiểm Tra Lại Thông Tin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
            }
        }

        private void btnban_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {



        }

        private void themthucdon1_Load(object sender, EventArgs e)
        {

        }

        private void cbthucdon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MyDbContextDataContext mydb = new MyDbContextDataContext();
            //int p = (cbthucdon.SelectedItem as ThucDon).Matd;
          
            //THUCDON td = mydb.THUCDONs.Where(t => t.MATD == p).SingleOrDefault();
           
            //if (td == null) return;

            //MemoryStream memoryStream = new MemoryStream((byte[])td.anh.ToArray());
            //Image img = Image.FromStream(memoryStream);
            //if (img == null)
            //    return;
            //else
            //    pictureBox1.Image = img;

        }

        private void dgvhoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            if (r >= 0)
            {
                int p = int.Parse(dgvhoadon.Rows[r].Cells["Column1"].Value.ToString());
                cbloaitd.SelectedValue = int.Parse(dgvhoadon.Rows[r].Cells["Column8"].Value.ToString());
                cbthucdon.EditValue = int.Parse(dgvhoadon.Rows[r].Cells["Column1"].Value.ToString());
                if (c == 0)
                {
                    Properties.Settings.Default.idthucdon = int.Parse(dgvhoadon.Rows[r].Cells["Column1"].Value.ToString());
                    Properties.Settings.Default.soluong = int.Parse(dgvhoadon.Rows[r].Cells["Column3"].Value.ToString());
                    Properties.Settings.Default.idct = int.Parse(dgvhoadon.Rows[r].Cells["Column10"].Value.ToString());
             
                    suahoadon frm = new suahoadon();
                    frm.FormClosed += new FormClosedEventHandler(dongform);
                    frm.ShowDialog();
               
                }
            }
        }

        private void dongform(object sender, FormClosedEventArgs e)
        {
            
            showHoadondgv(Properties.Settings.Default.idban);
            this.Show();
        }

        private void dgvhoadon_MouseHover(object sender, EventArgs e)
        {
            //var p = this.dgvhoadon.PointToClient(Cursor.Position);
            //var info = this.dgvhoadon.HitTest(p.X, p.Y);
            //int r = info.RowIndex;
            //int c = info.ColumnIndex;

            //if (r >= 0)
            //{
            //    string str = dgvhoadon.Rows[r].Cells["Column7"].Value.ToString();
            //    SetToolTipText(dgvhoadon.Rows[r],str);
            //}
        }
        private void SetToolTipText(DataGridViewRow row, String message)
        {
            foreach (DataGridViewCell cell in row.Cells)
                cell.ToolTipText = message;
        }

        private void dgvhoadon_MouseMove(object sender, MouseEventArgs e)
        {
            var p = this.dgvhoadon.PointToClient(Cursor.Position);
            var info = this.dgvhoadon.HitTest(p.X, p.Y);
            int r = info.RowIndex;
            int c = info.ColumnIndex;

            if (r >= 0)
            {
                string str1 = dgvhoadon.Rows[r].Cells["Column7"].Value.ToString();
                string str = "";
                if (str1.Trim().ToString() == "")
                    str = "Mặc định";
                else
                    str = str1;
                SetToolTipText(dgvhoadon.Rows[r], str);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            if (Properties.Settings.Default.themban_ == false)
            {
                loadban();
                Properties.Settings.Default.themban_ = true;

            }

            if (Properties.Settings.Default.phache_ == false)
            {
                
                table tb = dgvhoadon.Tag as table;
                if(tb != null)
                showHoadondgv(tb.ID);
                Properties.Settings.Default.phache_ = true;

            }



        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tìm kiếm...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                int t = ThucDonDAO.Instance.timkiemthucdon(textBox1.Text);
                cbthucdon.EditValue = t;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (textBox1.Text != null)
                {
                    int t = ThucDonDAO.Instance.timkiemthucdon(textBox1.Text);
                    cbthucdon.EditValue = t;
                }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



 
   

 

   



     
    }
}
