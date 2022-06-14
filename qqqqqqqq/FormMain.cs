using qqqqqqqq.DAO;
using qqqqqqqq.DTO;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            timer1.Start();

            page_Trangchu1.BringToFront();

            label1.Text = "Xin Chào : " + Properties.Settings.Default.user + " (" + Properties.Settings.Default.tencv+")";
            
            bool checkbanhang = ChucVuDAO.Instance.checkbanhang(Properties.Settings.Default.chucvu);
            if (checkbanhang == false)
            {
                btntrangchu.Visible = false;
                page_Trangchu1.Visible = false;
                
            }
            bool checkphache = ChucVuDAO.Instance.checkphache(Properties.Settings.Default.chucvu);
            if (checkphache == false)
            {
                btnphache.Visible = false;
                page_phache1.Visible = false;
            }

            bool checkthucdon = ChucVuDAO.Instance.checkthucdon(Properties.Settings.Default.chucvu);
            if (checkthucdon == false)
            {
                btnthucdon.Visible = false;
                page_thucdon2.Visible = false;
            }

            bool checknhanvien = ChucVuDAO.Instance.checknhanvien(Properties.Settings.Default.chucvu);
            if (checknhanvien == false)
            {
                btnnhanvien.Visible = false;
                pagenhanVien1.Visible = false;
            }

            bool checkhethong = ChucVuDAO.Instance.checkhethong(Properties.Settings.Default.chucvu);
            if (checkhethong == false)
            {
                btnhethong.Visible = false;
                page_hethong1.Visible = false;
            }

            bool checkthongke = ChucVuDAO.Instance.checkthongke(Properties.Settings.Default.chucvu);
            if (checkthongke == false)
            {
                btnthongke.Visible = false;
                page_Thongke1.Visible = false;
            }
         
           
        }
        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm.Grab(this);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MoveForm.Release();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm.MoveObject();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Bạn có thật sự muốn thoát !", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                label1.Text = "";
            }
          
         
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            if (sideMenu.Width >= 150)
            {
                logo.Location = new Point(5, 21);
                logo.Size = new Size(42, 40);

                sideMenu.Width = 50;
                label2.Visible = false;
                
            }
            else
            {
                logo.Location = new Point(22, 6);
                logo.Size = new Size(107, 57);
                sideMenu.Width = 150;
                label2.Visible = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            page_Trangchu1.BringToFront();
            page_Trangchu1.Visible = true;
           


            bunifuSeparator2.Height = btntrangchu.Height;
            bunifuSeparator2.Top = btntrangchu.Top;

            
            

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            page_phache1.BringToFront();

            page_phache1.Visible = true;

            bunifuSeparator2.Height = btnphache.Height;
            bunifuSeparator2.Top = btnphache.Top;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           page_thucdon2.BringToFront();
           page_thucdon2.Visible = true;

        

            bunifuSeparator2.Height = btnthucdon.Height;
            bunifuSeparator2.Top = btnthucdon.Top;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            pagenhanVien1.BringToFront();
          //  bunifuSeparator2.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top;

            pagenhanVien1.Visible = true;
            bunifuSeparator2.Height = btnnhanvien.Height;
            bunifuSeparator2.Top = btnnhanvien.Top;
        }

        private void page_Thongke1_Load(object sender, EventArgs e)
        {

        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            page_thucdon2.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = (DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).ToString();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Bạn có thật sự muốn đăng xuất !", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
                label1.Text = "";
            }


            
        }

        private void page_thucdon2_Load(object sender, EventArgs e)
        {

        }

      

        private void btnhethong_Click_1(object sender, EventArgs e)
        {
    
            page_hethong1.BringToFront();

            page_hethong1.Visible = true;
            bunifuSeparator2.Height = btnhethong.Height;
            bunifuSeparator2.Top = btnhethong.Top;
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            page_Thongke1.BringToFront();
            page_Thongke1.Visible = true;

            bunifuSeparator2.Height = btnthongke.Height;
            bunifuSeparator2.Top = btnthongke.Top;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            doipass frm = new doipass();
            frm.ShowDialog();
        }

   


















    }
}
