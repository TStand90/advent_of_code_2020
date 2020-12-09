using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public static class Day6
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day6.txt");
        
        public static int PartOne()
        {
            var totalCount = 0;
            
            var lines = File.ReadAllLines(FileName);

            var answers = new HashSet<char>();

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    totalCount += answers.Count;
                    
                    answers = new HashSet<char>();
                }
                else
                {
                    foreach (var character in line)
                    {
                        answers.Add(character);
                    }
                }
            }
            
            totalCount += answers.Count;

            return totalCount;
        }
        
        public static int PartTwo()
        {
            var totalCount = 0;
            
            var lines = File.ReadAllLines(FileName);

            var answers = new HashSet<char>();
            var noCommonAnswers = false;

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    totalCount += answers.Count;
                    
                    answers = new HashSet<char>();
                    noCommonAnswers = false;
                }
                else
                {
                    if (noCommonAnswers) continue;
                    
                    var personsAnswers = new HashSet<char>();

                    foreach (var character in line)
                    {
                        personsAnswers.Add(character);
                    }

                    if (answers.Count == 0)
                    {
                        answers = personsAnswers;
                    }
                    else
                    {
                        answers.IntersectWith(personsAnswers);

                        if (answers.Count == 0)
                        {
                            noCommonAnswers = true;
                        }
                    }
                }
            }

            totalCount += answers.Count;

            return totalCount;
        }
    }
}