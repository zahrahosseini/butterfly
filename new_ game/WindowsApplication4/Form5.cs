using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication4
{
    public partial class Form5 : Form

    {
        private int r = 10, c = 20;
        public Form5()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { r = 10; c = 20; }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { r = 15; c = 20; }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        { r = 25; c = 25; }

       private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form tform2 = new Form2(r,c);
            tform2.Show();
            this.Dispose();
        }



     
    }
}