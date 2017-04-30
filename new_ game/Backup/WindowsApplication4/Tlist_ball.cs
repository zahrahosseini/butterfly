using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsApplication4
{
    class Tlist_ball
    {
        // public SoundPlayer sp = new SoundPlayer();

        public List<Tball> lb;
        private List<Tpoint> lp;
        public bool complete = false;


        public Tlist_ball(List<Tpoint> temp)
        {
            lp = new List<Tpoint>();
            lp.InsertRange(0, temp);
            lb = new List<Tball>();

        }
        public void Add_new_Ball()
        {
            Tball b = new Tball(lp);
            lb.Add(b);
        }
        public void Add_insect()
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
                        if (adjacet(i,i+1) && lb[i + 1].flag)
                            lb[i].flag = true;
                    }
                    if (lb[i].count == lp.Count - 1)
                        return true;//arrive to end
                }
            return false;
        }

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
                if (p == 0 && lb[p].r>lb[p+1].r)
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
                            if (adjacet(t,t+1) && lb[t + 1].flag)
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
                {
                    int s = 0;
                    for (int i = f - 1; i >= 0; i--)
                        if (adjacet(i, i - 1))
                            s++;
                        else
                            break;

                    
                    for (int i = f - 1; i >=f-s-1; i--)
                        lb[i].Push(numb, -1);
                    PopBall(f - 1);
                }
                else
                    for (int i = f - 1; i >= 0; i--)
                        lb[i].flag = false;
            }
            //****
            if (lb.Count == 1)
            {
                int last = lb.Count - 1;
                lb[last].Dispose();
                lb.RemoveAt(last);
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
       /* private bool adjacet(int p)//p+1--->p
        {
            if (p + 1 < lb.Count)
            {
                int c = lb[p + 1].count;
                c++;//next ball is p
                if (lb[p].r == lp[c].r && lb[p].c == lp[c].c)
                    return true;//p & q are mojaver
            }
            return false;
        }*/

       public  bool adjacet(int p,int q)//p+1--->p
        {
            if (q >=0 &&  q < lb.Count)
            {
                int c = lb[q].count;
                c++;//next ball is p
                if (lb[p].r == lp[c].r && lb[p].c == lp[c].c)
                    return true;//p & q are mojaver
            }
            return false;
        }

    }
}
