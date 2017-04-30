using System;
using System.Collections.Generic;
using System.Text;

namespace SocketServer
{
    class Tblock : System.Windows.Forms.PictureBox
    {
        public int r;
        public int c;
        public Constvar cv = new Constvar();

        public Tblock(int r0, int c0)
        {
            r = r0;
            c = c0;
            Left = c * cv.width_pic + cv.left_pg;
            Top = r * cv.hight_pic + cv.top_pg;
            ClientSize = new System.Drawing.Size(cv.width_pic, cv.hight_pic);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        public Tblock()
        {

            r = 0;
            c = 0;
            ClientSize = new System.Drawing.Size(cv.width_pic, cv.hight_pic);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }


    }
}
