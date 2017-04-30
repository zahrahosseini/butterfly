using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace WindowsApplication4
{

    class Write_file
    {
        public Write_file(List<Tpoint> l, string arg, Tpoint rc)
        {
            FileStream output = new FileStream(Directory.GetCurrentDirectory() + @"\filesw" + @"\" + arg + ".txt", FileMode.Create, FileAccess.Write);
            BinaryWriter Boutput = new BinaryWriter(output);

            Boutput.Write(rc.r);//playground r*c
            Boutput.Write(rc.c);

            for (int i = 0; i < l.Count; i++)
            {
                output.Position = (i + 1) * sizeof(Int32) * 2;//2:int32 r,int32 c
                Boutput.Write(l[i].r);
                Boutput.Write(l[i].c);
            }
            Boutput.Close();
            output.Close();
        }

    }
}
