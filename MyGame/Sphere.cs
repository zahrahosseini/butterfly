using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;

namespace Draw
{
   public  class Sphere
    {
        public GLUquadric q = GLU.gluNewQuadric();
        
         public Sphere() {}
       public void getbox(float x,float y,float z,float r)
       {
           GL.glTranslatef(x, y, z);
           GLU.gluQuadricNormals(q, GLU.GLU_SMOOTH);
           GLU.gluQuadricTexture(q, 1);
           GLU.gluSphere(q, r, 32, 32); 
       }

       public void getbox(){
          // GL.glColor3f(0, 1, 0);
           GLU.gluQuadricNormals(q, GLU.GLU_SMOOTH);
           GLU.gluQuadricTexture(q, 1);
           GLU.gluSphere(q, 0.25, 32, 32);
       } 
          /*   GL.glBegin(GL.GL_QUADS);
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
             GL.glEnd();*/
      
    }
}
