using PatternMatching.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Interfaces
{
    internal interface IState
    {
        public void GetState(Pattern pattern, char ch);
    }
}
