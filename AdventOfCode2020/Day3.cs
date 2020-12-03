using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public static class Day3
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day3.txt");
        
        private static List<List<bool>> GetTrees()
        {
            var lines = File.ReadAllLines(FileName);

            var trees = new List<List<bool>>();

            foreach (var line in lines)
            {
                var treesRow = new List<bool>();
                
                for (var x = 0; x < lines[0].Length; x++)
                {
                    treesRow.Add(line[x] == '#');
                }
                
                trees.Add(treesRow);
            }

            return trees;
        }
        
        private static void Step(ref int positionX, ref int positionY, int dx, int dy, int width)
        {
            positionX += dx;
            positionY += dy;
            
            if (positionX >= width)
            {
                positionX -= width;
            }
        }

        private static int CalculateTreesOnSlope(IReadOnlyList<IReadOnlyList<bool>> trees, int dx, int dy)
        {
            var treesCount = 0;

            var width = trees[0].Count;
            var height = trees.Count;
            
            var currentPositionX = 0;
            var currentPositionY = 0;
            
            while (currentPositionY < height - 1)
            {
                Step(ref currentPositionX, ref currentPositionY, dx, dy, width);
                
                if (trees[currentPositionY][currentPositionX])
                {
                    treesCount++;
                }
            }

            return treesCount;
        }
        
        public static int PartOne()
        {
            return CalculateTreesOnSlope(GetTrees(), 3, 1);
        }

        public static int PartTwo()
        {
            var trees = GetTrees();

            var treesProduct = CalculateTreesOnSlope(trees, 1, 1);
            treesProduct *= CalculateTreesOnSlope(trees, 3, 1);
            treesProduct *= CalculateTreesOnSlope(trees, 5, 1);
            treesProduct *= CalculateTreesOnSlope(trees, 7, 1);
            treesProduct *= CalculateTreesOnSlope(trees, 1, 2);

            return treesProduct;
        }
    }
}