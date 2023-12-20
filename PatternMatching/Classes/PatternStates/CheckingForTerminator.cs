using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes.PatternStates
{
    internal class CheckingForTerminator : IState
    {
        public void GetState(IPatternMatcher pattern, char ch)
        {
            if (matchesTerminator(pattern, ch))
            {
                
                pattern.CurrentState = new Completed();
                pattern.CurrentState.GetState(pattern, ch);
              
            }
            else
            {
                pattern.CharGroupIndex = 0;
                pattern.CurrentState = new ScanningForAdditionalMatches();
                pattern.CurrentState.GetState(pattern, ch);
                Console.WriteLine("looking for more");
            }
        }

        public bool matchesTerminator(IPatternMatcher pattern, char ch)
        {
            Console.WriteLine("ch: " +ch);
            if (pattern.Terminator.ContainsChar(ch))
            {
                Console.WriteLine($"Terminator Required and Satisfied:[{ch}]");
                return true;
            }
            return false;
        }
    }
}
