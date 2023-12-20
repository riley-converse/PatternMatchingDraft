using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternMatching.Classes;

namespace PatternMatching.Interfaces
{
    internal interface IPatternMatcher
    {
        public IState CurrentState { get; set; }
        public bool Active { get; set; }
        public ICharCollection[]? Definitions { get; set; }
        public ICharCollection? Prerequisite { get; set; }
        public ICharCollection? Terminator { get; set; }
        public int CurrentCharIndex { get; set; }
        public int CharGroupIndex { get; set; }
        public StringBoundary MatchedBoundary { get; set; }
    }
}
