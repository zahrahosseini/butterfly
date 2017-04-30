using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncClient
{
    class Tpoint
    {
        public int r;
        public int c;

        public Tpoint(int r0, int c0)
        {
            r = r0;
            c = c0;
        }
        public Tpoint(Tpoint p0)
        {
            r = p0.r;
            c = p0.c;
        }
        public Tpoint()
        {
            r = 0;
            c = 0;
        }
    }
}
