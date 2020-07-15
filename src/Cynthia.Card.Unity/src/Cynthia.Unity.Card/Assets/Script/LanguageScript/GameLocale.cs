using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.LanguageScript
{
    class GameLocale
    {
        public string Name { get; set; }
        public string Filename { get; set; }

        public GameLocale(string name, string filename)
        {
            Name = name;
            Filename = filename;
        }
    }
}
