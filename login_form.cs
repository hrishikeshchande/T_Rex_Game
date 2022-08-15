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
    public partial class login_form : Form
    {
        bool allCondition;
        public login_form()
        {
            InitializeComponent();
        }

        private void btcsubmit_Click(object sender, EventArgs e)
        {
            
            //check the all textbox are empty or not
            if(string.IsNullOrEmpty(txtname.Text))
            {
                errorname.SetError(txtname, "enter the name");
            }
            else if(string.IsNullOrEmpty(txtpassword.Text))
            {
                errorname.Clear();
                errorpassword.SetError(txtpassword, "enter the email");
            }
            else if(txtname.Text == "hrishi" && txtpassword.Text == "123")
            {
                errorpassword.Clear();
                allCondition = true;
            }
            else
            {
                MessageBox.Show("Please enter the correct name & password");
            }
            if(allCondition == true)
            {
                this.Hide();
                game trex = new game(this);
                trex.Show();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpassword.Text = "";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            index index_page = new index();
            index_page.Show();
        }
    }
}
