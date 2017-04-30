using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsApplication4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"f:\New Folder\SoundS\ClickButton.wav";
            myPlayer.Play();
                Form objform = new Form3(System.Convert.ToString(listBox1.SelectedItem));//hanuz naghoftam r,c save she farz kardam 10 10 bashe
                objform.Show();
                this.Dispose();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\filesw");
            foreach (string file in files)
                listBox1.Items.Add(file);
        }
    }
}