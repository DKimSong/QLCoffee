using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using qqqqqqqq.DAO;
using System.IO;
using System.Drawing.Imaging;


namespace qqqqqqqq
{
    public partial class page_thucdon : UserControl
    {
        public page_thucdon()
        {
            InitializeComponent();
            Napdatalist();
            Loadcomboloai();
            
         //   bunifuFlatButton1.Enabled = false;
            bunifuFlatButton2.Enabled = false;
            bunifuFlatButton3.Enabled = false;
           
            
           
        }

        private void Loadcomboloai()
        {
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery("SELECT *FROM dbo.LOAITHUCDON");
            cbloai.DataSource = data;
            cbloai.DisplayMember = "tenloaitd";
            cbloai.ValueMember = "maloaitd";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
   
         
        }
        

        private void Napdatalist()
        {
            Dataprovider.Instance.openCon();

            SqlCommand commandloai = new SqlCommand();
            commandloai.CommandType = CommandType.Text;
            commandloai.CommandText = "select *from loaithucdon";
            commandloai.Connection = Dataprovider.Instance.conn;
            lvthucdon.Groups.Clear();
            lvthucdon.Items.Clear();
            lvthucdon.Groups.Clear();
            SqlDataReader readerloai = commandloai.ExecuteReader();
            while (readerloai.Read())
            {
                ListViewGroup lvl = new ListViewGroup(readerloai.GetString(1));
                lvl.Tag = readerloai.GetInt32(0);
                lvthucdon.Groups.Add(lvl);

            }
            readerloai.Close();
            foreach (ListViewGroup lvl in lvthucdon.Groups)
            {
                string maloai = lvl.Tag.ToString();


                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select matd,tentd,gia from thucdon where trang_thai =1 and maloaitd = '"+maloai+"'";
                command.Connection = Dataprovider.Instance.conn;

                SqlDataReader reader = command.ExecuteReader();

                int stt = 1;

                while (reader.Read())
                {
                    string matd = reader.GetInt32(0).ToString();
                    string tentd = reader.GetString(1);
                    string gia = reader.GetInt32(2).ToString();
                    ListViewItem lvi = new ListViewItem(maloai);
              
                    lvi.SubItems.Add(stt + "");
                    lvi.SubItems.Add(tentd);
                   lvi.SubItems.Add(gia);
                   lvi.SubItems.Add(matd);
                    lvthucdon.Items.Add(lvi);
                    lvi.Group = lvl;
                    stt++;

                }
                reader.Close();
                
            }
            Dataprovider.Instance.conn.Close();
        }

        private void lvthucdon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvthucdon.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                bunifuFlatButton1.Text = "Làm mới";
                bunifuFlatButton2.Enabled = true;
                bunifuFlatButton3.Enabled = true;
                pictureBox1.Refresh();
                ListViewItem item = lvthucdon.SelectedItems[0];
                cbloai.SelectedValue = item.SubItems[0].Text;
                txtten.Text = item.SubItems[2].Text;
                txtgia.Text = item.SubItems[3].Text;

              
           
                MyDbContextDataContext mydb = new MyDbContextDataContext();
                THUCDON td = mydb.THUCDONs.Where(t => t.MATD == int.Parse(item.SubItems[4].Text)).FirstOrDefault();
                if (td == null) return;
              
                MemoryStream memoryStream = new MemoryStream((byte[])td.anh.ToArray());
                Image img = Image.FromStream(memoryStream);
                if (img == null)
                    return;
                else
                pictureBox1.Image = img;

            }
        }

        private void btnimage_Click(object sender, EventArgs e)
        {
          
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


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuFlatButton1.Text = bunifuFlatButton1.Text.Trim() == "Làm mới" ? "Thêm" : "Làm mới";
                if (bunifuFlatButton1.Text == "Thêm")
                {
                    errorMessage.Clear();
                    txtten.Text = "";
                    txtgia.Text = "";
                    bunifuFlatButton2.Enabled = false;
                    bunifuFlatButton3.Enabled = false;

                }
                else if (bunifuFlatButton1.Text == "Làm mới")
                {

                    errorMessage.Clear();
                    string ten = txtten.Text.Trim();
                    string gia = txtgia.Text.Trim();
                    Image img = pictureBox1.Image;

                    if (string.IsNullOrEmpty(ten))
                    {
                        errorMessage.SetError(txtten, "Bạn cần nhập tên tên đồ ăn !");
                        txtten.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(gia))
                    {
                        errorMessage.SetError(txtgia, "Bạn cần nhập giá đồ ăn ! ");
                        txtgia.Focus();
                        return;
                    }

                    else
                    {

                        MemoryStream stream = new MemoryStream();
                        pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
                        MyDbContextDataContext myDB = new MyDbContextDataContext();
                        THUCDON td = new THUCDON();
                        td.MALOAITD = (int)cbloai.SelectedValue;
                        td.TENTD = txtten.Text;
                        td.GIA = int.Parse(txtgia.Text);
                        td.anh = stream.ToArray();
                        td.TRANG_THAI = true;
                        myDB.THUCDONs.InsertOnSubmit(td);
                        myDB.SubmitChanges();
                        Napdatalist();
                        MessageBox.Show("Đã Thêm Thành Công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        bunifuFlatButton2.Enabled = false;
                        bunifuFlatButton3.Enabled = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thêm được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
    

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try { 
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
            MyDbContextDataContext myDB = new MyDbContextDataContext();

            int t = (int)cbloai.SelectedValue;
            string ten = txtten.Text;
            int gia = int.Parse(txtgia.Text);
            Image img = pictureBox1.Image;
            ListViewItem item = lvthucdon.SelectedItems[0];
          

            THUCDON td = myDB.THUCDONs.Where(p => p.MATD.Equals((int.Parse(item.SubItems[4].Text)))).FirstOrDefault();
            td.TENTD = ten;
            td.MALOAITD = t;
            td.GIA = gia;
            td.anh = stream.ToArray();
            td.TRANG_THAI = true;


         
            myDB.SubmitChanges();
            Napdatalist();
            MessageBox.Show("Đã Sửa Thành Công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            bunifuFlatButton3.Enabled = false;
            bunifuFlatButton2.Enabled = false;
            }
            catch{
                  MessageBox.Show("Không sửa được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try{
            ListViewItem item = lvthucdon.SelectedItems[0];

          //  HoaDonInfoDAO.Instance.deletedoadoninfo(int.Parse(item.SubItems[4].Text));
            MyDbContextDataContext myDB = new MyDbContextDataContext();
           


            THUCDON td = myDB.THUCDONs.Where(p => p.MATD.Equals((int.Parse(item.SubItems[4].Text)))).FirstOrDefault();
            td.TRANG_THAI = false;

            myDB.SubmitChanges();
         
            Napdatalist();
            MessageBox.Show("Đã Xóa Thành Công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            bunifuFlatButton2.Enabled = false;
            bunifuFlatButton3.Enabled = false;
            }
            catch{
                  MessageBox.Show("Không xóa được! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            themloaiTD frm = new themloaiTD();
            frm.ShowDialog();
        }

        private void cbloai_Click(object sender, EventArgs e)
        {
            Loadcomboloai();
        }

       

            
    }
   
  

        
}

        
    

