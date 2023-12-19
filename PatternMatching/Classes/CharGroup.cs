using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace PatternMatching.Classes
{
    internal class CharGroup : ICloneable
    {
        public char[] Definition { get; private set; }

        private bool _inverted = false;

        public CharGroup(params char[] definition)
        {
            Definition = definition;
        }

        public void AppendDefinition(params char[] definition)
        {
            char[] referenceTemp = Definition;
            char[] parameterTemp = definition;

            Definition = new char[referenceTemp.Length + parameterTemp.Length];
            referenceTemp.CopyTo(Definition, 0);
            parameterTemp.CopyTo(Definition, referenceTemp.Length);
        }

        public void RemoveDefinition(params char[] definition)
        {
            
        }

        /*private char[] ClearExistingDefinitions(params char[] definition)
        {
            char[] temp = definition;
            int tempIndex = 0;
            for (int i = 0; i < definition.Length; i++)
            {
                if (!ContainsChar(definition[i]))
                {
                    temp[tempIndex] = definition[i];
                    tempIndex++;
                }
            }

            temp.C
            return temp.CopyTo()
        }*/

        public char[] ClearArrayDuplicates(params char[] charArray)
        {
            int arrayLength = charArray.Length;
            int appendIndex = 0;
            int matchCounter = 0;
            char[] replacementArray = new char[arrayLength-1];
            bool foundDuplicate = false;

            for (int compareFromIndex = 0; compareFromIndex < arrayLength; compareFromIndex++)
            {
                for (int compareToIndex = compareFromIndex+1; compareToIndex < arrayLength; compareToIndex++)
                {
                    if (charArray[compareFromIndex] == charArray[compareToIndex])
                    {
                        foundDuplicate = true;
                        matchCounter++;
                        compareToIndex = arrayLength - 1; // break out of for loop
                    }

                }
                if (!foundDuplicate)
                {
                    replacementArray[appendIndex] = charArray[compareFromIndex];
                    appendIndex++;
                }
                foundDuplicate = false;
            }

            Array.Resize(ref replacementArray, arrayLength-matchCounter);
            return replacementArray;
        }

        
        public bool ContainsChar(char inputChar)
        {
            return FoundDefinition(inputChar, found => _inverted == false ? found : !found);
        }

        private bool FoundDefinition(char inputChar, Func<bool, bool> handleInversion)
        {
            foreach (char refChar in Definition)
            {
                if (inputChar == refChar)
                {
                    return handleInversion(true);
                }
            }

            return handleInversion(false);
        }

        private void InvertDefinitions()
        {
            _inverted = !_inverted;
        }

        public void PrintDebug()
        {
            foreach (char c in Definition)
            {
                Console.WriteLine(c);
            }
        }

        public override string ToString()
        {
            string temp = string.Empty;
            foreach (char c in Definition)
            {
                temp += '[';
                temp += c;
                temp += ']';
                temp += ' ';
            }
            
            return temp;
        }

        public static CharGroup operator !(CharGroup group)
        {
            group = (CharGroup)group.MemberwiseClone();
            group.InvertDefinitions();
            return group;
        }

        public static CharGroup operator +(CharGroup groupA, CharGroup groupB)
        {
            groupA = (CharGroup)groupA.MemberwiseClone();
            groupA.AppendDefinition(groupB.Definition);
            groupA._inverted = (groupB._inverted || groupA._inverted);

            return groupA;
        }

        public static CharGroup operator -(CharGroup groupA, CharGroup groupB)
        {
            groupA = (CharGroup)groupA.MemberwiseClone();
            groupA.AppendDefinition(groupB.Definition);
            groupA._inverted = (groupB._inverted || groupA._inverted);

            return groupA;
        }
        public object Clone()
        {
            CharGroup group = (CharGroup)MemberwiseClone();
            group.Definition = (char[])Definition.Clone();
            group._inverted = (bool)_inverted;

            return group;
        }
    }
}
