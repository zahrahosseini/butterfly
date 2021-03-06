using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AsyncClient
{
    class Tlist_ball
    {
        // public SoundPlayer sp = new SoundPlayer();

        public List<Tball> lb;
        private List<Tpoint> lp = new List<Tpoint>();
        private static int number = 0;
        public bool complete = false;


        public Tlist_ball(List<Tpoint> temp)
        {
            number++;
            lp.InsertRange(0, temp);
            lb = new List<Tball>();

        }
        public void Add_new_Ball()
        {
            Tball b = new Tball(lp);
            lb.Add(b);
        }
        public void Add_Hashare()
        {
            insect b = new insect(lp);
            lb.Add(b);
        }
        public bool move()
        {
            if (lb.Count != 0)
                for (int i = lb.Count - 1; i >= 0; i--)
                {
                    if (lb[i].flag == true)
                        lb[i].Push(1, 1);
                    else
                    {
                        if (mojaver(i) && lb[i + 1].flag)
                            lb[i].flag = true;
                    }
                }
            return false;
        }
        public int num()
        { return number; }
        public void insertball(Tball b, int p)
        {
            lb.Insert(p, b);
        }
        private int SearchFront(int p)
        {
            int s = 0;
            for (int i = p - 1; i >= 0; i--)
            {
                if (lb[i].num == lb[p].num && lb[i].flag == lb[p].flag)
                    s++;
                else
                    break;
            }
            return p - s;
        }
        private int SearchBack(int p)
        {
            int s = 0;
            for (int i = p + 1; i < lb.Count; i++)
            {
                if (lb[i].num == lb[p].num && lb[i].flag == lb[p].flag)
                    s++;
                else
                    break;
            }
            return s + p;
        }
        public void insert_ball(ref int p, int num)
        {
            if (p != lb.Count - 1)
            {
                int cont;
                if (p == 0)
                {
                    cont = lb[p].count + 1;
                    insertball(new Tball(lp, num, cont), p);
                    lb[p].flag = lb[p + 1].flag;
                }
                else
                {
                    cont = lb[p].count;
                    p++;
                    insertball(new Tball(lp, num, cont), p);
                    lb[p].flag = lb[p - 1].flag;
                    for (int t = p - 1; t >= 0; t--)
                    {
                        if (lb[p].flag == lb[t].flag)
                            lb[t].Push(1, 1);
                        else
                        {
                            if (mojaver(t) && lb[t + 1].flag)
                                lb[t].flag = true;
                        }
                    }

                }

            }
        }
        public int PopBall(int p)
        {
            int f = SearchFront(p);
            int b = SearchBack(p);
            int numb = b - f + 1;
            if (numb >= 3)
            {
                for (int i = f; i <= b; i++)
                    lb[i].Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "bom.jpg");
                for (int i = f; i <= b; i++)
                    lb[i].Dispose();
                lb.RemoveRange(f, numb);

                if (f != 0 && lb[f - 1].num == lb[f].num)
                    for (int i = f - 1; i >= 0; i--)
                        lb[i].Push(numb, -1);
                else
                    for (int i = f - 1; i >= 0; i--)
                        lb[i].flag = false;
            }
            return numb;
        }
        public void Hit(int c0, int t, ref int maxin, ref int max, ref int maxinlist)
        {
            for (int i = 0; i < lb.Count; i++)
                if (lb[i].c == c0 && lb[i].r > max)
                {
                    maxin = i;
                    maxinlist = t;
                    max = lb[maxin].r;
                }
        }
        private bool mojaver(int p)//p+1--->p
        {
            if (p + 1 < lb.Count)
            {
                int c = lb[p + 1].count;
                c++;//next ball is p
                if (lb[p].r == lp[c].r && lb[p].c == lp[c].c)
                    return true;//p & q are mojaver
            }
            return false;
        }

    }
}
