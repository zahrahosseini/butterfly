using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace WindowsApplication4
{
    public partial class Form1 : Form
    {

       
        private SoundPlayer myplayer = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
           // System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
         //   myPlayer.SoundLocation = @"f:\New Folder\SoundS\GameplayMusic2.wav";
            //myPlayer.Play();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
           // myPlayer.SoundLocation = @"f:\New Folder\SoundS\ClickButton.wav";
           // myPlayer.Play();
            Form objform = new Form5();
            objform.Show();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
           // myPlayer.SoundLocation = @"f:\New Folder\SoundS\ClickButton.wav";
           // myPlayer.Play();
            Form objform = new Form4();
            objform.Show();

        }





  




    }
}

