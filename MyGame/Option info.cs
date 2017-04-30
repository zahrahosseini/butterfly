using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Draw
{
    public partial class Option_info : Form
    {
        public TrackBar t1;
        public Option_info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s1 = new Start();
            s1.Show();
        }
    }
}