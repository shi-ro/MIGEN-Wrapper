using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUGEN_Engine
{
    class StateDef
    {
        StateTrigger trigger;
        string type = ""; // can either be S C A or L ( standing, crouching, air, lying down )
        string movetype = ""; // can either be A I H or U ( attacking, idle, hit, unchanged ) //default I
        string physics = ""; // can either be S C or A ( special friction, normal friction, accelerate downwards )
        string anim = ""; // defined animation state
        // optional veriables
        string velset = ""; // set velocity
        string ctrl = ""; // allow player control
        string poweradd = ""; // let an action add to your power bar
        string juggle = ""; // juggle points required for move to hit
        string facep2 = ""; // force turn twoards p2
        string hitdefpersist = ""; // any active hitdefs will stay 
        string movehitpersist = ""; // move hit information from previous state persists
        string hitcountpersist = ""; // ammount of attacks done persists between states
        string sprpriority = ""; // where p1 appears 
    }
}
