
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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            mau();
           
           
            
        }

        private void mau()
        {
         
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }
        private void tmr_Tick(object sender, EventArgs e)
        {

            Color TruocDo = label2.ForeColor;
            Color[] clr = new Color[] 
{ 
    Color.Red
    ,Color.Yellow
    ,Color.Orange
    ,Color.Green
    ,Color.Blue
    ,Color.Indigo
    ,Color.Purple
    ,Color.Aqua
    ,Color.BurlyWood
    ,Color.DarkViolet
    ,Color.PaleVioletRed
    ,Color.PaleGreen
};
            for (Int32 i = 0; i < clr.Length; i++)
                if (label2.ForeColor == clr[i])
                {
                    label2.ForeColor = (i == clr.Length - 1 ? clr[0] : clr[i + 1]);
                    break;
                }
            if (label2.ForeColor == TruocDo)
                label2.ForeColor = clr[0];
        }
        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this,"Bạn có thật sự muốn thoát !", "Thông Báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
 


        private void bunifuGradientPanel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MoveForm.Grab(this);

           
           
        }

        private void bunifuGradientPanel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            MoveForm.Release();
        }

        private void bunifuGradientPanel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            MoveForm.MoveObject();
        }

     
        bool login(string name, string pass)
        {
            return loginDAO.Instance.checklogin(name, pass);

        }
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtpass_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
         
            

            errorMessage.Clear();
            string username = txtname.Text.Trim();
            string pass = txtpass.Text.Trim();

            if (string.IsNullOrEmpty(username)|| txtname.ForeColor == Color.Gray)
            {
                errorMessage.SetError(txtname, "Bạn cần nhập tên tài khoản !");
                txtname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(pass) || txtpass.ForeColor==Color.Gray)
            {
                errorMessage.SetError(txtpass, "Bạn cần nhập mật khẩu ! ");
                txtpass.Focus();
                return;
            }


            else if (login(username, pass))
            {
                Properties.Settings.Default.user = txtname.Text;
                Properties.Settings.Default.pass = txtpass.Text;
                Properties.Settings.Default.Save();

                //FormMain frm = new FormMain();
                //this.Hide();
                //frm.ShowDialog();
                progressBar1.Visible = true;
                timer1.Start();


            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"Sai tên đăng nhập hoặc mật khẩu! \n Vui lòng kiểm tra lại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = (Convert.ToInt32(progressBar1.Value)) + 10 ;
            if ((Convert.ToInt32(progressBar1.Value) + 10) > 80)
            {
                timer1.Stop();

                FormMain frm = new FormMain();
                this.Hide();
                frm.ShowDialog();

            }
            

        }

      
   

        private void txtpass_KeyDown(object sender, EventArgs e)
        {

        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Tên đăng nhập...")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.Black;

            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Tên đăng nhập...";
                txtname.ForeColor = Color.Gray;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Mật khẩu...";
                txtpass.ForeColor = Color.Gray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Mật khẩu...")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Black;
            }
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorMessage.Clear();
                string username = txtname.Text.Trim();
                string pass = txtpass.Text.Trim();

                if (string.IsNullOrEmpty(username) || txtname.ForeColor == Color.Gray)
                {
                    errorMessage.SetError(txtname, "Bạn cần nhập tên tài khoản !");
                    txtname.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(pass) || txtpass.ForeColor == Color.Gray)
                {
                    errorMessage.SetError(txtpass, "Bạn cần nhập mật khẩu ! ");
                    txtpass.Focus();
                    return;
                }


                else if (login(username, pass))
                {
                    Properties.Settings.Default.user = txtname.Text;
                    Properties.Settings.Default.pass = txtpass.Text;
                    Properties.Settings.Default.Save();

                    //FormMain frm = new FormMain();
                    //this.Hide();
                    //frm.ShowDialog();
                    progressBar1.Visible = true;
                    timer1.Start();


                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Sai tên đăng nhập hoặc mật khẩu! \n Vui lòng kiểm tra lại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorMessage.Clear();
                string username = txtname.Text.Trim();
                string pass = txtpass.Text.Trim();

                if (string.IsNullOrEmpty(username) || txtname.ForeColor == Color.Gray)
                {
                    errorMessage.SetError(txtname, "Bạn cần nhập tên tài khoản !");
                    txtname.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(pass) || txtpass.ForeColor == Color.Gray)
                {
                    errorMessage.SetError(txtpass, "Bạn cần nhập mật khẩu ! ");
                    txtpass.Focus();
                    return;
                }


                else if (login(username, pass))
                {
                    Properties.Settings.Default.user = txtname.Text;
                    Properties.Settings.Default.pass = txtpass.Text;
                    Properties.Settings.Default.Save();

                    //FormMain frm = new FormMain();
                    //this.Hide();
                    //frm.ShowDialog();
                    progressBar1.Visible = true;
                    timer1.Start();


                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Sai tên đăng nhập hoặc mật khẩu! \n Vui lòng kiểm tra lại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void chkpass_OnChange(object sender, EventArgs e)
        {
            if (chkpass.Checked == true)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

    



       
    }

}
