using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using qqqqqqqq.DAO;
using DevExpress.Utils;
using System.Windows.Forms.DataVisualization.Charting;

namespace qqqqqqqq
{
    public partial class page_Thongke : UserControl
    {
        public page_Thongke()
        {
            InitializeComponent();

            
             

        }



        private void AddItems1(ImageComboBoxEdit editor, ImageCollection imgList,int i,string tentd,int index)
        {
         
          
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            this.pr_hoadonngayTableAdapter.Fill(this._CAFE_netDataSet.pr_hoadonngay, dateTimePicker1.Value);
            this.reportViewer1.RefreshReport();
            
        }

        private void tabNavigationPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.pr_doanhthuHangTableAdapter.Fill(this._CAFE_netDataSet.pr_doanhthuHang, dateTimePicker2.Value, 1);
                this.reportViewer2.RefreshReport();
            }
            else
            {
                this.pr_doanhthuHangTableAdapter.Fill(this._CAFE_netDataSet.pr_doanhthuHang, dateTimePicker2.Value, 0);
                this.reportViewer2.RefreshReport();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.pr_chartTableAdapter.Fill(this._CAFE_netDataSet.pr_chart, dateTimePicker3.Value);
            this.reportViewer3.RefreshReport();
        }


    }
}
