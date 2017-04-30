using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SocketServer
{
    public partial class Form3 : Form
    {
        private Write_file f;

        private int widtht_pg, hight_pg;
        private Constvar cv;
        private int culmn, row;

        private Tblock butterfly;
        private Tblock Pview;

        private Tmap map;
        private Ghab gh;
        //private List<Tblock>Listp;

        public Form3(int r, int c)
        {
            InitializeComponent();
            row = r;
            culmn = c;
            cv = new Constvar();

            widtht_pg = cv.width_pic * culmn;
            hight_pg = cv.hight_pic * row;

            map = new Tmap();
            map.makeTmap(row, culmn);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < culmn; j++)
                { Controls.Add(map.block[i, j]); map.block[i, j].Visible = false; }


            butterfly = new Tblock(0, 0);
            butterfly.BackColor = SystemColors.Control;
            Controls.Add(butterfly);
            butterfly.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "butterfly[1].gif");

            Pview = new Tblock(0, 0);
            Pview.Width = widtht_pg;
            Pview.Height = hight_pg;
            //Pview.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "g1.jpg");
            Pview.BackColor = Color.Black;
            Controls.Add(Pview);

            gh = new Ghab(row, culmn);
            for (int i = 0; i < gh.sizeghab; i++)
                Controls.Add(gh.ghab[i]);

            map.lp = new List<Tpoint>();
            Tpoint start = new Tpoint(0, 0);
            map.lp.Add(start);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           /*StreamWriter myf = File.AppendText(Directory.GetCurrentDirectory() + @"\namepath" + @"\" + "namepath.txt");
            myf.WriteLine(textBox1.Text);
            myf.Close();*/
           // FileStream output = new FileStream(" ",FileMode.Append,FileAccess.Write);
           

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Tpoint p = new Tpoint(row, culmn);
            f = new Write_file(map.lp, textBox1.Text, p);
            Form objform = new Form4(textBox1.Text);
            objform.Show();
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            int i = (butterfly.Top - cv.top_pg) / cv.hight_pic;
            int j = (butterfly.Left - cv.left_pg) / cv.width_pic;
            switch (e.KeyCode)
            {
                case Keys.D:
                    { j++; break; }
                case Keys.A:
                    { j--; break; }
                case Keys.S:
                    { i++; break; }
                case Keys.W:
                    { i--; break; }
            }
            if (0 <= i && i < row && 0 <= j && j < culmn)
            {
                bool flag = false;
                for (int t = 0; t < map.lp.Count; t++)
                {
                    if (map.lp[t].r == i && map.lp[t].c == j)
                    { flag = true; break; }
                }
                if (!flag)
                {
                    butterfly.Top = i * cv.hight_pic + cv.top_pg;
                    butterfly.Left = j * cv.width_pic + cv.left_pg;
                    map.block[i, j].Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\pictures" + @"\" + "1.jpg");
                    map.block[i, j].Visible = true;
                    map.lp.Add(new Tpoint(i, j));
                }
            }
        }

    }
}