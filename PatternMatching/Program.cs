using PatternMatching.Classes;

namespace PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharGroup number = new CharGroup('1');
            CharGroup test = new CharGroup('c','d','c', 'b', 'a', 'b');
            CharGroup testRemoval = new CharGroup('d', 'm', 'a');

            test.AppendDefinition('e', 'f', 'g');

            CharGroup merged = number + test;
            
            Console.WriteLine(test.ToString());

            Console.WriteLine("Char"+test.ContainsChar('d'));
            Console.WriteLine("bool" + !test.ContainsChar('d'));
            Console.WriteLine(test.ContainsChar('d'));
            Console.WriteLine("Addition"+(number + test).ContainsChar('a'));
            Console.WriteLine("Addition"+merged.ContainsChar('a'));
            Console.WriteLine(merged.ToString());

          
            CharGroup newl = new(merged.ClearArrayDuplicates(merged.Definition));
            Console.WriteLine(newl.ToString());


            Console.WriteLine("BEFORE: " + test.ToString());
            Console.WriteLine("TO REMOVE: " + testRemoval.ToString());
            test.RemoveDefinition(testRemoval.Definition);
            Console.WriteLine("AFTER: "+test.ToString());
        }
    }
}
