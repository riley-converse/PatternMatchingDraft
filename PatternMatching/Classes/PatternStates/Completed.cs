using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes.PatternStates
{
    internal class Completed : IState
    {
        public void GetState(Pattern pattern, char ch)
        {
  
            if (pattern.Terminator is null)
            {
                pattern.MatchedBoundary.EndIndex = pattern.CurrentCharIndex;
            }
            else
            {
                pattern.MatchedBoundary.EndIndex = pattern.CurrentCharIndex-1;
            }
            Console.WriteLine("Found Match: " + pattern.MatchedBoundary.StartIndex + ":" + pattern.MatchedBoundary.EndIndex);
            pattern.Active = false;
        }
    }
}
