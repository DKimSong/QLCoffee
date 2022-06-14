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
    public partial class page_phache : UserControl
    {
        public page_phache()
        {
            InitializeComponent();
            loaddgv();
            cbphache.SelectedIndex = 0;

        }

        private void loaddgv()
        {
            dgvchebien.DataSource = chebienDAO.Instance.htchebien();
        }

        private void dgvchebien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            if (r >= 0)
            {
                if (c == 0)
                {
           
                    chebienDAO.Instance.chuyenphache(int.Parse(dgvchebien.Rows[r].Cells["Column6"].Value.ToString()));
                    Properties.Settings.Default.phache_ = false;
                    
                
                    if (cbphache.SelectedIndex == 0)
                    {
                        dgvchebien.DataSource = chebienDAO.Instance.htchebien();
                    }
                    if (cbphache.SelectedIndex == 1)
                    {
                        dgvchebien.DataSource = chebienDAO.Instance.daphache();
                    }
                    if (cbphache.SelectedIndex == 2)
                    {
                        dgvchebien.DataSource = chebienDAO.Instance.allphache();
                    }


                }
            }
        }

        private void cbphache_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbphache_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbphache.SelectedIndex == 0)
            {

                dgvchebien.DataSource = chebienDAO.Instance.htchebien();
                dgvchebien.Columns[0].Visible = true;
            }
            if (cbphache.SelectedIndex == 1)
            {
            
                dgvchebien.DataSource =  chebienDAO.Instance.daphache();
                dgvchebien.Columns[0].Visible = false;
            }
            if (cbphache.SelectedIndex == 2)
            {
                dgvchebien.DataSource = chebienDAO.Instance.allphache();
                
                dgvchebien.Columns[0].Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            if (Properties.Settings.Default.phache_thucdon == false)
            {
                loaddgv();
                Properties.Settings.Default.phache_thucdon = true;
   
            }
          
        }

    }
}
