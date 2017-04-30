using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication4
{
    class Tmap
    {
        private int row;
        private int coulmn;
        public Tblock[,] block;
        public List<Tpoint> lp = new List<Tpoint>();

        public Tmap() { }

        public void makeTmap(int r, int c)
        {
            row = r; coulmn = c;
            block = new Tblock[row, coulmn];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < coulmn; j++)
                    block[i, j] = new Tblock(i, j);
        }


    }
}
