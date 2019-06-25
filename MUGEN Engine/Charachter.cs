using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUGEN_Engine
{
    class Charachter
    {
        public Definition def;
        public CommandSet cmd;
        public Constants cns; 
        public States st;     // usually wirites to the same file as constants
        // UNDEFINED : stcommon
        public Sprite sprite;
        public Animation anim;
    }
}
