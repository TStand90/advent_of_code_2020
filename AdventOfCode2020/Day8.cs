using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day8
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day8.txt");

        public static int PartOne()
        {
            var lines = File.ReadAllLines(FileName);
            var instructions = new List<Tuple<string, int>>();

            foreach (var line in lines)
            {
                var splitLine = line.Split(' ');
                
                var operation = splitLine[0];
                var argumentAsString = splitLine[1];

                var argument = int.Parse(argumentAsString);
                
                instructions.Add(new Tuple<string, int>(operation, argument));
            }

            var (_, accumulator) = IterateInstructions(instructions);

            return accumulator;
        }

        private static (bool programTerminated, int accumulatorValue) IterateInstructions(List<Tuple<string, int>> instructions)
        {
            var accumulator = 0;
            var currentLine = 0;
            var visitedLines = new List<int>();
            
            while (currentLine < instructions.Count)
            {
                if (visitedLines.Contains(currentLine))
                {
                    return (false, accumulator);
                }

                visitedLines.Add(currentLine);

                var (operation, argument) = instructions[currentLine];

                if (operation == "acc")
                {
                    accumulator += argument;
                } else if (operation == "jmp")
                {
                    currentLine += argument;
                    
                    continue;
                }

                currentLine += 1;
            }

            return (true, accumulator);
        }

        public static int PartTwo()
        {
            var lines = File.ReadAllLines(FileName);
            var instructions = new List<Tuple<string, int>>();

            foreach (var line in lines)
            {
                var splitLine = line.Split(' ');
                
                var operation = splitLine[0];
                var argumentAsString = splitLine[1];

                var argument = int.Parse(argumentAsString);
                
                instructions.Add(new Tuple<string, int>(operation, argument));
            }

            for (var i = 0; i < instructions.Count; i++)
            {
                var (operation, argument) = instructions[i];

                var copy = instructions.ToList();

                var changedOperation = operation switch
                {
                    "nop" => "jmp",
                    "jmp" => "nop",
                    _ => null
                };

                if (changedOperation == null) continue;
                
                var newInstruction = new Tuple<string, int>(changedOperation, argument);
                copy[i] = newInstruction;
                
                var (programTerminated, accumulator) = IterateInstructions(copy);

                if (programTerminated)
                {
                    return accumulator;
                }
            }

            return 0;
        }
    }
}