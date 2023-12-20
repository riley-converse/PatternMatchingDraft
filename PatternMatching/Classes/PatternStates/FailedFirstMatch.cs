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
        public void GetState(IPatternMatcher pattern, char ch)
        {
            if (MeetsPrerequisite(pattern,ch)) 
            {
                pattern.CurrentState = new LookingForFirstMatch();
            }
            else
            {
                pattern.CurrentState = new Listening();
            }
        }

        public bool MeetsPrerequisite(IPatternMatcher pattern, char ch)
        {
            if (pattern.Prerequisite == null) { return true; }
            return pattern.Prerequisite.ContainsChar(ch);
            

        }
    }
}
