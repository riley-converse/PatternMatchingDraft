using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes.PatternStates
{
    internal class FailedFirstMatch : IState
    {
        public void GetState(Pattern pattern, char ch)
        {
            if (MeetsPrerequisite(pattern,ch)) 
            {
                pattern._currentState = new LookingForFirstMatch();
            }
            else
            {
                pattern._currentState = new Listening();
            }
        }

        public bool MeetsPrerequisite(Pattern pattern, char ch)
        {
            if (pattern.PrerequisiteMet || pattern.Prerequisite is null) { return true; }
            else
            {
                return pattern.Prerequisite.ContainsChar(ch);
            }

        }
    }
}
