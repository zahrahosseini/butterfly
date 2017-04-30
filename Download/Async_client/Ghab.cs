using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AsyncClient
{
    class Ghab
    {
        public Tblock[] ghab;
        public int sizeghab;
        public Ghab(int r, int c)
        {
            sizeghab = (c + r + 2) * 2;
            ghab = new Tblock[sizeghab];
            for (int i = 0; i < sizeghab; i++)
            {
                if (i <= c + 1)
                    ghab[i] = new Tblock(-1, i - 1);

                if (c + 1 < i && i <= c + r + 2)
                    ghab[i] = new Tblock(i - (c + 2), c);

                if (c + r + 2 < i && i <= 2 * (c) + 3 + r)
                    ghab[i] = new Tblock(r, c - (i - (r + c + 2)));

                if (2 * c + 3 + r < i)
                    ghab[i] = new Tblock(r - (i - (r + 2 * c + 3)), -1);

                ghab[i].Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "G9.jpg");

            }
        }
    }
}
