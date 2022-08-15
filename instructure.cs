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
    public partial class instructure : Form
    {
        public instructure()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            index index_form = new index();
            index_form.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_form login_form_show = new login_form();
            login_form_show.Show();
        }
    }
}
