using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    internal class Day6Problem : IDayProblem
    {
        string Input;
        public Day6Problem(string input)
        {
            this.Input = input;
        }

        public void SolvePart1()
        {
            var rawLines = Input.Split("\r\n");

            var rowCount = rawLines.Length;
            var colCount = rawLines[0].Length;

            char[,] grid = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                var line = rawLines[i];
                for (int j = 0; j < colCount; j++)
                {
                    grid[j, i] = line[j];
                }
            }

            var startingPointI = 0;
            var startingPointJ = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (grid[i, j] == '^')
                    {
                        startingPointI = i;
                        startingPointJ = j;
                    }
                }
            }

            var directionX = 0; var directionY = -1;
            grid[startingPointI, startingPointJ] = 'X';
            MarkXs(grid, startingPointI, startingPointJ, directionX, directionY);

            var sum = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (grid[i, j] == 'X')
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine("part1: " + sum.ToString());

        }

        private class XY
        {
            public int X;
            public int Y;
        }

        private static bool MarkXs(char[,] grid, int startingPointI, int startingPointJ, int directionX, int directionY)
        {
            var markedBefore = new List<XY>();

            var rowCount = grid.GetLength(0)-1;
            var colCount = grid.GetLength(1)-1;
            var i = startingPointI;
            var j = startingPointJ;
            var seenBlockBeforeCount = 0;
            while ((i < rowCount || j < colCount) && (i>=0 || j>=0))
            {
                i = i+directionX;
                j = j+directionY;

                if (i == rowCount+1 || j == colCount+1)
                    return false;

                if (i == -1 || j==-1)
                    return false;


                if (grid[i, j] == '#')
                {

                    if (markedBefore.Where(x => x.X == i && x.Y == j).FirstOrDefault() != null)
                    {
                        if (markedBefore.Count(x => x.X == i && x.Y == j) > 20)
                            return true;
                        
                    }
                       
                    markedBefore.Add(new XY() { X = i, Y = j });


                    i = i - directionX;
                    j = j - directionY;
                    if (directionX == 0 && directionY == -1)
                    {
                        directionX = 1;
                        directionY = 0;
                        continue;
                    }
                    if (directionX == 1 && directionY == 0)
                    {
                        directionX = 0;
                        directionY = 1;
                        continue;
                    }
                    if (directionX == 0 && directionY == 1)
                    {
                        directionX = -1;
                        directionY = 0;
                        continue;
                    }
                    if (directionX == -1 && directionY == 0)
                    {
                        directionX = 0;
                        directionY = -1;
                        continue;
                    }
                }
                else
                {
                    grid[i, j] = 'X';
                }

            }
            return false;
        }

        public void SolvePart2()
        {
            var rawLines = Input.Split("\r\n");

            var rowCount = rawLines.Length;
            var colCount = rawLines[0].Length;

            char[,] grid = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                var line = rawLines[i];
                for (int j = 0; j < colCount; j++)
                {
                    grid[j, i] = line[j];
                }
            }

            var startingPointI = 0;
            var startingPointJ = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (grid[i, j] == '^')
                    {
                        startingPointI = i;
                        startingPointJ = j;
                    }
                }
            }

            var directionX = 0; var directionY = -1;
            var sum = 0;
            var originalGrid = (char[,])grid.Clone();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    grid = (char[,])originalGrid.Clone();
                    if (i == startingPointI && j == startingPointJ)
                        continue;
                    grid[i, j] = '#';
                    if (MarkXs(grid, startingPointI, startingPointJ, directionX, directionY))
                        sum++;
                }
            }

            Console.WriteLine("part2: " + sum.ToString());
        }
    }
}
