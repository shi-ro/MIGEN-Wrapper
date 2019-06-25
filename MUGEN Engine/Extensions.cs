using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUGEN_Engine
{
    public static class Extensions
    {
        public static Bitmap Duplicate( this Bitmap t)
        {
            Bitmap ret = new Bitmap(t.Width, t.Height);
            for(int y = 0; y < t.Height; y++)
            {
                for (int x = 0; x < t.Width; x++)
                {
                    ret.SetPixel(x, y, t.GetPixel(x, y));
                }
            }
            return ret;
        }
    }
}
