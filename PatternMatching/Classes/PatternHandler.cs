using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes
{
    internal class PatternHandler
    {
        public Pattern[] PatternArray { get; private set; }

        public string Input { get; private set; }
        
        public PatternHandler(string input, params Pattern[] patternArray) 
        {
            PatternArray = patternArray;
        }


    }
}
