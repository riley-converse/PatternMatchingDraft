using PatternMatching.Classes;

namespace PatternMatching
{
    internal class Program
    {
        // driver
        static void Main(string[] args)
        {
            CharGroup letter = new CharGroup('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z');

            CharGroup integers = new CharGroup('1', '2', '3');
            CharGroup operators = new CharGroup('!', '>', '<', '.');

            string userInputString;
            string userChoice;
            Console.WriteLine("Pattern Driver");

            Console.WriteLine("Enter Input to Test: ");
            userInputString = Console.ReadLine() + " ";


            Console.Clear();
            Console.WriteLine("Input: " + userInputString);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Select Prerequisite: ");
            Console.WriteLine("1) None");
            Console.WriteLine("2) Letter");
            Console.WriteLine("3) Operator");
            Console.WriteLine("4) Custom Value");
            Console.WriteLine("Enter here: ");

            userChoice = Console.ReadLine();
            CharGroup prerequisite = null;


            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("No Prerequisite will be used.");
                    break;
                case "2": Console.WriteLine("Letter CharGroup loaded into Prerequisite");
                    prerequisite = letter;
                    break;
                case "3":
                    Console.WriteLine("Operator CharGroup loaded into Prerequisite");
                    prerequisite = operators;
                    break;
                case "4":
                    Console.WriteLine("Please enter custom values as one string. Enter only characters to be added: ");
                    userChoice = Console.ReadLine();
                    char[] chars = userChoice.ToCharArray();
                    prerequisite = new CharGroup(chars);
                    break;
                default:
                   
                    break;
            }

            Console.Clear();
            Console.WriteLine("Input: " + userInputString);
            Console.WriteLine("Prerequisite: " + prerequisite?.ToString());
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Select Terminator: ");
            Console.WriteLine("1) None");
            Console.WriteLine("2) Letter");
            Console.WriteLine("3) Operator");
            Console.WriteLine("4) Custom Value");
            Console.WriteLine("Enter here: ");

            userChoice = Console.ReadLine();
            CharGroup terminator = null;
            
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("No terminator will be used.");
                    break;
                case "2":
                    Console.WriteLine("Letter CharGroup loaded into Terminator");
                    terminator = letter;
                    break;
                case "3":
                    Console.WriteLine("Operator CharGroup loaded into Terminator");
                    terminator = operators;
                    break;
                case "4":
                    Console.WriteLine("Please enter custom values as one string. Enter only characters to be added: ");
                    userChoice = Console.ReadLine();
                    char[] chars = userChoice.ToCharArray();
                    terminator = new CharGroup(chars);
                    break;
                default:
                    break;
            }

