using System;
using System.IO;
using System.Linq;
using static System.Int32;

namespace AdventOfCode2020
{
    public static class Day2
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day2.txt");
        
        public static int PartOne()
        {
            var validPasswordsCount = 0;
            
            var lines = File.ReadAllLines(FileName);

            const string pattern = @"(\d+)-(\d+) (.): (.+)";

            foreach (var line in lines)
            {
                foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(line, pattern))
                {
                    var minimumValue = Parse(match.Groups[1].Value);
                    var maximumValue = Parse(match.Groups[2].Value);
                    var letter = Convert.ToChar(match.Groups[3].Value);
                    var password = match.Groups[4].Value;

                    var letterCount = password.Count(passwordLetter => passwordLetter == letter);

                    if (letterCount >= minimumValue && letterCount <= maximumValue)
                    {
                        validPasswordsCount++;
                    }
                }
            }

            return validPasswordsCount;
        }
        
        public static int PartTwo()
        {
            var validPasswordsCount = 0;
            
            var lines = File.ReadAllLines(FileName);

            const string pattern = @"(\d+)-(\d+) (.): (.+)";

            foreach (var line in lines)
            {
                foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(line, pattern))
                {
                    var firstIndex = Parse(match.Groups[1].Value) - 1;
                    var secondIndex = Parse(match.Groups[2].Value) - 1;
                    var letter = Convert.ToChar(match.Groups[3].Value);
                    var password = match.Groups[4].Value;

                    if (password[firstIndex] == letter && password[secondIndex] != letter)
                    {
                        validPasswordsCount++;
                    } else if (password[firstIndex] != letter && password[secondIndex] == letter)
                    {
                        validPasswordsCount++;
                    }
                }
            }

            return validPasswordsCount;
        }
    }
}