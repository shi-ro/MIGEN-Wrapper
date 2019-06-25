using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUGEN_Engine
{
    public class SingularSprite
    {
        public int group;
        public int item;
        public Bitmap image;
        public string imagePath;
        public string name;
        public List<ColisionBox> colisions = new List<ColisionBox>();
        public int axisX;
        public int axisY;
    }
}
