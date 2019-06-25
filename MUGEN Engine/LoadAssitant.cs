using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUGEN_Engine
{
    static class LoadAssitant
    {
        public static void LoadProjectBase(string path, string name)
        {
            //create home directory
            CreateDirectory(path, name);
            string _home = $@"{path}\{name}";

            //create main directories
            CreateDirectory(_home, "chars");
            CreateDirectory(_home, "data");
            CreateDirectory(_home, "Elecbyte.MUGEN.libs");
                string _libs = $@"{_home}\Elecbyte.MUGEN.libs";
                CreateDirectory(_libs, "Microsoft.VC90.CRT");
            CreateDirectory(_home, "font");
            CreateDirectory(_home, "Microsoft.VC90.CRT");
            CreateDirectory(_home, "old_tools");
                string _old = $@"{_home}\old_tools";
                CreateDirectory(_old, "data");  
                CreateDirectory(_old, "font");
            CreateDirectory(_home, "plugins");
                string _plugin = $@"{_home}\plugins";
                CreateDirectory(_plugin, "Microsoft.VC90.CRT");
            CreateDirectory(_home, "sound");
            CreateDirectory(_home, "stages");
            CreateDirectory(_home, "work");
                string _work = $@"{_home}\work";
                CreateDirectory(_work, "common");
                    string _cmn = $@"{_work}\common";
                    CreateDirectory(_cmn, "sound");
                CreateDirectory(_work, "fight");
                    string _ft = $@"{_work}\fight";
                    CreateDirectory(_ft, "simul");
                    CreateDirectory(_ft, "sound");
                    CreateDirectory(_ft, "turns");
                CreateDirectory(_work, "fightfx");
                CreateDirectory(_work, "font");
                CreateDirectory(_work, "mugen1");
                    string _mu1 = $@"{_work}\mugen1";
                    CreateDirectory(_mu1, "fight");
                        string _f = $@"{_mu1}\fight";
                        CreateDirectory(_f, "simul");
                        CreateDirectory(_f, "turns");
                    CreateDirectory(_mu1, "system");
                CreateDirectory(_work, "stages");
                CreateDirectory(_work, "system");
                    string _sys = $@"{_work}\system";
                    CreateDirectory(_sys, "sound");
        }

        public static void LoadContent(string parent)
        {

        }

        public static DirectoryInfo CreateDirectory(string path, string name)
        {
            return Directory.CreateDirectory($@"{path}\{name}");
        }
    }
}
