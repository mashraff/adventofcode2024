using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    internal class Day3Problem : IDayProblem
    {
        string Input;
        public Day3Problem(string input)
        {
            this.Input = input;
        }
        public void SolvePart1()
        {
            var total = Multiply(this.Input);
            Console.WriteLine("part1: " + total.ToString());
        }

        internal int Multiply(string input)
        {
            var total = 0;
            var rawLines = input.Split("mul");
            foreach (var line in rawLines)
            {
                var indexOfpar = line.IndexOf(')');
                if (indexOfpar == -1)
                    continue;
                if (line[0] != '(')
                    continue;
                var newLine = line.Substring(1, indexOfpar - 1);
                var twoNumbers = newLine.Split(',');
                if (twoNumbers.Length != 2)
                    continue;
                int number1 = 0;
                int number2 = 0;
                if (int.TryParse(twoNumbers[0], out number1) == false)
                    continue;
                if (int.TryParse(twoNumbers[1], out number2) == false)
                    continue;
                total += (number1 * number2);
            }
            return total;
        }

        public void SolvePart2()
        {
            var rawLines = Input.Split("don\'t()");
            var total = Multiply(rawLines[0]);
            for (int i = 1; i < rawLines.Length; i++)
            {
                var line = rawLines[i];
                if (!line.Contains("do()"))
                    continue;
                var indexOfFirstDo = line.IndexOf("do()");
                var newLine = line.Substring(indexOfFirstDo);
                total += Multiply(newLine);
            }
            Console.WriteLine("part2:" + total.ToString());
        }
    }
}
