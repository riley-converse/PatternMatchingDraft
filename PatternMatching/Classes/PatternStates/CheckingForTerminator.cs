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
        public void GetState(Pattern pattern, char ch)
        {
            if (matchesTerminator(pattern, ch))
            {
                
                pattern._currentState = new Completed();
                pattern._currentState.GetState(pattern, ch);
              
            }
            else
            {
                pattern.CharGroupIndex = 0;
                pattern._currentState = new ScaningForAdditionalMatches();
                pattern._currentState.GetState(pattern, ch);
                Console.WriteLine("looking for more");
            }
        }

        public bool matchesTerminator(Pattern pattern, char ch)
        {
            Console.WriteLine("ch: " +ch);
            if (pattern.Terminator.ContainsChar(ch))
            {
                Console.WriteLine("TRUE: ch");
                return true;
            }
            return false;
        }
    }
}
