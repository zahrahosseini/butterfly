using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CsGL.OpenGL;
using System.Threading;
using System.Timers;
using System.Drawing;

namespace Draw
{
    public class draw : OpenGLControl
    {
        public List<List_My_Ball> limyba = new List<List_My_Ball>();
        public int per = 0;
        public bool light = false;				// Lighting ON/OFF ( NEW )
        public bool lp = false;					// L Pressed? ( NEW )
        public bool fp = false;					// F Pressed? ( NEW )
        public int formno = 0;
        public List_My_Ball MyBall;
        public List_My_Ball MyBall1 = new List_My_Ball();
        public List_My_Ball MyBall2 = new List_My_Ball();
        public List_My_Ball MyBall3 = new List_My_Ball();
        public float xrot = 0.0f;				// X-axis rotation
        public float yrot = 0.0f;				// Y-axis rotation
        public float zrot = 0.0f;
        public float xspeed = 0.0f;				// X Rotation Speed
        public float yspeed = 0.0f;				// Y Rotation Speed
        public float z = -5.0f;					// Depth Into The Screen
        public Sphere sphere1 = new Sphere();
        public Squre sq1 = new Squre();
        public Box box1 = new Box();
        public Disc d1 = new Disc();
        public butterfly butterfly1 = new butterfly();
        public LoadTextures loading = new LoadTextures();
        // Lighting components for the cube
        public Tball ttball;
        public My_time t1;
        private float xx, yy, zz;
        public float[] LightAmbient =  { 0.5f, 0.5f, 0.5f, 1.0f };
        public float[] LightDiffuse =  { 1.0f, 1.0f, 1.0f, 1.0f };
        public float[] LightPosition = { 0.0f, 0.0f, 2.0f, 1.0f };
        public color mycolor = new color();
        public int[] clo = new int[6] { 0, 1, 2, 3, 4, 5 };
        public int n = 0;
        public int filter = 0;					// Which Filter To Use
        public static int no;
        public int[] mytextno = new int[6] { 5, 5, 5, 5, 5, 5 };
        public bool finished;
        public int lnum = 3;
        public Assume_path as12 = new Assume_path();
        public int ttime;
        public bool flag = false;
        public Random r = new Random();
        public Random r1;
        int a = 0;
        public float xb, yb, zb;
        public Two_time ttime2;
        public int givetime()
        {
            ttime++;
            return ttime;
        }

        public draw()
            : base()
        {

            this.KeyDown += new KeyEventHandler(LessonView_KeyDown);
            this.KeyUp += new KeyEventHandler(LessonView_KeyUp);
            this.finished = false;
            r1 = new Random(r.Next());
            t1 = new My_time();
            ttime2 = new Two_time();
            t1.Interval = 2000;
            ttime2.Interval = 1000;
            MyBall = new List_My_Ball();
            limyba.Add(MyBall1);
            limyba.Add(MyBall2);
            limyba.Add(MyBall3);
        }

        protected override void InitGLContext()
        {
            loading.LoadTextures1(2);
            MyBall2 = new List_My_Ball();
            xb = zb = 0;
            yy=yb = -1.2f;
            GL.glEnable(GL.GL_TEXTURE_2D);									// Enable Texture Mapping
            GL.glShadeModel(GL.GL_SMOOTH);									// Enable Smooth Shading
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);						// Black Background
            GL.glClearDepth(1.0f);											// Depth Buffer Setup
            GL.glEnable(GL.GL_DEPTH_TEST);									// Enables Depth Testing
            GL.glDepthFunc(GL.GL_LEQUAL);									// The Type Of Depth Testing To Do
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);		// Really Nice Perspective Calculations

