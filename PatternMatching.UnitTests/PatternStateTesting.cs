using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternMatching.Classes;
using PatternMatching.Classes.PatternStates;
using PatternMatching.Interfaces;

namespace PatternMatching.UnitTests
{
    [TestClass]
    public class PatternStateTesting
    {
        [TestMethod]
        public void TestListening()
        {
            // ARRANGE
            Pattern test = new Pattern();
            char ch = 'a';

            // ACT

            test.AddPrerequisite(new CharGroup('a'));
            Listening statePat = new Listening();
            test.CurrentState = statePat;

            Assert.IsTrue(test.CurrentState != statePat);
        }
    }
}
