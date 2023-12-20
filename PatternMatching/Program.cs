using PatternMatching.Classes;

namespace PatternMatching
{
    internal class Program
    {
        // driver
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

            CharGroup letter = new CharGroup('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                                             'm','n','o','p','q','r','s','t','u','v','w','x','y','z');
            CharGroup leftCarrot = new CharGroup('<');
            CharGroup start = new CharGroup('\\');
            CharGroup space = new CharGroup(' ');
            CharGroup integers = new CharGroup('1', '2', '3');
            CharGroup operators = new CharGroup('!', '>', '<', '.');

            // pattern testing
            string input = "remember cool the < html place of <! and such 3<html> so that<html style> ";
            Pattern htmlTagPattern = new (letter);
            htmlTagPattern.AddPrerequisite(leftCarrot);
            htmlTagPattern.AddTerminiator(space);
            // space + operators

            Console.WriteLine(test.ToString());
            int testIndex = 0;

            foreach(char c in input)
            {
                Console.WriteLine($"Processing Input[{testIndex}]: " + c);
                htmlTagPattern.ProcessChar(c);
                testIndex++;
            }
            Console.WriteLine("==================");
            Console.WriteLine("OUTPUT:");
            if (htmlTagPattern.MatchedBoundary.StartIndex<0)
            {
                Console.WriteLine("NO MATCH");
            }
            else
            {
                Console.WriteLine($"Match Boundaries ({htmlTagPattern.MatchedBoundary.StartIndex}:{htmlTagPattern.MatchedBoundary.EndIndex})");
                Console.WriteLine($"Extracted Text: ");

                for (int i = htmlTagPattern.MatchedBoundary.StartIndex; i <= htmlTagPattern.MatchedBoundary.EndIndex; i++)
                {
                    Console.Write($"[{i}:{input[i]}]");
                }
            }


            Console.Write("\n\n\n\n");
            


        }
    }
}
