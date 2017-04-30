using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsApplication4
{
    class Read_file
    {
        public Read_file(ref  List<Tpoint> l, string arg, ref Tpoint rc)
        {
            FileStream input = new FileStream(arg, FileMode.Open, FileAccess.Read);
            BinaryReader Binput = new BinaryReader(input);

            rc.r = Binput.ReadInt32();
            rc.c = Binput.ReadInt32(); 
            int r0, c0;
            Tpoint b;
            while (Binput.PeekChar() != -1)
            {
                r0 = Binput.ReadInt32();
                c0 = Binput.ReadInt32();
                b = new Tpoint(r0, c0);
                l.Add(b);
            
            }
            Binput.Close();
            input.Close();
        }
    }
}
