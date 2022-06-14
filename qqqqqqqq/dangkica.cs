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
    public partial class dangkica : Form
    {
        public dangkica()
        {
            InitializeComponent();
            loadcombobox();
            lbl2.Text = Properties.Settings.Default.tennhanvien;
            cbca.SelectedValue = Properties.Settings.Default.maca;

        }

        private void loadcombobox()
        {
            cbca.DataSource = CaDAO.Instance.listca();
            cbca.DisplayMember = "tenca";
            cbca.ValueMember = "maca";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DangKiCaDAO.Instance.updatedkCa(Properties.Settings.Default.maca, Properties.Settings.Default.cmndca, int.Parse(cbca.SelectedValue.ToString()));
            this.Close();
        }
     
    }
}
