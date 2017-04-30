using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace SocketServer
{
    public partial class Form2 : Form
    {
        private int r = 10, c = 20;
        private SoundPlayer myplayer = new SoundPlayer();
        public Form2()
        {
            InitializeComponent();
            // myplayer.SoundLocation ="C:\\b.wav";

            // myplayer.Play();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form objform = new Form3(r, c);
            objform.Show();
            //myplayer.Stop();


        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { r = 10; c = 20; }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { r = 15; c = 20; }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        { r = 20; c = 25; }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form objform = new Form4(textBox1.Text);//hanuz naghoftam r,c save she farz kardam 10 10 bashe
            objform.Show();
            //myplayer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           // StreamReader mf = File.OpenText(Directory.GetCurrentDirectory() + @"\namepath" + @"\" + "namepath.txt");
          //  while (!mf.EndOfStream)
             //  listBox1.Items.Add(mf.ReadLine());
          //  mf.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // textBox1.Text = (string)listBox1.SelectedItem;
        }

    }
}