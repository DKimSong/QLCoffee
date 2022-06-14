using Microsoft.Reporting.WinForms;
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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CAFE_netDataSet.pr_reportHD' table. You can move, or remove it, as needed.
            this.pr_reportHDTableAdapter.Fill(this._CAFE_netDataSet.pr_reportHD,Properties.Settings.Default.reportMAHD);
            // TODO: This line of code loads data into the '_CAFE_netDataSet.vi_hoadon' table. You can move, or remove it, as needed.
        

            this.reportViewer1.RefreshReport();

       
        }
    }
}
