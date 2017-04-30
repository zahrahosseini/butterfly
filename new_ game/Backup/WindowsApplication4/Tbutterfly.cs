using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsApplication4
{
    class Tbutterfly : Tblock
    {
        private int score = 0;
        private int row, culmn;
        public Tball[] ball;
        public Tball Ball;
        public Tbutterfly(int ro, int cu, int r, int c)
            : base(r, c)
        {
            row = ro;
            culmn = cu;
            Width *= 3;
            Height *= 2;
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "butterfly[2].jpg");
            Ball = new Tball(row+1, 0);
            ball = new Tball[3];
            for(int i=0;i<3;i++)
                ball[i] = new Tball(row,culmn+i+2);
            changepic();
            Ball.Image = ball[1].Image;
            Ball.num = ball[1].num;
            
            //ball[1] = new Tball(row,0);
            // ball[2] = new Tball(row,1);
        }
        public void move(int toward)
        {
            if (toward == 1)
                if (Left <= (culmn - 3) * cv.width_pic + cv.left_pg)
                {
                    Left += cv.width_pic;
                    //if (Ball.flag)
                    {
                        Ball.Left += cv.width_pic;
                        Ball.c++;

                    }
                }
            if (toward == -1)
                if (cv.left_pg <= Left)
                {
                    Left -= cv.width_pic;
                   // if (Ball.flag)
                    {
                        Ball.Left -= cv.width_pic;
                        Ball.c--;

                    }
                }
        }
        public void Add_Score(int s)
        { score += s; }
        public int Get_Score()
        { return score; }
        public void Dec_Score(int s)
        { score -= s; }
        public void swappic()
        {
            Tblock temp = new Tblock();
            int n = ball[0].num;
            ball[0].num = ball[1].num;
            ball[1].num = ball[2].num;
            ball[2].num = n;
            
            temp.Image= ball[0].Image;
            ball[0].Image = ball[1].Image;
            ball[1].Image=ball[2].Image;
            ball[2].Image = temp.Image;

            Ball.num = ball[1].num;
            Ball.Image = ball[1].Image;
           


        }
        public void changepic()
        {
            for (int i = 0; i < 3; i++)
                ball[i].picrandom();
            Ball.num = ball[1].num;
            Ball.Image = ball[1].Image;
        
        }
    }
}
