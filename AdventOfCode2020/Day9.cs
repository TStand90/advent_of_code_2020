using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day9
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day9.txt");

        private static bool Contains(ICollection<long> numbers, long currentNumber)
        {
            foreach (var number in numbers)
            {
                var desiredNumber = currentNumber - number;

                if (currentNumber == desiredNumber)
                {
                    continue;
                }

                if (numbers.Contains(desiredNumber))
                {
                    return true;
                }
            }

            return false;
        }

        public static long PartOne()
        {
            var lines = File.ReadAllLines(FileName);

            var numbers = lines.Select(long.Parse).ToList();

            const int bound = 25;

            for (var i = bound; i < numbers.Count; i++)
            {
                var lowerBound = i - bound;

                var currentNumber = numbers[i];

                var rangeNumbers = numbers.GetRange(lowerBound, bound);

                if (!Contains(rangeNumbers, currentNumber))
                {
                    return currentNumber;
                }
            }

            return 0;
        }

        public static long PartTwo()
        {
            var lines = File.ReadAllLines(FileName);

            var numbers = lines.Select(long.Parse).ToList();

            var invalidNumber = PartOne();

            var left = 0;
            var right = 0;
            var sum = numbers[left];

            while (sum != invalidNumber)
            {
                if (sum < invalidNumber)
                {
                    right++;

                    sum += numbers[right];
                } else if (sum > invalidNumber)
                {
                    sum -= numbers[left];

                    left++;
                }
            }

            var subArray = numbers.Skip(left).Take(right - left);

            var enumerable = subArray as long[] ?? subArray.ToArray();
            var min = enumerable.Min();
            var max = enumerable.Max();

            return min + max;
        }
    }
}