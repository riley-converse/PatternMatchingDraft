using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PatternMatching.Interfaces;

namespace PatternMatching.Classes
{
    internal class PatternGroup : IPatternMatcher
    {
        public IState CurrentState { get; set; }
        public bool Active { get; set; }
        public ICharCollection[]? Definitions { get; set; }
        public ICharCollection? Prerequisite { get; set; }
        public ICharCollection? Terminator { get; set; }
        public int CurrentCharIndex { get; set; }
        public int CharGroupIndex { get; set; }
        public StringBoundary MatchedBoundary { get; set; }

        public IPatternMatcher[] GroupOfPatterns { get; set; }

        public PatternGroup(params IPatternMatcher[] groupOfPatterns)
        {
            GroupOfPatterns = groupOfPatterns;
        }

        public void ProcessChar(char ch)
        {
            for (int i = 0; i < GroupOfPatterns.Length; i++)
            {
                while (GroupOfPatterns[i].Active)
                {
                    GroupOfPatterns[i].ProcessChar(ch);
                }
                
            }

        }
    }
}
