using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;

namespace Draw
{
  public   class Squre
    {
      public LoadTextures lo = new LoadTextures();
        public Squre()
        {}
        public void getsq(){
            GL.glRotatef(70, 1, 0, 0);
            GL.glScalef(0.25f, 0.25f, 0.25f);
            GL.glBegin(GL.GL_QUADS);
            GL.glNormal3f(0.0f, 0.0f, 1.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, 1.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 1.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(1.0f, -0.5f, 1.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-1.0f, -0.5f, 1.0f);

            // back face
            GL.glNormal3f(0.0f, 0.0f, -1.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, -1.5f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(1.0f, -1.0f, 0.5f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(1.0f, -0.5f, 0.5f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, -0.5f, 0.5f);
            // Top Face
            GL.glNormal3f(0.0f, 1.0f, 0.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(1.0f, -0.5f, 1.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-1.0f, -0.5f, 1.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(1.0f, -0.5f, 0.5f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, -0.5f, 0.5f);
            // Bottom Face
            GL.glNormal3f(0.0f, -1.0f, 0.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, 1.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 1.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 0.5f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 0.5f);
            // Right face
           /* GL.glNormal3f(1.0f, 0.0f, 0.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, -1.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(1.0f, 1.0f, -1.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(1.0f, 1.0f, 1.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 1.0f);
            // Left Face
            GL.glNormal3f(-1.0f, 0.0f, 0.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, -1.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, 1.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-1.0f, 1.0f, 1.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-1.0f, 1.0f, -1.0f);


            */



            GL.glEnd();
            GL.glScalef(4, 4, 4);
            GL.glLoadIdentity();
        }
    }
}
