using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trex_4
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void btninstruction_Click(object sender, EventArgs e)
        {
            this.Hide();
            instructure instructure_form = new instructure();
            instructure_form.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_form login_form_Show = new login_form();
            login_form_Show.Show();
        }
    }
}
