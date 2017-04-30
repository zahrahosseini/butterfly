using System;
using System.Collections.Generic;
using System.Text;

namespace Draw
{
  public   class List_My_Ball:Tball
  {
      public Tball ttball;
  
        public Random r = new Random();
      public Assume_path as12 = new Assume_path();
        public Random r1;
       public  int a=0;
      public List<Tball> lmp1;
        
        public List_My_Ball() 
        {
           // lmp1 = new List<Tball>[4];
           // lmp1[0] = new List<Tball>();
            lmp1 = new List<Tball>();
            r1 = new Random(r.Next());
        }
      public void moveball()
      {
          for (int i = 0; i < this.lmp1.Count; i++)
              this.lmp1[i].counter = (this.lmp1[i].counter + 1) % 12;
          a = r1.Next(3);
          this.ttball = new Tball(as12.MyPath[0].x, as12.MyPath[0].y, 0, 0, a);
          this.lmp1.Insert(this.lmp1.Count, ttball);
      }
    }
}
