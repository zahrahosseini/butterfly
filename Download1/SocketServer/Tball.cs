using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SocketServer
{
    class Tball : Tblock
    {
        public int count = -1;
        private List<Tpoint> lp = new List<Tpoint>();
        private Random ran;
        public int num;
        public bool flag = true;



        public Tball(List<Tpoint> temp)
            : base()
        {

            lp.InsertRange(0, temp);
            ran = new Random();
            num = ran.Next(5);
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\b" + num + ".jpg");
        }

        public Tball(List<Tpoint> temp, int n, int cunt)
            : base()
        {
            lp.InsertRange(0, temp);
            count = cunt;
            r = lp[count].r;
            c = lp[count].c;
            Left = c * cv.width_pic + cv.left_pg;
            Top = r * cv.hight_pic + cv.top_pg;
            num = n;
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\b" + num + ".jpg");
        }

        public Tball(int r0, int c0)
            : base(r0, c0)
        {
            ran = new Random();
            num = ran.Next(5);
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\b" + num + ".jpg");


        }
        public void move(int n, int toward)
        {
            if (flag)
                Push(n, toward);
        }
        public void Push(int n, int toward)
        {
            if (-1 <= count && count < lp.Count - 1)
                for (int i = 1; i <= n; i++)
                {
                    if (toward == 1)
                        count++;
                    if (toward == -1)
                        count--;
                    if (count <= lp.Count)
                    {
                        Left = lp[count].c * cv.width_pic + cv.left_pg;
                        Top = lp[count].r * cv.hight_pic + cv.top_pg;
                        r = lp[count].r;
                        c = lp[count].c;

                    }

                }
        }

        public void picrandom()
        {
            ran = new Random();
            num = ran.Next(5);
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\b" + num + ".jpg");
        }

    }
}
