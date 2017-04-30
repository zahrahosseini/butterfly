using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AsyncClient
{
    class Tbutterfly : Tblock
    {
        private int score = 0;
        private int row, culmn;
        public Tball[] ball;
        public Tbutterfly(int ro, int cu, int r, int c)
            : base(r, c)
        {
            row = ro;
            culmn = cu;
            Width *= 3;
            Height *= 2;
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "butterfly[2].jpg");

            ball = new Tball[3];
            ball[0] = new Tball(row, 0);
            //ball[1] = new Tball(row,0);
            // ball[2] = new Tball(row,1);
        }
        public void move(int toward)
        {
            if (toward == 1)
                if (Left <= (culmn - 3) * cv.width_pic + cv.left_pg)
                {
                    Left += cv.width_pic;
                    ball[0].Left += cv.width_pic;
                    ball[0].c++;
                }
            if (toward == -1)
                if (cv.left_pg <= Left)
                {
                    Left -= cv.width_pic;
                    ball[0].Left -= cv.width_pic;
                    ball[0].c--;
                }
        }
        public void Add_Score(int s)
        { score += s; }
        public int Get_Score()
        { return score; }
        public void Dec_Score(int s)
        { score -= s; }
    }
}
