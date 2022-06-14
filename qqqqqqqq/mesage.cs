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
    public partial class mesage : Form
    {
        public mesage()
        {
            InitializeComponent();
        }

        private void mesage_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

        }

        private void bunifuFormFadeTransition1_TransitionEnd(object sender, EventArgs e)
        {
            icon_delay.Start();
            icon.Enabled= true;

        }

        private void icon_delay_Tick(object sender, EventArgs e)
        {
            icon.Enabled = false;
            icon_delay.Stop();
            label1.Visible = true;
            

            bunifuFlatButton1.Visible = true;


        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public static void show()
        {
            mesage ms = new mesage();
            ms.ShowDialog();


        }
    }
}
