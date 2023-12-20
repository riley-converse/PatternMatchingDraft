using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using PatternMatching.Interfaces;

namespace PatternMatching.Classes
{
    internal class CharGroup : ICharCollection, ICloneable
    {
        public char[] Definition { get; private set; }

        private bool _inverted = false;

        public CharGroup(params char[] definition)
        {
            Definition = ClearArrayDuplicates(definition);
        }

        public void AppendDefinition(params char[] definition)
        {
            char[] referenceTemp = Definition;
            char[] parameterTemp = definition;

            Definition = new char[referenceTemp.Length + parameterTemp.Length];
            referenceTemp.CopyTo(Definition, 0);
            parameterTemp.CopyTo(Definition, referenceTemp.Length);

            Definition = ClearArrayDuplicates(Definition);
        }

        public void RemoveDefinition(params char[] toRemove)
        {
            
            char[] mainArray = Definition;
            char[] secondaryArray;
            secondaryArray = ClearArrayDuplicates(toRemove);
            
            bool foundMatch = false;
            char[] temp = new char[mainArray.Length];
            int tempIndex = 0;
            int matchCounter = 0;
            for (int compareFromIndex=0; compareFromIndex< mainArray.Length; compareFromIndex++)
            {
                for (int compareToIndex = 0; compareToIndex < secondaryArray.Length; compareToIndex++)
                {
                    if (mainArray[compareFromIndex] == secondaryArray[compareToIndex])
                    {
                        foundMatch = true;
                        compareToIndex = secondaryArray.Length;
                        matchCounter++;
                    }
                }
                if (!foundMatch)
                {
                    temp[tempIndex] = mainArray[compareFromIndex];
                    tempIndex++;
                }
                foundMatch = false;
            }

            Array.Resize(ref temp, mainArray.Length - matchCounter);
            Definition = temp;
        }

        public char[] ClearArrayDuplicates(params char[] charArray)
        {
            int arrayLength = charArray.Length;
            int appendIndex = 0;
            int matchCounter = 0;
            char[] replacementArray = new char[arrayLength];
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
