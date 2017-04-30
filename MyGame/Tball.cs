using System;
using System.Collections.Generic;
using System.Text;

namespace Draw
{
   public  class Tball:position
    {
     public    int counter;
      public  int data;
    public    Tball(float x1, float y1, float z1, int counter1,int data1)
       {
           x = x1;
           y = y1;
           z = z1;
           counter = counter1;
           data = data1;
       }
       public Tball() { }
    }
}
