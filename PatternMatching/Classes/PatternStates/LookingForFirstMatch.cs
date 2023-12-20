using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes.PatternStates
{
    internal class LookingForFirstMatch : IState
    {
        public void GetState(Pattern pattern, char ch)
        {
            if (FoundFirstMatch(pattern,ch))
            {
                if (pattern.Definitions.Length > 1)
                {
                    pattern._currentState = new ScaningForAdditionalMatches();
                }
                else
                {
                    if (pattern.Terminator != null)
                    {
                        pattern._currentState = new CheckingForTerminator();
                    }
                    else
                    {
                        pattern._currentState = new Completed();
                    }
                    
                   
                }
            }
            else
            {
                pattern._currentState = new FailedFirstMatch();
                Console.WriteLine("Going back to listening for :"+ch);
                pattern._currentState.GetState(pattern, ch);
            }

        }

        public bool FoundFirstMatch(Pattern pattern, char ch)
        {
            pattern.CharGroupIndex = 0;
            if (pattern.Definitions[pattern.CharGroupIndex].ContainsChar(ch))
            {
                Console.WriteLine($"Found first match:[{ch}]");
                pattern.MatchedBoundary.StartIndex = pattern.CurrentCharIndex;
                pattern.CharGroupIndex++;
                return true;
            }
            return false;
        }
    }
}
