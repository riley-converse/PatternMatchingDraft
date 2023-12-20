using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Interfaces
{
    internal interface ICharCollection
    {
        public void AppendDefinition(params char[] definitions);

        public bool ContainsChar(char ch);
    }
}
