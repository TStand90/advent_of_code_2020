using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day5
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day5.txt");
        
        public static int PartOne()
        {
            var highestSeatId = -1;

            var lines = File.ReadAllLines(FileName);
            
            foreach (var line in lines)
            {
                var currentRow = 0;
                var currentSeat = 0;
                
                var currentMinimum = 0.0;
                var currentMaximum = 127.0;

                for (var i = 0; i < 7; i++)
                {
                    var character = line[i];
                    
                    if (character == 'F')
                    {
                        if (i == 6)
                        {
                            currentRow = (int)currentMinimum;
                        }
                        else
                        {
                            currentMaximum = Math.Floor((currentMinimum + currentMaximum) / 2);
                        }
                    }
                    else
                    {
                        if (i == 6)
                        {
                            currentRow = (int)currentMaximum;
                        }
                        else
                        {
                            currentMinimum = Math.Ceiling((currentMinimum + currentMaximum) / 2);
                        }
                    }
                }

                var currentSeatMinimum = 0.0;
                var currentSeatMaximum = 7.0;
                
                for (var i = 7; i < 10; i++)
                {
                    var character = line[i];
                    
                    if (character == 'L')
                    {
                        if (i == 9)
                        {
                            currentSeat = (int)currentSeatMinimum;
                        }
                        else
                        {
                            currentSeatMaximum = Math.Floor((currentSeatMinimum + currentSeatMaximum) / 2);
                        }
                    }
                    else
                    {
                        if (i == 9)
                        {
                            currentSeat = (int)currentSeatMaximum;
                        }
                        else
                        {
                            currentSeatMinimum = Math.Ceiling((currentSeatMinimum + currentSeatMaximum) / 2);
                        }
                    }
                }

                var seatId = (currentRow * 8) + currentSeat;

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }

            return highestSeatId;
        }
        
        public static int PartTwo()
        {
            var highestSeatId = -1;

            var lines = File.ReadAllLines(FileName);

            var foundIds = new List<int>(); 
            
            foreach (var line in lines)
            {
                var currentRow = 0;
                var currentSeat = 0;
                
                var currentMinimum = 0.0;
                var currentMaximum = 127.0;

                for (var i = 0; i < 7; i++)
                {
                    var character = line[i];
                    
                    if (character == 'F')
                    {
                        if (i == 6)
                        {
                            currentRow = (int)currentMinimum;
                        }
                        else
                        {
                            currentMaximum = Math.Floor((currentMinimum + currentMaximum) / 2);
                        }
                    }
                    else
                    {
                        if (i == 6)
                        {
                            currentRow = (int)currentMaximum;
                        }
                        else
                        {
                            currentMinimum = Math.Ceiling((currentMinimum + currentMaximum) / 2);
                        }
                    }
                }

                var currentSeatMinimum = 0.0;
                var currentSeatMaximum = 7.0;
                
                for (var i = 7; i < 10; i++)
                {
                    var character = line[i];
                    
                    if (character == 'L')
                    {
                        if (i == 9)
                        {
                            currentSeat = (int)currentSeatMinimum;
                        }
                        else
                        {
                            currentSeatMaximum = Math.Floor((currentSeatMinimum + currentSeatMaximum) / 2);
                        }
                    }
                    else
                    {
                        if (i == 9)
                        {
                            currentSeat = (int)currentSeatMaximum;
                        }
                        else
                        {
                            currentSeatMinimum = Math.Ceiling((currentSeatMinimum + currentSeatMaximum) / 2);
                        }
                    }
                }

                var seatId = (currentRow * 8) + currentSeat;

                if (!foundIds.Contains(seatId))
                {
                    foundIds.Add(seatId);
                }
            }
            
            foundIds.Sort();

            for (var i = 1; i < foundIds.Count - 1; i++)
            {
                var previousId = foundIds[i-1];
                var currentId = foundIds[i];
                
                if (currentId - previousId != 1)
                {
                    return previousId + 1;
                }
            }

            return highestSeatId;
        }
    }
}