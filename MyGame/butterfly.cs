using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;

namespace Draw
{
    public  class butterfly
    {
        public GLUquadric q1 = GLU.gluNewQuadric();
        
      public   butterfly() { }
    public void     butterflydraw(){
      
        GLU.gluQuadricNormals(q1, GLU.GLU_SMOOTH);
        GLU.gluQuadricTexture(q1, 1);
        GL.glTranslatef(0.1f, 0.0f, 0);
                    GL.glRotatef(90, 1.0f, 0.0f, 0.0f);
                    GL.glColor3f(0.5f,0.24f, 0.43f);
                    GLU.gluCylinder(q1, 0.1,0.1,0.5f, 13, 13);
               
                    GL.glTranslatef(0.11f, 0.19f , 0);
                    GLU.gluSphere(q1, 0.15, 32, 32);
                 
                     GL.glTranslatef(1.19f,0,0);
                     GL.glBegin(GL.GL_TRIANGLES);					// start drawing a triangle
                     GL.glColor3f(1.0f, 0.0f, 0.0f);					// red
                     GL.glVertex3f(0.2f, 0.5f, 0.0f);				// top point of the triangle
                     GL.glColor3f(0.0f, 1.0f, 0.0f);					// green
                     GL.glVertex3f(-0.1f, -0.25f, 0.0f);				// left point of the triangle
                     GL.glColor3f(0.0f, 0.0f, 1.0f);					// blue
                     GL.glVertex3f(0.5f, -0.7f, 0.0f);				// right point of the triangle
                     GL.glEnd();
                    
                     GL.glTranslatef(1.19f, 0, 0);
                     GL.glBegin(GL.GL_TRIANGLES);					// start drawing a triangle
                     GL.glColor3f(1.0f, 0.0f, 0.0f);					// red
                     GL.glVertex3f(-0.3f, 0.5f, 0.0f);				// top point of the triangle
                     GL.glColor3f(0.0f, 1.0f, 0.0f);					// green
                     GL.glVertex3f(0.0f, -0.25f, 0.0f);				// left point of the triangle
                     GL.glColor3f(0.0f, 0.0f, 1.0f);					// blue
                     GL.glVertex3f(-0.5f, -0.7f, 0.0f);				// right point of the triangle
                     GL.glEnd();
                     }
    }
}
