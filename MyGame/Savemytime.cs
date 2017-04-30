using System;
using System.Collections.Generic;
using System.Text;

namespace Draw
{
   
    public class Savemytime
    { 
        public  int lnumber;
       public  Savemytime() { }
        public void  inc(){
        lnumber++;
        }
        public int gettime(){
            return lnumber;
        }
    }
}
