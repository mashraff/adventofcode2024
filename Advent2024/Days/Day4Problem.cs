using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    internal class Day4Problem : IDayProblem
    {
        string Input;
        public Day4Problem(string input)
        {
            this.Input = input;
        }
        public void SolvePart1()
        {
            var rawLines = Input.Split("\r\n");
            var count = 0;

            var rowCount = rawLines.Length;
            var colCount = rawLines[0].Length;

            char[,] grid = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                var line = rawLines[i];
                for (int j = 0; j < colCount; j++)
                {
                    grid[i, j] = line[j];
                }
            }

            var goRight = new int[] { 0, 1, 2, 3 };
            var goLeft = new int[] { 0, -1, -2, -3 };
            var goUp = new int[] { 0, -1, -2, -3 }; // col
            var goDown = new int[] { 0, 1, 2, 3 }; // col

            var goDiag1X = new int[] { 0, 1, 2, 3 }; // this one: \
            var goDiag1Y = new int[] { 0, 1, 2, 3 }; // this one: \

            var goDiag1X2 = new int[] { 0, -1, -2, -3 }; // this one: \
            var goDiag1Y2 = new int[] { 0, -1, -2, -3 }; // this one: \

            var goDiag2X = new int[] { 0, 1, 2, 3 }; // this one: /
            var goDiag2Y = new int[] { 3, 2, 1, 0 }; // this one: /

            var goDiag2X2 = new int[] { 0, -1, -2, -3 }; // this one: /
            var goDiag2Y2 = new int[] { 0, 1, 2, 3 }; // this one: /

            var blank = new int[] { 0, 0, 0, 0 };

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (SearchXMAS(grid, goRight, blank, i, j))
                        count++;
                    if (SearchXMAS(grid, goLeft, blank, i, j))
                        count++;
                    if (SearchXMAS(grid, blank, goUp, i, j))
                        count++;
                    if (SearchXMAS(grid, blank, goDown, i, j))
                        count++;
                    if (SearchXMAS(grid, goDiag1X, goDiag1Y, i, j))
                        count++;
                    if (SearchXMAS(grid, goDiag2X, goDiag2Y, i, j))
                        count++;
                    if (SearchXMAS(grid, goDiag1X2, goDiag1Y2, i, j))
                        count++;
                    if (SearchXMAS(grid, goDiag2X2, goDiag2Y2, i, j))
                        count++;
                }
            }

            Console.WriteLine("part1: " + count.ToString());
        }

        static bool SearchXMAS(char[,] grid, int[] rowInstruction, int[] colInstruction, int row, int col)
        {
            var word = "XMAS";
            var maxRow = grid.GetLength(0) - 1;
            var maxCol = grid.GetLength(1) - 1;

            if (rowInstruction.Max() + row > maxRow
                || rowInstruction.Min() + row < 0
                || colInstruction.Max() + col > maxCol
                || colInstruction.Min() + col < 0
                )
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                var cursor = grid[rowInstruction[i] + row, colInstruction[i] + col];
                if (cursor != word[i])
                    return false;
            }
            return true;
        }


        static bool IsMASXDiag(char[,] grid, int row, int col)
        {
            var maxRow = grid.GetLength(0) - 1;
            var maxCol = grid.GetLength(1) - 1;

            if (row == 0 || col == 0 || row == maxRow || col == maxCol)
                return false;

            //diagonal1: i.e.: \
            var d1_upLeft = grid[row - 1, col - 1];
            var d1_downRight = grid[row + 1, col + 1];

            //diagonal2 i.e.: /
            var d2_upRight = grid[row - 1, col + 1];
            var d2_downLeft = grid[row + 1, col - 1];

            if (d1_upLeft != d1_downRight
                && (d1_upLeft == 'M' || d1_downRight == 'M')
                && (d1_upLeft == 'S' || d1_downRight == 'S')
                ) // diag1 matched!
            {
                if (d2_upRight != d2_downLeft
                && (d2_upRight == 'M' || d2_downLeft == 'M')
                && (d2_upRight == 'S' || d2_downLeft == 'S')
                ) // diag2 matched!
                {
                    return true;
                }

            }
            return false;


        }


        public void SolvePart2()
        {
            var rawLines = Input.Split("\r\n");
            var count = 0;

            var rowCount = rawLines.Length;
            var colCount = rawLines[0].Length;

            char[,] grid = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                var line = rawLines[i];
                for (int j = 0; j < colCount; j++)
                {
                    grid[i, j] = line[j];
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (grid[i, j] == 'A')
                    {
                        if (IsMASXDiag(grid, i, j))
                            count++;
                    }
                }
            }

            Console.WriteLine("part2: " + count.ToString());
        }
    }
}
