using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes.PatternStates
{
    internal class Listening : IState
    {
        public void GetState(IPatternMatcher pattern, char ch)
        {
            if (MeetsPrerequisite(pattern, ch))
            {
                Console.WriteLine("Meets pre");
                pattern.CurrentState = new LookingForFirstMatch();
                if (pattern.CurrentCharIndex == 0 && pattern.Prerequisite is not null ) {  pattern.CurrentState.GetState(pattern, ch); }
            }
        }

        public bool MeetsPrerequisite(IPatternMatcher pattern, char ch)
        {
            if (pattern.Prerequisite is null) { return true; }
            else if (pattern.CurrentCharIndex == 0 && pattern.Prerequisite.ContainsChar('\\')) { return true; }
            else
            {
                return pattern.Prerequisite.ContainsChar(ch);
            }

        }
    }
}
