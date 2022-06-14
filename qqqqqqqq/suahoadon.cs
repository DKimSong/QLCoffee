using qqqqqqqq.DAO;
using qqqqqqqq.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qqqqqqqq
{
    public partial class suahoadon : Form
    {
        public suahoadon()
        {
            InitializeComponent();
            loadcbloai();
            loaddata();
          
      
        }

        private void loaddata()
        {
            try
            {
                cbloaitd.SelectedValue = LoaiTDAO.Instance.maloaitd(Properties.Settings.Default.idthucdon);
                cbthucdon.EditValue = Properties.Settings.Default.idthucdon;
                nupconut.Value = Properties.Settings.Default.soluong;
                DataTable data = HoaDonInfoDAO.Instance.ghichu_tt(Properties.Settings.Default.idhoadon, Properties.Settings.Default.idthucdon);
                cbtrangthai.SelectedIndex = int.Parse(data.Rows[0][1].ToString()) - 1;
                txtghichu.Text = data.Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại.");
            }
             
        }

    
        private void loadcbloai()
        {
            List<LoaiTd> dsLoaitd = LoaiTDAO.Instance.ListLoaitd();
            cbloaitd.DataSource = dsLoaitd;
            cbloaitd.DisplayMember = "TENLOAITD";
            cbloaitd.ValueMember = "MALOAITD";

        }

        private void loadcomboimage(int id)
        {


            string str = "SELECT * FROM thucdon WHERE maloaitd = '" + id + "' and trang_thai = 1";
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonInfoDAO.Instance.suacthoadon(Properties.Settings.Default.idhoadon, Properties.Settings.Default.idthucdon, (int)cbthucdon.EditValue, (int)nupconut.Value, 0, txtghichu.Text, cbtrangthai.SelectedIndex + 1);
                MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.Close();
            }
            catch
            {
              MessageBox.Show("Lỗi! Vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Properties.Settings.Default.phache_thucdon = false;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
