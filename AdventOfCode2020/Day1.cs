using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day1
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day1.txt");
        private const int TargetNumber = 2020;

        private static List<int> GetSortedExpenses()
        {
            var lines = File.ReadAllLines(FileName);

            var expenses = lines.Select(int.Parse).ToList();
            
            expenses.Sort();

            return expenses;
        }

        public static int PartOne()
        {
            var expenses = GetSortedExpenses();
            
            var left = 0;
            var right = expenses.Count - 1;

            while (left < right)
            {
                var leftNumber = expenses[left];
                var rightNumber = expenses[right];

                if (leftNumber + rightNumber == TargetNumber)
                {
                    return leftNumber * rightNumber;
                }
                
                if (leftNumber + rightNumber < TargetNumber)
                {
                    left += 1;
                }
                else
                {
                    right -= 1;
                }
            }

            return 0;
        }

        public static int PartTwo()
        {
            var expenses = GetSortedExpenses();

            for (var index = 0; index < expenses.Count; index++)
            {
                var expense = expenses[index];
                
                var left = index + 1;
                var right = expenses.Count - 1;

                while (left < right)
                {
                    var leftNumber = expenses[left];
                    var rightNumber = expenses[right];

                    if (expense + leftNumber + rightNumber == TargetNumber)
                    {
                        return expense * leftNumber * rightNumber;
                    }

                    if (expense + leftNumber + rightNumber < TargetNumber)
                    {
                        left += 1;
                    }
                    else
                    {
                        right -= 1;
                    }
                }
            }

            return 0;
        }
    }
}