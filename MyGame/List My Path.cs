using System;
using System.Collections.Generic;
using System.Text;

namespace Draw
{
  public   class List_My_Path
    {
       public  List<position> lmp1 = new List<position>();
        public List_My_Path()
        {
            
        }
      public void add(position p)
      {
          lmp1.Add(p);
      }
      public void remove(position l)
      {
          lmp1.Remove(l);
      }
      public int count() 
      {
          return lmp1.Count;
      }
    }
}
