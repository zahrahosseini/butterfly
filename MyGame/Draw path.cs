using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Draw
{
    public partial class Draw_path : Form
    {
        public position p1 = new position();
        public List_My_Path l1 = new List_My_Path();
        private string picpath1 = @"\Data\up.bmp";
        private string picpath2 = @"\Data\down.bmp";
        private string picpath3 = @"\Data\left.bmp";
        private string picpath4 = @"\Data\right.bmp";
        public My_Pic[][] pic;
        private static int x, y;
        public Draw_path()
        {
            InitializeComponent();
            drawpic();
        }
        public void drawpic()
        {
            pic = new My_Pic[10][];
            for (int i = 0; i < 10; i++)
                pic[i] = new My_Pic[10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    pic[i][j] = new My_Pic();
                    pic[i][j].Left = j * 30 + 30;
                    pic[i][j].Top = i * 30 + 30;
                    Controls.Add(pic[i][j]);
                    pic[i][j].ClientSize = new Size(30, 30);
                    pic[i][j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pic[i][j].BackColor = Color.LightSteelBlue;
                    if ((i + j) % 2 == 0)
                        pic[i][j].BackColor = Color.CornflowerBlue;
                }
            pic[0][0].Image = Image.FromFile(Directory.GetCurrentDirectory() + picpath1);
            x = y = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    pic[i][j].number = 0;
            pic[0][0].number++;
        }

        private void Draw_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
                Start.ActiveForm.Hide();
                MyGame.MainForm.ActiveForm.Show();
            }
            else
                if ((e.KeyCode == Keys.Up)
                   && (x > 0) && (pic[x - 1][y].number < 2))
                {
                    pic[x - 1][y].Image = Image.FromFile(Directory.GetCurrentDirectory() + picpath1);
                    x--;
                    l1.add(new position(0, 1, pic[x][y].number));
                    pic[x][y].number--;
                }
                else
                    if ((e.KeyCode == Keys.Left)
                            && (y > 0) && (pic[x][y - 1].number < 2))
                    {
                        pic[x][y - 1].Image = Image.FromFile(Directory.GetCurrentDirectory() + picpath3);
                        y--;
                        l1.add(new position(-1, 0, pic[x][y].number));
                        pic[x][y].number--;
                    }
                    else
                        if ((e.KeyCode == Keys.Right)
                           && (y < 9) && (pic[x][y + 1].number < 2))
                        {
                            pic[x][y + 1].Image = Image.FromFile(Directory.GetCurrentDirectory() + picpath4);
                            y++;
                            l1.add(new position(1, 0, pic[x][y].number));
                            pic[x][y].number--;
                        }
                        else
                            if ((e.KeyCode == Keys.Down)
                                       && (x < 9) && (pic[x + 1][y].number < 2))
                            {
                                pic[x + 1][y].Image = Image.FromFile(Directory.GetCurrentDirectory() + picpath2);
                                x++;
                                l1.add(new position(0, -1, pic[x][y].number));
                                pic[x][y].number--;
                            }
        }
    }
}