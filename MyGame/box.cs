using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;

namespace Draw
{
  public   class Box:Tball
    {
      public LoadTextures lo = new LoadTextures();
     public    Box() { }
        public void getbox(){
          GLUquadric q = GLU.gluNewQuadric();
            color c1=new color ();
           GL.glScalef(0.125f, 0.125f, 0.125f);
         GL.glBegin(GL.GL_QUADS);
             // Front Face
         // Front Face 
          
         GL.glNormal3f(0.0f, 0.0f, 1.0f);
         GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, 1.0f);
         GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 1.0f);
         GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(1.0f, 1.0f, 1.0f);
         GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-1.0f, 1.0f, 1.0f);
         // Back Face
         GL.glNormal3f(0.0f, 0.0f, -1.0f);
         GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, -1.0f);
         GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-1.0f, 1.0f, -1.0f);
         GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(1.0f, 1.0f, -1.0f);
         GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, -1.0f);
         // Top Face
         GL.glNormal3f(0.0f, 1.0f, 0.0f);
         GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-1.0f, 1.0f, -1.0f);
         GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-1.0f, 1.0f, 1.0f);
         GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(1.0f, 1.0f, 1.0f);
         GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(1.0f, 1.0f, -1.0f);
         // Bottom Face
         GL.glNormal3f(0.0f, -1.0f, 0.0f);
         GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-1.0f, -1.0f, -1.0f);
         GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(1.0f, -1.0f, -1.0f);
         GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(1.0f, -1.0f, 1.0f);
         GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-1.0f, -1.0f, 1.0f);
         // Right face
         GL.glNormal3f(1.0f, 0.0f, 0.0f);
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
             
             
            GL.glEnd();GL.glScalef(8, 8, 8);
               GL.glTranslatef(0,-0.1f, 0.3f);
               GL.glColor3fv(c1.yellow);
               lo.LoadTextures1(5);
            GLU.gluQuadricNormals(q, GLU.GLU_SMOOTH);
             GLU.gluQuadricTexture(q,1);
             GLU.gluDisk(q, 0.01, 0.1, 32, 32);
             GL.glTranslatef(0, -0.01f, -0.3f);
             GLU.gluDisk(q, 0.01, 0.1, 32, 32);
        }
    }
}

        
       
           