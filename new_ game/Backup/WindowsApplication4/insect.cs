using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsApplication4
{
    class insect : Tball
    {
        public insect(List<Tpoint> lip)
            : base(lip)
        {
            Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "G11.jpg");
            num = -1;
        }
    }
}
