using System;
using System.Collections.Generic;
using System.Text;

namespace Draw
{
  public   class Two_time:System.Windows.Forms.Timer
    {
        public List_My_Ball lmb = new List_My_Ball();
        protected override void OnTick(EventArgs e)
        {
            if(this.Enabled)
            lmb.moveball();
        }
    }
}
