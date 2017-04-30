using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsApplication4
{
    public partial class Form3 : Form
    {


        private List<Tlist_ball> LLB = new List<Tlist_ball>();
        private const int NLb = 3;
        private int cNlb = 0;

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


        public Form3(string st)
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
            butterfly = new Tbutterfly(row, culmn, row + 2, -1);
            Controls.Add(butterfly);
            butterfly.Ball.BringToFront();
            Controls.Add(butterfly.Ball);
            for (int i = 0; i < 3; i++)
                Controls.Add(butterfly.ball[i]);

            //-------------------------make view-----------------------------------------------------------------------------------------------
            Pview = new Tblock(0, 0);
            Pview.Width = widtht_pg;
            Pview.Height = hight_pg;
            Pview.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "Score.jpg");
            //Pview.BackColor = Color.Black;
            Controls.Add(Pview);
            //-------------------------make ghab-----------------------------------------------------------------------------------------------

            gh = new Ghab(row, culmn);
            for (int i = 0; i < gh.sizeghab; i++)
                Controls.Add(gh.ghab[i]);

            //--------------------------------------------------------------------------------------------------------------------------
            button2.Left = button3.Left = cv.left_pg + culmn * cv.width_pic + 50;
            button2.Top = button3.Top = cv.top_pg;
            //System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
            //myPlayer.SoundLocation = @"f:\New Folder\SoundS\GameplayMusic.wav";
            //myPlayer.PlayLooping();

        }



        

    

        private bool HitListBall(int n1, int n2)
        {
            if ((LLB[n1].lb.Count) != 0 && (LLB[n2].lb.Count != 0))
            {
                if ((LLB[n1].lb[0].count) == LLB[n2].lb[LLB[n2].lb.Count-1].count)
                    return true;//n1 hit to n2:n1...>n2
            }
            return false;
        }
        private void concatListBall(int n1, int n2)//n1 hit to n1->n2 
        {
            int s=1;
            for (int i = LLB[n2].lb.Count - 1; i>0;i-- )
            {
                if (LLB[n2].adjacet(i, i - 1))
                    s++;
                else
                    break;
            }

            for (int i = LLB[n2].lb.Count - 1; i >=LLB[n2].lb.Count +1- s; i--)
            {
                LLB[n2].lb[i].flag = LLB[n1].lb[0].flag;
            }
            LLB[n2].lb.InsertRange(LLB[n2].lb.Count, LLB[n1].lb);
            //concat n1 to first of n2
            LLB[n1].lb.Clear();
        }

   





        private void timer2_Tick(object sender, EventArgs e)
        {
            int k, p=0;
            if (butterfly.Ball.Top > cv.top_pg)
            {
                butterfly.Ball.Top -= cv.hight_pic;
                butterfly.Ball.r--;
                int r = butterfly.Ball.r;
                bool fl = false;
                for (k = 0; k < LLB.Count; k++)
                {
                    for (p = 0; p < LLB[k].lb.Count; p++)
                        if (LLB[k].lb[p].r == r && LLB[k].lb[p].c == butterfly.Ball.c)
                        {
                            fl = true;
                            break;
                        }
                    if (fl) break;
                }
                if (fl && p != LLB[k].lb.Count)
                {
                    butterfly.Ball.r = row+1;
                    butterfly.Ball.Top = (row+1) * cv.hight_pic + cv.top_pg;
                    timer2.Enabled = false;
                    LLB[k].insert_ball(ref p, butterfly.Ball.num);
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
                        //System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                        //myPlayer.SoundLocation = @"f:\New Folder\SoundS\BonusStarCatch.wav";
                        //myPlayer.Play();
                        //myPlayer.SoundLocation = @"f:\New Folder\SoundS\GameplayMusic.wav";
                        //myPlayer.PlayLooping();
                    }
                    butterfly.changepic();
                }
            }
            else
            {
                butterfly.Ball.r = row;
                butterfly.Ball.Top = row * cv.hight_pic + cv.top_pg;
                timer2.Enabled = false;
                butterfly.changepic();
            }
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
                    { timer2.Enabled = true; break; }
                case Keys.Down:
                    { butterfly.swappic();/* butterfly.Ball.picrandom();*/ break; }
            }


            return base.ProcessDialogKey(keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Visible = true;
            // button2.Dispose();
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
                    LLB[n].Add_insect();
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
                    timer1.Enabled = false;
                    MessageBox.Show("You lose ");
                   // System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                    //myPlayer.SoundLocation = @"f:\New Folder\SoundS\LostLifeHole.wav";
                    //myPlayer.PlayLooping();
                }

            }
           //******
            bool win = true;
            if (LLB.Count == NLb + 1)
            {

                for (int i = 0; i < LLB.Count; i++)

                    if (LLB[i].lb.Count != 0)
                        win = false;
                if (win)
                {
                   // System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                    //myPlayer.SoundLocation = @"f:\New Folder\SoundS\BukWinEnd.wav";
                    //myPlayer.Play();
                    Pause = true;
                    timer1.Enabled = false;
                    MessageBox.Show("You win ");

                }
            }
            
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
              switch (e.Button)
            {

                case MouseButtons.Left:
                    { timer2.Enabled = true; break; }
                  case MouseButtons.Right:
                    { butterfly.swappic();/* butterfly.Ball.picrandom();*/ break; }
            }
            
            
       //     if(==MouseButtons.Left)
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            int a = (e.X - cv.left_pg) / cv.width_pic;
            int c= a-butterfly.c;
            if (c>0)
            {
                for (int i = 0; i <= c; i++)
                    butterfly.move(1);
            }
            else
            {
                for (int i = 0; i <= Math.Abs(c); i++)
                    butterfly.move(-1);
            }
            

        }






}
}
