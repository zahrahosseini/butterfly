using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;

namespace Draw
{
  public   class Disc
    {
        public GLUquadric q = GLU.gluNewQuadric();
        public Disc() { }
        public void getbox()
        {
            
            GL.glRotatef(80, 1, 0, 0);
            // GL.glColor3f(0, 1, 0);
            GLU.gluQuadricNormals(q, GLU.GLU_SMOOTH);
            GLU.gluQuadricTexture(q, 1);
            GLU.gluDisk(q,0.01,0.2,32,32);
            GL.glRotatef(80, -1, 0, 0);
        } 
    }
}
