using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes
{
    internal record StringBoundary()
    {
        public int StartIndex { get; set; } = -1;
        public int EndIndex { get; set; } = -1;

    }
}
