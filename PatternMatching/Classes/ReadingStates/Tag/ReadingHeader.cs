using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternMatching.Interfaces;

namespace PatternMatching.Classes.ReadingStates.Tag
{
    internal class ReadingHeader
    {
        private IPatternMatcher StartingPattern { get; set; }

        public ReadingHeader(IPatternMatcher startPattern)
        {
            StartingPattern = startPattern;
        }

        public void Process(char c)
        {

        }
    }
}
