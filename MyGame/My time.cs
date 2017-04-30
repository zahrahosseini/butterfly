using System;
using System.Collections.Generic;
using System.Text;

namespace Draw
{
   public  class My_time:System.Windows.Forms.Timer
    {
       public  int l;

     /*  public List_My_Ball lmb = new List_My_Ball();
       protected override void OnTick(EventArgs e)
       {
           if (this.Enabled)
               lmb.moveball();
       }
      */  protected override void OnTick(EventArgs e)
        {
            if (this.Enabled)
            {
               
                l++;
             
            }
           
        }
        public int gettime()
        {
            return l;
        }
    }
}