            // content patterns ------------------------
            bool RunAgain = true;
            Pattern userPattern = new Pattern();
            CharGroup contents = new CharGroup();
            List<string> addedPatternsOutput = new List<string>();
            while (RunAgain)
            {


                Console.Clear();
                Console.WriteLine("Input: " + userInputString);
                Console.WriteLine("Prerequisite: " + prerequisite?.ToString());
                Console.WriteLine("Terminator: " + terminator?.ToString());
                Console.WriteLine("Content Definition Length: " + userPattern.Definitions.Length);
                foreach (string str in addedPatternsOutput)
                    Console.Write(str.ToString());
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("Select Content Pattern: ");
                Console.WriteLine("1) None");
                Console.WriteLine("2) Letter");
                Console.WriteLine("3) Operator");
                Console.WriteLine("4) Custom Value");
                Console.WriteLine("5) Stop Looping");
                Console.WriteLine("Enter here: ");

                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("nope.");
                        break;
                    case "2":
                        Console.WriteLine("Letter CharGroup loaded into Content");
                        contents = letter;
                        addedPatternsOutput.Add("[Letter] ");
                        userPattern.AddCharGroup(contents);
                        break;
                    case "3":
                        Console.WriteLine("Operator CharGroup loaded into Content");
                        contents = operators;
                        userPattern.AddCharGroup(contents);
                        addedPatternsOutput.Add("[Operator] ");
                        break;
                    case "4":
                        Console.WriteLine(
                            "Please enter custom values as one string. Enter only characters to be added: ");
                        userChoice = Console.ReadLine();
                        char[] chars = userChoice.ToCharArray();
                        contents = new CharGroup(chars);
                        userPattern.AddCharGroup(contents);
                        addedPatternsOutput.Add($"[CustomValue: {contents.ToString()}] ");
                        break;
                    default:
                        RunAgain = false;
                        break;
                }
               
                
            }

            if (prerequisite is not null)
                userPattern.AddPrerequisite(prerequisite);

            if (terminator is not null)
                userPattern.AddTerminiator(terminator);

            Console.Clear();

            int anIndex = 0;
            foreach (char c in userInputString)
            {
                Console.WriteLine($"Processing Input[{anIndex}]: " + c);
                userPattern.ProcessChar(c);
                anIndex++;
            }

            
            Console.WriteLine("Input: " + userInputString);
            Console.WriteLine("Prerequisite: " + prerequisite?.ToString());
            Console.WriteLine("Terminator: " + terminator?.ToString());
            Console.WriteLine("Content Definition Length: ");
            foreach (string str in addedPatternsOutput)
                Console.Write(str.ToString());
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("OUTPUT:");
            Console.WriteLine();

         
    
            if (userPattern.MatchedBoundary.StartIndex < 0 || userPattern.MatchedBoundary.EndIndex < 0)
            {
                Console.WriteLine("NO MATCH");
            }
            else
            {
                Console.WriteLine($"Match Boundaries ({userPattern.MatchedBoundary.StartIndex}:{userPattern.MatchedBoundary.EndIndex})");
                Console.WriteLine($"Extracted Text: ");

                for (int i = userPattern.MatchedBoundary.StartIndex; i <= userPattern.MatchedBoundary.EndIndex; i++)
                {
                    Console.Write($"[{i}:{userInputString[i]}]");
                }
            }


            Console.Write("\n\n\n\n");
            if (false)
            {


                // Example of params
                CharGroup number = new CharGroup('1');
                CharGroup test = new CharGroup('c', 'd', 'c', 'b', 'a', 'b');
                CharGroup testRemoval = new CharGroup('d', 'm', 'a');

                test.AppendDefinition('e', 'f', 'g');

                CharGroup merged = number + test;

                Console.WriteLine(test.ToString());

                Console.WriteLine("Char" + test.ContainsChar('d'));
                Console.WriteLine("bool" + !test.ContainsChar('d'));
                Console.WriteLine(test.ContainsChar('d'));
                Console.WriteLine("Addition" + (number + test).ContainsChar('a'));
                Console.WriteLine("Addition" + merged.ContainsChar('a'));
                Console.WriteLine(merged.ToString());


                CharGroup newl = new(merged.ClearArrayDuplicates(merged.Definition));
                Console.WriteLine(newl.ToString());


                Console.WriteLine("BEFORE: " + test.ToString());
                Console.WriteLine("TO REMOVE: " + testRemoval.ToString());
                test.RemoveDefinition(testRemoval.Definition);
                Console.WriteLine("AFTER: " + test.ToString());


                CharGroup leftCarrot = new CharGroup('<');
                CharGroup start = new CharGroup('\\');
                CharGroup space = new CharGroup(' ');


                // pattern testing
                string input = "remember cool the < html place of <! and such 3<html> so that<html style> ";
                Pattern htmlTagPattern = new(letter);
                htmlTagPattern.AddPrerequisite(leftCarrot);
                htmlTagPattern.AddTerminiator(space);
                // space + operators

                Console.WriteLine(test.ToString());
                int testIndex = 0;

                foreach (char c in input)
                {
                    Console.WriteLine($"Processing Input[{testIndex}]: " + c);
                    htmlTagPattern.ProcessChar(c);
                    testIndex++;
                }

                Console.WriteLine("==================");
                Console.WriteLine("OUTPUT:");
                if (htmlTagPattern.MatchedBoundary.StartIndex < 0)
                {
                    Console.WriteLine("NO MATCH");
                }
                else
                {
                    Console.WriteLine(
                        $"Match Boundaries ({htmlTagPattern.MatchedBoundary.StartIndex}:{htmlTagPattern.MatchedBoundary.EndIndex})");
                    Console.WriteLine($"Extracted Text: ");

                    for (int i = htmlTagPattern.MatchedBoundary.StartIndex;
                         i <= htmlTagPattern.MatchedBoundary.EndIndex;
                         i++)
                    {
                        Console.Write($"[{i}:{input[i]}]");
                    }
                }


                Console.Write("\n\n\n\n");


            }
        }

        /*public CharGroup customValue GetChars(string str)
        {
            
            foreach (char c in str) 
            { Console.WriteLine()}
            return new
        }*/
    }
}
