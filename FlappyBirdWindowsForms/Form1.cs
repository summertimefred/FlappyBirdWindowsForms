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

namespace FlappyBirdWindowsForms
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public object PlayWavFiles { get; private set; }

        public Form1()
        {
            InitializeComponent();
            //btnStartGame.Enabled = false;
            //btnStartGame.Visible= false;
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            //btnStartGame.Visible = false;
            //btnStartGame.Enabled = false;
            //flappyBird.Top += gravity;

            flappyBird.Top = flappyBird.Top + gravity;
            pipeBottom.Left = pipeBottom.Left - pipeSpeed;
            pipeTop.Left = pipeTop.Left - pipeSpeed;

            if(pipeBottom.Left < -50)
            {
                pipeBottom.Left = 800;
                score = score + 1;
            }
            if (pipeTop.Left < -50)
            {
                pipeTop.Left = 850;
                score = score + 1;
            }
            lblScore.Text = $"Score = {score}";

            if(flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                gameOver();
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                gameOver();
            }
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                gameOver();
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
                SoundPlayer sndplayr = new SoundPlayer(FlappyBirdWindowsForms.Properties.Resources.sfx_die);
                sndplayr.Play();
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void gameOver()
        {
            gameTimer.Stop();
            lblScore.Text = lblScore.Text + " GAME OVER!!!!!!!!!!";
 

            SoundPlayer sndplayr = new SoundPlayer(FlappyBirdWindowsForms.Properties.Resources.sfx_wing );
            
            sndplayr.Play();

        }

        //private void bntStartGame_Click(object sender, EventArgs e)
        //{
        //    Application.Restart();
        //    //gameTimer.Start();
            
        //    //lblScore.Text = "Score:";
        //    //score = 0;
        //    ////btnStartGame.Visible = false;
        //    ////btnStartGame.Enabled = false;
        //    //flappyBird.Left = 100;
        //    //flappyBird.Top = 100;
        //    //pipeBottom.Left = 800;
        //    //pipeTop.Left = 850;

        //    //flappyBird.Focus();
        //}

        //private void Form1_Click(object sender, EventArgs e)
        //{
        //    Application.Restart();
        //}

        private void lblRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