            GL.glLightfv(GL.GL_LIGHT1, GL.GL_AMBIENT, this.LightAmbient);	// Setup The Ambient Light
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_DIFFUSE, this.LightDiffuse);	// Setup The Diffuse Light
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_POSITION, this.LightPosition);	// Position The Light
            GL.glEnable(GL.GL_LIGHT1);										// Enable Light One
            if (this.light)													// If lighting, enable it to start
                GL.glEnable(GL.GL_LIGHTING);
        }

        public void AddTball(List_My_Ball MyBall, int start, int end)
        {
            for (int i = start; i < end; i++)
                if (MyBall.lmp1[i].counter < as12.MyPath.Count)
                    MyBall.lmp1[i].counter++;
            if (MyBall.lmp1.Count < 6)
            {
                a = r1.Next(6);
                this.ttball = new Tball(as12.MyPath[0].x, as12.MyPath[0].y, 0, 0, a);
                MyBall.lmp1.Insert(MyBall.lmp1.Count, ttball);
            }
        }
        public void MoveBall(List_My_Ball MyBall)
        {
            for (int i = 0; (i < MyBall.lmp1.Count) && (t1.Enabled); i++)
            {
                if (MyBall.lmp1[i].counter < as12.MyPath.Count)
                {
                    GL.glLoadIdentity();
                    GL.glTranslatef(0, 0, this.z);

                    GL.glTranslatef(as12.MyPath[MyBall.lmp1[i].counter].x, as12.MyPath[MyBall.lmp1[i].counter].y, as12.MyPath[MyBall.lmp1[i].counter].z);
                    if (MyBall.lmp1[i].data == 1)
                        GL.glColor3fv(mycolor.yellow);
                    if (MyBall.lmp1[i].data == 0)
                        GL.glColor3fv(mycolor.green);
                    if (MyBall.lmp1[i].data == 2)
                        GL.glColor3fv(mycolor.magneta);
                    if (MyBall.lmp1[i].data == 3)
                        GL.glColor3fv(mycolor.blue);
                    if (MyBall.lmp1[i].data == 4)
                        GL.glColor3fv(mycolor.cyan);
                    if (MyBall.lmp1[i].data == 5)
                        GL.glColor3fv(mycolor.red);
                    sphere1.getbox();
                }
            }
        }
        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();
            GL.glColor3fv(mycolor.red);
            if ((formno != 0) && (!t1.Enabled))
                t1.Enabled = true;
            if (formno == 0)
            {
                GL.glTranslatef(-1.5f, 0.0f, this.z);
                for (int i = 0; (i < 6) && (givetime() < 200); i++)
                {

                    loading.LoadTextures1(mytextno[i]);
                    sphere1.getbox();
                    GL.glLoadIdentity();
                    GL.glTranslatef((-1.5f + (0.6f * i)), 0, this.z);

                    switch (clo[i])
                    {
                        case 0:
                            GL.glColor3fv(mycolor.red);
                            break;
                        case 1:
                            GL.glColor3fv(mycolor.blue);
                            break;
                        case 2:
                            GL.glColor3fv(mycolor.cyan);
                            break;
                        case 3:
                            GL.glColor3fv(mycolor.green);
                            break;
                        case 4:
                            GL.glColor3fv(mycolor.yellow);
                            break;
                        case 5:
                            GL.glColor3fv(mycolor.magneta);
                            break;
                    }
                }
            }
            else
            {
                ///////////////////////////////////////path///////////////////////////////
                GL.glLoadIdentity();
                GL.glTranslatef(0.0f, 0.0f, this.z);
                // -2.3  1.5
                GL.glTranslatef(as12.MyPath[0].x, as12.MyPath[0].y, as12.MyPath[0].z);
                for (int i = 0; i < as12.MyPath.Count; i++)
                {
                    if (i > 0)
                        GL.glTranslatef(as12.MyPath[i].x - as12.MyPath[i - 1].x, as12.MyPath[i].y - as12.MyPath[i - 1].y, as12.MyPath[i].z - as12.MyPath[i - 1].z);
                    d1.getbox();
                }
                GL.glLoadIdentity();
                GL.glTranslatef(0.0f, 0.0f, this.z);
                GL.glTranslatef(2.8f, -1.5f, 0);
                sphere1.getbox();
                GL.glLoadIdentity();
                GL.glTranslatef(0.0f, 0.0f, this.z);
                // GL.glTranslatef(0.0f, -1.5f, 0);
                GL.glTranslatef(xb, yb, zb);
                sphere1.getbox();
                GL.glLoadIdentity();
                GL.glTranslatef(0.0f, 0.0f, this.z);
                GL.glTranslatef(xx, yy , zz);
                sphere1.getbox();
                if (t1.Enabled)
                {
                    MoveBall(limyba[0]);
                    if (per > 7)
                        MoveBall(limyba[1]);
                    if (per > 14)
                        MoveBall(limyba[2]);
                    if ((yy < 1.6f) && (flag))
                    {
                        int i, j;
                        yy += 0.45f;
                        for (i = 0; i < 3; i++)
                        {
                            for (j = 0; j < limyba[i].lmp1.Count; j++)
                            {
                               // float l = limyba[i].lmp1[j].y;
                             //   float la = limyba[i].lmp1[j].x;
                                //  if ((xx <= limyba[i].lmp1[j].x) && (limyba[i].lmp1[j].x < xx + 0.45f))
                                //   if ((yy >= l) && (yy < l + 0.15f))
                                if (Math.Sqrt((xx - limyba[i].lmp1[j].x) * (xx - limyba[i].lmp1[j].x) + (yy - limyba[i].lmp1[j].y) * (yy - limyba[i].lmp1[j].y)) <= 0.025)
                                {
                                   // System.Windows.Forms.MessageBox.Show("found");
                                    yy =- 1.62f;
                                    flag = false;
                                    break;
                                }
                                //  else
                                //   yy += 0.225f;
                            }
                            if (!flag)
                                break;
                        }
                    }
                    /*  float l = limyba[0].lmp1[1].y;
                      float la = as12.MyPath[2].x;
                     if((xx>=la)&&(xx<la+0.45f))

                      if ((yy >= l)&&(yy<l+0.15f))
                      {
                          System.Windows.Forms.MessageBox.Show("found");
                         yy += 0.225f;
                      }
                      else
                        //  }
                      yy += 0.225f;
                       
                  }*/
                    else
                        if (yy >= 1.6f)
                        {
                            flag = false;
                            yy = -2.1f;
                            xx = xb;
                            zz = zb;
                        }
                }
                if (t1.gettime() == ttime + 1)
                {
                    
                    AddTball(limyba[0], 0, limyba[0].lmp1.Count);
                    if (per > 7)
                        AddTball(limyba[1], 0, limyba[1].lmp1.Count);
                    if (per > 15)
                        AddTball(limyba[2], 0, limyba[2].lmp1.Count);
                    per++;
                }
                ttime = t1.l;
                /*    //for (int i = 0; i < MyBall.lmp1.Count; i++)
                      //   if(MyBall.lmp1[i].counter<11)
                      //  MyBall.lmp1[i].counter++;
                      //MyBall.lmp1.Add(new Tball(as12.MyPath[0].x, as12.MyPath[0].y, 0, t1.s, 0));
                      MyBall.lmp1.Insert(MyBall.lmp1.Count, new Tball(as12.MyPath[0].x, as12.MyPath[0].y, 0, la, 0));
                      for (int i = 0; i < MyBall.lmp1.Count; i++)
                      {
                          GL.glLoadIdentity();
                          GL.glTranslatef(0, 0, this.z);
                          if ((t1.gettime()%11 + MyBall.lmp1[i].counter )< 11)
                          {
                              GL.glTranslatef(as12.MyPath[t1.gettime()%11 + MyBall.lmp1[i].counter].x, as12.MyPath[t1.gettime() %11+ MyBall.lmp1[i].counter].y, as12.MyPath[t1.gettime()%11 + MyBall.lmp1[1].counter].z);
                              GL.glColor3fv(mycolor.yellow);
                              sphere1.getbox();
                          }
                        //  if (t1.gettime() + 1 > 12)
                          //    t1.l = 0;
                      }*/
            }
            //////////////////////////////////////////////////
            /*     if(t1.Enabled)
                 {
                     for (int j=0;j<MyBall.lmp1.Count;j++)
                     {
                         MyBall.lmp1[j].counter++;
                         if (MyBall.lmp1[j].counter < 12)
                         {
                             MyBall.lmp1[j].x = as12.MyPath[MyBall.lmp1[j].counter].x;
                             MyBall.lmp1[j].y = as12.MyPath[MyBall.lmp1[j].counter].y;
                         }
                         else
                         {
                             MyBall.lmp1[j].x = as12.MyPath[0].x;
                             MyBall.lmp1[j].y = as12.MyPath[0].y;
                         }
                     }
                     if(MyBall.lmp1.Count<12)
                     MyBall.lmp1.Add(new Tball (as12.MyPath[0].x,as12.MyPath[0].y,as12.MyPath[0].z,0,1));
                     for(int j=0;j<MyBall.lmp1.Count;j++)
                     {
                         GL.glLoadIdentity();
                         GL.glTranslatef(0,0,this.z);
                         GL.glTranslatef(MyBall.lmp1[j].x,MyBall.lmp1[j].y,MyBall.lmp1[j].z);
                         sphere1.getbox();
                     }
                 }
             }*/
            /////////////////////////////
            /*   GL.glLoadIdentity();
              GL.glTranslatef(0, 1, 0);
             GL.glTranslatef(-1, 0, 0);
            
                
          
              box1.getbox();
       butterfly1.butterflydraw();
         -----------------------------------------------
       this.xrot += this.xspeed;
        this.yrot += this.yspeed;*/
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Size s = Size;

            if (s.Height == 0)
                s.Height = 1;

            GL.glViewport(0, 0, s.Width, s.Height);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GL.gluPerspective(45.0f, (double)s.Width / (double)s.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        protected void LessonView_KeyDown(object Sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)				// Finish the application if the escape key was pressed
                this.finished = true;
            else if (e.KeyCode == Keys.L && !this.lp)	// On the L key, flip the lighting mode
            {
                this.lp = true;
                this.light = !this.light;
                if (this.light)
                    GL.glEnable(GL.GL_LIGHTING);
                else
                    GL.glDisable(GL.GL_LIGHTING);
            }
            else if (e.KeyCode == Keys.F && !this.fp)	// On the F key, cycle the texture filter (texture used)
            {
                this.fp = true;
                this.filter = (filter + 1) % 3;
            }
            else if (e.KeyCode == Keys.PageUp)			// On page up, move out
                this.z -= 0.02f;
            else if (e.KeyCode == Keys.PageDown)		// On page down, move in
                this.z += 0.02f;
        }

        private void LessonView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L)					// Release the lighting toggle key lock
            { this.lp = false; }
            else if (e.KeyCode == Keys.F)				// Release the filter cycle key lock
            { this.fp = false; }
            else
                if (e.KeyCode == Keys.C)
                {
                    if(!flag)
                    flag = true;
                    xx = xb;
                    yy = -0.75f;
                    zz = zb;
                }
          //  {
                
                /*
                    float miny = 3;
                    int minlist = -1;
                    int minindex = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < limyba[i].lmp1.Count; j++)
                            if (limyba[i].lmp1[j].counter < as12.MyPath.Count)

                                if (xb == as12.MyPath[limyba[i].lmp1[j].counter].x)

                                    if (as12.MyPath[limyba[i].lmp1[j].counter].y < miny)
                                    {
                                        minlist = i;
                                        minindex = j;
                                        miny = as12.MyPath[limyba[i].lmp1[j].counter].y;
                                    }
                    }
                    if (minlist != -1)
                    {
                        for (int j = 0; j < minindex + 1; j++)
                            limyba[minlist].lmp1[j].counter++;

                        limyba[minlist].lmp1.Insert(minindex + 1, new Tball(as12.MyPath[limyba[minlist].lmp1[minindex].counter - 1].x, as12.MyPath[limyba[minlist].lmp1[minindex].counter - 1].y, as12.MyPath[limyba[minlist].lmp1[minindex].counter - 1].z, limyba[minlist].lmp1[minindex].counter - 1, 3));
                    }
               
                   
                   int cc = 10;
                   for(int i=0;i<limyba[0].lmp1.Count;i++)
                    if(limyba[0].lmp1[i].counter<as12.MyPath.Count)
                     if (as12.MyPath[limyba[0].lmp1[i].counter].x == xb)
                  {
                      cc = i;
                      for (int j = 0; j <= cc; j++)
                          limyba[0].lmp1[j].counter++;
                    //   ttball = new Tball(as12.MyPath[MyBall1.lmp1[i].counter - 1].x, as12.MyPath[MyBall1.lmp1[i].counter - 1].y, as12.MyPath[MyBall1.lmp1[i].counter - 1].z, MyBall1.lmp1[i].counter - 1, 3);
                     //limyba[0].lmp1.Insert(i,new Tball(as12.MyPath[MyBall1.lmp1[i].counter - 1].x, as12.MyPath[MyBall1.lmp1[i].counter - 1].y, as12.MyPath[MyBall1.lmp1[i].counter - 1].z, MyBall1.lmp1[i].counter - 1, 3));
                       //   MyBall1.lmp1.Add(ttball);
                      break;
                   }
               if (cc != 10)
               {
                  // ttball = new Tball(as12.MyPath[MyBall1.lmp1[cc].counter].x, as12.MyPath[MyBall1.lmp1[cc].counter - 1].y, as12.MyPath[MyBall1.lmp1[cc].counter - 1].z, MyBall1.lmp1[cc].counter - 1, 3);
                 limyba[0].lmp1.Insert(cc+1, new Tball(as12.MyPath[MyBall1.lmp1[cc+1].counter ].x, as12.MyPath[MyBall1.lmp1[cc+1].counter ].y, as12.MyPath[MyBall1.lmp1[cc+1].counter ].z, MyBall1.lmp1[cc].counter-1 , 3));
               }  */       
                    //  ttball = new Tball(as12.MyPath[MyBall1.lmp1.Count].x, as12.MyPath[MyBall1.lmp1.Count].y, as12.MyPath[MyBall1.lmp1.Count].z, 0, 3);
                    //  limyba[0].lmp1.Add(ttball);

            //    }
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
          /*  if (keyData == Keys.C)
            {

                float miny = 3;
                int minlist = -1;
                int minindex = -1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < limyba[i].lmp1.Count; j++)
                        if (limyba[i].lmp1[j].counter < as12.MyPath.Count)

                            if (xb == as12.MyPath[limyba[i].lmp1[j].counter].x)

                                if (as12.MyPath[limyba[i].lmp1[j].counter].y < miny)
                                {
                                    minlist = i;
                                    minindex = j;
                                    miny = as12.MyPath[limyba[i].lmp1[j].counter].y;
                                }
                }
                if (minlist != -1)
                {
                    for (int j = 0; j < minindex + 1; j++)
                        limyba[minlist].lmp1[j].counter++;

                    limyba[minlist].lmp1.Insert(minindex + 1, new Tball(as12.MyPath[limyba[minlist].lmp1[minindex].counter - 1].x, as12.MyPath[limyba[minlist].lmp1[minindex].counter - 1].y, as12.MyPath[limyba[minlist].lmp1[minindex].counter - 1].z, limyba[minlist].lmp1[minindex].counter - 1, 3));
                }*/
             /*  
               int cc = 10;
               for(int i=0;i<limyba[0].lmp1.Count;i++)
                if(limyba[0].lmp1[i].counter<as12.MyPath.Count)
                 if (as12.MyPath[limyba[0].lmp1[i].counter].x == xb)
              {
                  cc = i;
                  for (int j = 0; j < cc+1; j++)
                      limyba[0].lmp1[j].counter++;
                //   ttball = new Tball(as12.MyPath[MyBall1.lmp1[i].counter - 1].x, as12.MyPath[MyBall1.lmp1[i].counter - 1].y, as12.MyPath[MyBall1.lmp1[i].counter - 1].z, MyBall1.lmp1[i].counter - 1, 3);
                 //limyba[0].lmp1.Insert(i,new Tball(as12.MyPath[MyBall1.lmp1[i].counter - 1].x, as12.MyPath[MyBall1.lmp1[i].counter - 1].y, as12.MyPath[MyBall1.lmp1[i].counter - 1].z, MyBall1.lmp1[i].counter - 1, 3));
                   //   MyBall1.lmp1.Add(ttball);
                  break;
               }
           if (cc != 10)
           {
              // ttball = new Tball(as12.MyPath[MyBall1.lmp1[cc].counter].x, as12.MyPath[MyBall1.lmp1[cc].counter - 1].y, as12.MyPath[MyBall1.lmp1[cc].counter - 1].z, MyBall1.lmp1[cc].counter - 1, 3);
             limyba[0].lmp1.Insert(cc+1, new Tball(as12.MyPath[MyBall1.lmp1[cc+1].counter ].x, as12.MyPath[MyBall1.lmp1[cc+1].counter ].y, as12.MyPath[MyBall1.lmp1[cc+1].counter ].z, MyBall1.lmp1[cc].counter-1 , 3));
           }        */
                //  ttball = new Tball(as12.MyPath[MyBall1.lmp1.Count].x, as12.MyPath[MyBall1.lmp1.Count].y, as12.MyPath[MyBall1.lmp1.Count].z, 0, 3);
                //  limyba[0].lmp1.Add(ttball);

           // }
            if (keyData == Keys.Enter)
            {
                if ((no < 5) && (givetime() < 200))
                {
                    no++;
                    mytextno[no] = 4;
                }
                else
                    if (givetime() > 200)
                    {

                        if (formno == 0)
                        {
                            Form objform = new Start();
                            objform.Show();
                            formno++;
                        }
                        if (formno == 0)
                            formno++;
                    }


            }

            if (keyData == Keys.Up)						// Change rotation about the x axis
            {
                yb -= 0.45f;
            }
            else if (keyData == Keys.Down)
                yb += 0.45f;
            else if (keyData == Keys.Right)				// Change rotation about the y axis
            { xb += 0.45f;  }
            else if (keyData == Keys.Left)
            { xb -= 0.45f; }
            return base.ProcessDialogKey(keyData);
        }
    }
}
