using PatternMatching.Classes.PatternStates;
using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes
{
    internal class Pattern
    {
        public CharGroup[] Definitions { get; private set; }
        public CharGroup? Prerequisite { get; private set; } = null;
        public CharGroup? Terminator { get; private set; } = null;

        public bool PrerequisiteMet { get; set; } = true;
        public bool UsingTerminator { get; set; } = true;

        public bool Active = true;

        public bool RanONcePre = false;

        public List<IState> PStates { get; set; }
        public StringBoundary MatchedBoundary { get; set; } = new StringBoundary();
        public int CurrentCharIndex { get; set; } = 0;
        public int CharGroupIndex { get; set; } = 0;

        public IState _currentState = new Listening();

        public Pattern(params CharGroup[] definitions) 
        { 
            Definitions = definitions;
            PStates = new List<IState>();
        }

        public void AddCharGroup(params CharGroup[] definitions)
        {
            CharGroup[] referenceTemp = Definitions;
            CharGroup[] parameterTemp = definitions;

            Definitions = new CharGroup[referenceTemp.Length + parameterTemp.Length];
            referenceTemp.CopyTo(Definitions, 0);
            parameterTemp.CopyTo(Definitions, referenceTemp.Length);
        }

        public void AddPrerequisite(CharGroup prequisite)
        {
            Prerequisite = prequisite;
            PrerequisiteMet = false;
        }

        public void AddTerminiator(CharGroup terminator)
        {
            Terminator = terminator;
            UsingTerminator = false;
        }

        public void ProcessChar(char ch)
        {
            if (Active)
            {
                _currentState.GetState(this, ch);
                CurrentCharIndex++;

            }
        }
    }
}
