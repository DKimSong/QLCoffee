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
using System.Globalization;
using System.Threading;

namespace qqqqqqqq
{
    public partial class page_tran : UserControl
    {
        public page_tran()
        {
            InitializeComponent();
            Loadcomboloai();
            loadban();
            Loadcomboloai();
       
           
            
        }

        private void loadban()
        {
            flpTable.Controls.Clear();
          List <table>  tableList =  BanDAO.Instance.loadbanList();
          foreach (table item in tableList)
          {
              Button btn = new Button()
              {
                  Width = 100,
                  Height = 100
              };
              btn.Click += btn_click;
              btn.Tag = item;
              btn.Tag = item;

              btn.BackColor = Color.Green;
              btn.Text = item.Ten +"("+ item.Loaiban+")" + Environment.NewLine + item.Trangthai;
              if (item.Trangthai == "BÀN HỎNG")
                  btn.BackColor = Color.DarkGray;
              if (item.Trangthai == "CÓ KHÁCH")
                  btn.BackColor = Color.Red;
              if (item.Trangthai == "BÀN CHƯA DỌN")
                  btn.BackColor = Color.Yellow;

              flpTable.Controls.Add(btn);
          }
        }

        private void btn_click(object sender, EventArgs e)
        {
            int idtable = ((sender as Button).Tag as table).ID;
            lvhoadon.Tag = (sender as Button).Tag;
            showHoadon(idtable);
            
            btnban.Text = ((sender as Button).Tag as table).Ten;
          

        }

        private void showHoadon(int id)
        {
            lvhoadon.Items.Clear();

            List<htHoadon> listhoadoninfo = htHoaDonDAO.Instance.Hoadonban(id);
            int tien = 0;

            foreach (htHoadon item in listhoadoninfo)
            {
                ListViewItem lvitem = new ListViewItem(item.Matd.ToString());
                lvitem.SubItems.Add(item.Maloaitd.ToString());
                lvitem.SubItems.Add(item.Thucan.ToString());
                lvitem.SubItems.Add(item.Count.ToString());
                lvitem.SubItems.Add(item.Gia.ToString());
                lvitem.SubItems.Add(item.Thanhtien.ToString());

                lvhoadon.Items.Add(lvitem);
                tien += item.Thanhtien;
            }
           // CultureInfo culture = new CultureInfo("vi");

            txttien.Text = tien.ToString();
            
        }


        private void Loadcomboloai()
        {
            List<LoaiTd> dsLoaitd = LoaiTDAO.Instance.ListLoaitd();
            cbloaitd.DataSource = dsLoaitd;
            cbloaitd.DisplayMember = "TENLOAITD";
         //   cbloaitd.SelectedValue = "MALOATTD";
        }






        private void LoadcomboTD(int id)
        {
            List<ThucDon> dsthucdon = ThucDonDAO.Instance.listThucdon(id);
            cbthucdon.DataSource = dsthucdon;
            cbthucdon.DisplayMember = "TENTD";
            cbthucdon.ValueMember = "MALOAITD";
           
        }

        private void cbloaitd_SelectedValueChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            LoaiTd selected = cb.SelectedItem as LoaiTd;
            id = selected.Maloaitd;

            LoadcomboTD(id);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string user = Properties.Settings.Default.user;
                table tb = lvhoadon.Tag as table;
                int idhoadon = HoaDonDAO.Instance.hoadonban(tb.ID);
                int _thucdon = (cbthucdon.SelectedItem as ThucDon).Matd;
                int _gia = (cbthucdon.SelectedItem as ThucDon).Gia;
                int _sl = (int)nupconut.Value;
                if (idhoadon == -1)
                {
                    HoaDonDAO.Instance.insertHd(tb.ID, user);
                    HoaDonInfoDAO.Instance.insertHdInfo(HoaDonDAO.Instance.maxHoadon(), _thucdon, _sl, _gia);
                }
                else
                {
                    HoaDonInfoDAO.Instance.insertHdInfo(idhoadon, _thucdon, _sl, _gia);
                }
                showHoadon(tb.ID);
            }
            catch {
                MessageBox.Show("Không Thành Công! Vui Lòng Kiểm Tra Lại Thông Tin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadban();
         }

        private void lvhoadon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvhoadon.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = lvhoadon.SelectedItems[0];
               
              //  cbthucdon.SelectedValue = 4;
             //   MessageBox.Show(item.SubItems[0].ToString());

            }
           
        }

        private void lvhoadon_MouseClick(object sender, MouseEventArgs e)
        {
           

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

            table table = lvhoadon.Tag as table;
            int tien =  int.Parse(txttien.Text);
            float giamgia = float.Parse(txtgiamgia.Text);
            float b = tien / 100;

            float t = tien - b * giamgia;
            int tong = (int)t;


            int mahd = HoaDonDAO.Instance.hoadonban(table.ID);
            if (mahd != -1)
            {
                if (MessageBox.Show("Bạn thật sự muốn thanh toán cho " + table.Ten + " ! \n Tổng tiền - (Tổng Tiền * Giảm giá / 100) \n= "+tien+" - ("+tien+" * "+giamgia+"/100) = "+tong+" ", "Thông Báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonDAO.Instance.checkout(mahd, tong, giamgia);
                    showHoadon(table.ID);
                    loadban();
                }
            }
        }

        private void lvhoadon_Click(object sender, EventArgs e)
        {
            //if (lvhoadon.SelectedItems.Count == 0)
            //{
            //    return;
            //}
            //else
            //{
            //    ListViewItem item = lvhoadon.SelectedItems[0];
            //    cbloaitd.SelectedValue = 3;
            //    MessageBox.Show(item.SubItems[0].ToString());

            //}
        }

       
       
    }
}
