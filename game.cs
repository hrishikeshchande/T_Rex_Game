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
    public partial class game : Form
    {
        login_form lg;

        bool jump;
        public static Random rnd = new Random();
        int jumpspeed = 5,obstspeed = 3,scoreCount;

        public game(login_form lg1)
        {
            InitializeComponent();
            this.lg = lg1;
        }

        private void DoubleClickBack(object sender, EventArgs e)
        {
            this.Hide();
            login_form login_form_Show = new login_form();
            login_form_Show.Show();
        }

        private void DoubleClickPause(object sender, EventArgs e)
        {
            MoveTimer.Stop();
        }

        private void DoubleClickRestart(object sender, EventArgs e)
        {
            MoveTimer.Start();
        }
        private void TimerEventStart(object sender, EventArgs e)
        {
            labuser.Text = lg.txtname.Text;
            //jump of trex
            if (jump == true)
            {
                trex.Top -= jumpspeed;
                if(trex.Top <= 60)
                {
                    trex.Location = new Point(62,191);
                }
            }
            if (jump == false && trex.Top < 190)
            {
                trex.Top += jumpspeed;
            }

            //move obstacle1
            obstacle1.Left -= obstspeed;
            if(obstacle1.Left <=0)
            {
                obstacle1.Left = rnd.Next(500, 700);
                scoreCount++;
                score.Text = Convert.ToString(scoreCount);
            }
            //move obstacle2
            obstacle2.Left -= obstspeed;
            if (obstacle2.Left <= 0)
            {
                obstacle2.Left = rnd.Next(950, 1000);
                scoreCount++;
                score.Text = Convert.ToString(scoreCount);
            }

            //if the obstacle1 and 2 touch with trex then play out
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        trex.Image = Properties.Resources.dead;
                        MoveTimer.Stop();
                        //visible will true after restart game
                        restarttxt.Visible = true;
                        labelpause.Visible = false;
                        labelrestart.Visible = false;
                        MessageBox.Show(lg.txtname.Text + " lose the game score are :" + scoreCount + "\n level are: " + labellevel.Text);
                    }
                }
            }
            //increase speed of obstacle
            if(scoreCount > 10)
            {
                obstspeed = 6;
                labellevel.Text = "2";
            }
            if (scoreCount > 20)
            {
                obstspeed = 9;
                labellevel.Text = "3";
            }

        }
        

        //if space,r key id down
        private void keyisDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                jump = true;
            }
            if(e.KeyCode == Keys.R)
            {
                //visible will false after restart game
                restarttxt.Visible = false;
                labelrestart.Visible = true;
                labelpause.Visible = true;
                scoreCount = 0;
                obstspeed = 3;
                score.Text = Convert.ToString(scoreCount);
                trex.Image = Properties.Resources.running;
                MoveTimer.Start();
                //after trex collaps the obstacle1 in 700 at x 
                obstacle1.Left = 500;
                obstacle2.Left = 700;
            }
        }

        //key space key id up
        private void keyisUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                jump = false;
            }
        }
    }
}
