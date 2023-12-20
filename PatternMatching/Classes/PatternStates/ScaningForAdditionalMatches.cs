﻿using PatternMatching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Classes.PatternStates
{
    internal class ScaningForAdditionalMatches : IState
    {
        
        public void GetState(Pattern pattern, char ch)
        {
            Console.WriteLine("Scanning:" +ch);
            if (ContainsMatch(pattern, ch)) 
            {
                Console.WriteLine("MATCHES char: " + ch);
                if (ReachedEndOfCharGroupArray(pattern, ch))
                {
                    Console.WriteLine("reached end");
                    if (pattern.Terminator is null)
                    {
                        pattern._currentState = new Completed();
                        pattern._currentState.GetState(pattern, ch);
                    }
                    else
                    {
                        pattern._currentState = new CheckingForTerminator();
                    }
                }
            }
            else
            {
                pattern._currentState = new Listening();
                pattern.MatchedBoundary.StartIndex = -1;
                pattern._currentState.GetState(pattern, ch);
                pattern.RanONcePre = true;
            }
        }

        public bool ContainsMatch(Pattern pattern, char ch)
        {
            Console.WriteLine("Pattern CharGroup Index: "+pattern.CharGroupIndex);
            Console.WriteLine("Against: " + pattern.Definitions[pattern.CharGroupIndex]);
            if (pattern.Definitions[pattern.CharGroupIndex].ContainsChar(ch))
            {
                pattern.CharGroupIndex++;
                Console.WriteLine("char matches: " + ch);
                return true;
            }
            pattern.CharGroupIndex = 0;
            return false;
        }

        public bool ReachedEndOfCharGroupArray(Pattern pattern, char ch)
        {
            Console.WriteLine(pattern.Definitions.Length + " and " + pattern.CharGroupIndex);
            if (pattern.Definitions.Length <= pattern.CharGroupIndex)
                return true;
            return false;
        }
    }
}
