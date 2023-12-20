using PatternMatching.Classes;
namespace PatternMatching.UnitTests
{
    [TestClass]
    public class CharGroupTests
    {

        [TestMethod]
        public void TestFoundDefinition()
        {
            //ARRANGE
            char[] charList = new char[] { 'a', 'b', '1' };

            // ACT
            CharGroup group = new CharGroup(charList);

            // ASSERT
            Assert.IsTrue(group.ContainsChar('a'));
            Assert.IsTrue(group.ContainsChar('b'));
            Assert.IsTrue(group.ContainsChar('1'));
            Assert.IsFalse(group.ContainsChar('2'));
            Assert.IsFalse(group.ContainsChar('c'));
        }

        [TestMethod]
        public void TestPlusOperators()
        {
            // ARRANGE
            char[] charList = new char[] { 'a', 'b', '1' };
            char[] charList2 = new char[] { 'c', 'd', '2' };

            // ACT
            CharGroup group = new CharGroup(charList);
            CharGroup group2 = new CharGroup(charList2);


            // ASSERT
            Assert.IsFalse(group.ContainsChar('c'));
            Assert.IsFalse(group2.ContainsChar('a'));

            Assert.IsTrue((group2 + group).ContainsChar('a'));
            Assert.IsTrue((group2 + group).ContainsChar('c'));

        }

        [TestMethod]
        public void TestMinusOperator()
        {
            // ARRANGE
            char[] charList = new char[] { 'a', 'b', 'c', '1' };
            char[] charList2 = new char[] { 'c', 'd', '2' };

            // ACT
            CharGroup group = new CharGroup(charList);
            CharGroup group2 = new CharGroup(charList2);
            CharGroup group3 = (group - group2);

            // ASSERT
            Assert.IsTrue(group3.ContainsChar('a'));
            Assert.IsTrue(group3.ContainsChar('1'));
            Assert.IsFalse(group3.ContainsChar('c'));

        }

        [TestMethod]
        public void TestRemoveDefinitions()
        {
            char[] charList = new char[] { 'a', 'b', 'c', '1' };

            CharGroup group = new CharGroup(charList);
            group.RemoveDefinition('1','b');

            Assert.IsTrue(group.ContainsChar('a'));
            Assert.IsFalse(group.ContainsChar('b'));
            Assert.IsFalse(group.ContainsChar('1'));
        }
    }
}