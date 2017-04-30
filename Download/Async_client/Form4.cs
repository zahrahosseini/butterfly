using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AsyncClient
{
    public partial class Form4 : Form
    {
        private List<Tlist_ball> LLB = new List<Tlist_ball>();
        private const int NLb = 3;
        private int cNlb = 0;
        public AsyncClient.Form1 ss = new Form1();
        private const int Nb = 5;
        private const int per = 10;
        private int p = 0;

        private int widtht_pg, hight_pg;
        private Constvar cv;
        private int culmn, row;


        private Tbutterfly butterfly;
        private Tblock Pview;

        private Tmap map;
        private Ghab gh;

        private bool Pause = true;


        public Form4(string st)
        {
            InitializeComponent();

            //-------------------------load path-----------------------------------------------------------------------------------------------
            Tpoint point = new Tpoint();
            map = new Tmap();
            Read_file rf = new Read_file(ref map.lp, st, ref point);
            row = point.r;
            culmn = point.c;

            //-------------------------make map-----------------------------------------------------------------------------------------------
            map.makeTmap(row, culmn);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < culmn; j++)
                { Controls.Add(map.block[i, j]); map.block[i, j].Visible = false; }
            int c = 0;
            while (c != map.lp.Count)
            {
                map.block[map.lp[c].r, map.lp[c].c].Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "1.jpg");
                map.block[map.lp[c].r, map.lp[c].c].Visible = true;
                c++;
            }

            //------------------------------------------------------------------------------------------------------------------------------
            cv = new Constvar();
            widtht_pg = cv.width_pic * culmn;
            hight_pg = cv.hight_pic * row;

            Width = widtht_pg + 300;
            Height = hight_pg + 300;

            //-------------------------make Butterfky-----------------------------------------------------------------------------------------------
            butterfly = new Tbutterfly(row, culmn, row + 1, -1);
            Controls.Add(butterfly);
            butterfly.ball[0].BringToFront();
            Controls.Add(butterfly.ball[0]);

            //-------------------------make view-----------------------------------------------------------------------------------------------
            Pview = new Tblock(0, 0);
            Pview.Width = widtht_pg;
            Pview.Height = hight_pg;
            Pview.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "Score.jpg");
            Pview.BackColor = Color.Black;
            Controls.Add(Pview);
            //-------------------------make ghab-----------------------------------------------------------------------------------------------

            gh = new Ghab(row, culmn);
            for (int i = 0; i < gh.sizeghab; i++)
                Controls.Add(gh.ghab[i]);

            //--------------------------------------------------------------------------------------------------------------------------


        }



        private void ThrowBall()
        {
            int maxin = 0; int max = -1; int maxinlist = 0;
            for (int t = 0; t < LLB.Count; t++)//<=
                LLB[t].Hit(butterfly.ball[0].c, t, ref maxin, ref max, ref maxinlist);
            int k = maxinlist;
            int p = maxin;
            //timer2.Enabled = true;
            //timer1.Enabled = false;
            if (max != -1 && p != LLB[k].lb.Count)
            {

                //   timer2.Enabled = true;
                /* if (butterfly.ball[0].Top == max * cv.hight_pic + cv.top_pg)
                     timer2.Enabled = false;*/

                LLB[k].insert_ball(ref p, butterfly.ball[0].num);
                //timer1.Enabled = true;
                //timer2.Enabled = false;

                Controls.Add(LLB[k].lb[p]);
                LLB[k].lb[p].BringToFront();
                for (int t = k - 1; t >= 0; t--)
                    if (HitListBall(k, t))
                    {
                        int last = LLB[t].lb.Count - 1;
                        LLB[t].lb[last].Dispose();
                        LLB[t].lb.RemoveAt(last);
                        p += LLB[t].lb.Count;
                        concatListBall(k, t);//clear k
                        k = t;
                        break;
                    }

                int s = LLB[k].PopBall(p);
                if (s >= 3)
                {
                    butterfly.Add_Score(s);
                    label1.Text = System.Convert.ToString(butterfly.Get_Score());
                    ss.txtDataTx.Text = label1.Text;
                    ss.send();
              //      label2.Text = ss.txtDataRx.Text;
                }
            }
        }
        private bool HitListBall(int n1, int n2)
        {
            if ((LLB[n1].lb.Count) != 0 && (LLB[n2].lb.Count != 0))
            {
                if ((LLB[n1].lb[0].count) == LLB[n2].lb[LLB[n2].lb.Count - 1].count)
                    return true;//n1 hit to n2:n1...>n2
            }
            return false;
        }
        private void concatListBall(int n1, int n2)//n1 hit to n2->n1 
        {
            LLB[n2].lb.InsertRange(LLB[n2].lb.Count, LLB[n1].lb);
            //concat n1 to first of n2
            LLB[n1].lb.Clear();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //  MessageBox.Show("top");
            butterfly.ball[0].Top -= cv.hight_pic;
            if (butterfly.ball[0].Top == cv.top_pg)
            {
                butterfly.ball[0].Top = butterfly.Top - cv.width_pic;
                timer2.Enabled = false;
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {

            if (p == 0 && cNlb < NLb)
            {
                LLB.Add(new Tlist_ball(map.lp));
                cNlb++;
            }
            p++;
            int n = LLB.Count - 1;//last list
            if (p == per)
                p = 0;
            if (!LLB[n].complete)
            {
                if (LLB[n].lb.Count == Nb - 1)
                {
                    LLB[n].Add_Hashare();
                    LLB[n].complete = true;
                }
                else
                    LLB[n].Add_new_Ball();
                Controls.Add(LLB[n].lb[LLB[n].lb.Count - 1]);
                LLB[n].lb[LLB[n].lb.Count - 1].BringToFront();
            }

            for (int i = 0; i < LLB.Count; i++)
            {
                bool f = LLB[i].move();
                if (f)
                {
                    Pause = true;
                    MessageBox.Show("You lose ");
                }

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Visible = true;
            button2.Visible = false;
            button3.Visible = true;
        }



       


        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Stop")
            {
                Pause = false;
                button3.Text = "Play";
                timer1.Enabled = false;
            }
            else
            {
                Pause = true;
                button3.Text = "Stop";
                timer1.Enabled = true;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Visible = true;
            // button2.Dispose();
            button2.Visible = false;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Right:
                    { butterfly.move(1); break; }
                case Keys.Left:
                    { butterfly.move(-1); break; }
                case Keys.Up:
                    { ThrowBall(); break; }
                case Keys.Down:
                    { butterfly.ball[0].picrandom(); break; }
            }


            return base.ProcessDialogKey(keyData);
        }

    }
}