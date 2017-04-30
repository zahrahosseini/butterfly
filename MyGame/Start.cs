using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Draw
{
    public partial class Start : Form
    {
        public draw d1 = new draw();
        public Savemytime smt = new Savemytime();
        public Start()
        {
            InitializeComponent();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Select_Game_Mode sgm = new Select_Game_Mode();
            sgm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            MyGame.MainForm.ActiveForm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instruction_info f1 = new Instruction_info();
            f1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            smt.lnumber++;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Option_info o1 = new Option_info();
            o1.Show();
        }
    }

}