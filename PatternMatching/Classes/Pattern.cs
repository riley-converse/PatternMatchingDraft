using PatternMatching.Classes.PatternStates;
using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes
{
    internal class Pattern : IPatternMatcher
    {
        public ICharCollection[]? Definitions { get; set; }
        public ICharCollection? Prerequisite { get; set; } = null;
        public ICharCollection? Terminator { get; set; } = null;

        public bool PrerequisiteMet { get; set; } = true;
        public bool UsingTerminator { get; set; } = true;

        public bool Active { get; set; } = true;

        public List<IState> PStates { get; set; }
        public StringBoundary MatchedBoundary { get; set; } = new StringBoundary();
        public int CurrentCharIndex { get; set; } = 0;
        public int CharGroupIndex { get; set; } = 0;

        public IState CurrentState { get; set; } = new Listening();

        public Pattern(params ICharCollection[] definitions) 
        { 
            Definitions = definitions;
            PStates = new List<IState>();
        }

        public void AddCharGroup(params ICharCollection[] definitions)
        {
            ICharCollection[] referenceTemp = Definitions;
            ICharCollection[] parameterTemp = definitions;

            Definitions = new ICharCollection[referenceTemp.Length + parameterTemp.Length];
            referenceTemp.CopyTo(Definitions, 0);
            parameterTemp.CopyTo(Definitions, referenceTemp.Length);
        }

        public void AddPrerequisite(ICharCollection prequisite)
        {
            Prerequisite = prequisite;
            PrerequisiteMet = false;
        }

        public void AddTerminiator(ICharCollection terminator)
        {
            Terminator = terminator;
            UsingTerminator = false;
        }

        public void ProcessChar(char ch)
        {
            if (Active)
            {
                CurrentState.GetState(this, ch);
                CurrentCharIndex++;
            }
        }
    }
}
