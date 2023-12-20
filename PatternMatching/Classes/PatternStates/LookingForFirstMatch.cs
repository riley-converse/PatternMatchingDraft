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
        public void GetState(IPatternMatcher pattern, char ch)
        {
            if (FoundFirstMatch(pattern,ch))
            {
                if (pattern.Definitions.Length > 1)
                {
                    pattern.CurrentState = new ScanningForAdditionalMatches();
                }
                else
                {
                    Console.WriteLine("Only one match pattern");
                    if (pattern.Terminator != null)
                    {
                        pattern.CurrentState = new CheckingForTerminator();
                    }
                    else
                    {
                        Console.WriteLine("No terminator, completing");
                        pattern.CurrentState = new Completed();
                        pattern.CurrentState.GetState(pattern,ch);
                    }
                }
            }
            else
            {
                pattern.CurrentState = new FailedFirstMatch();
                Console.WriteLine("Going back to listening for :"+ch);
                pattern.CurrentState.GetState(pattern, ch);
            }

        }

        public bool FoundFirstMatch(IPatternMatcher pattern, char ch)
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
