using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            restartbutton2.Visible = false;
            exitbutton1.Visible = false;
        }

        int ballX = 4;
        int ballY = 4;
        int score = 0;


        private void GameOver()
        {
            if (score > 19)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!!!");
                restartbutton2.Visible = true;
                exitbutton1.Visible = true;
            }
            if (ball.Top+ball.Height > ClientSize.Width)
            {
                timer1.Stop();
                MessageBox.Show("You Failld!!\nGame Over!");
                restartbutton2.Visible = true;
                exitbutton1.Visible = true;
            }
        }
        private void GetScore()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ballY = -ballY;
                        score++;
                        label1.Text = "Score :" + score;

                    }
                }
            }
        }
        private void ballMovment()
        {
            ball.Left += ballX;
            ball.Top += ballY;
            if(ball.Left+ball.Width>ClientSize.Width|| ball.Left < 0)
            {
                ballX = -ballX;
            }
            if (ball.Top < 0 || ball.Bounds.IntersectsWith(Player.Bounds)){
                ballY = -ballY;
            }
        } 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left&&Player.Left>0)
            {
                Player.Left -= 5;
            }
            if (e.KeyCode == Keys.Right && Player.Right < 800)
            {
                Player.Left += 5;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ballMovment();
            GetScore();
            GameOver();
        }
        private void exitbutton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void restartbutton2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            restartbutton2.Visible = false;
            exitbutton1.Visible = false;
       
            score = 0;
            label1.Text = "Score :" + score;

           

        }

    
    }
}
