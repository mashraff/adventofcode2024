using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    internal class DayNProblem : IDayProblem
    {
        string Input;
        public DayNProblem(string input)
        {
            this.Input = input;
        }
        public void SolvePart1()
        {
            var rawLines = Input.Split('\n');
            var safetyCount = 0;
            foreach (var line in rawLines)
            {
                //var list = line.Split(" ").Select(int.Parse).ToList();
            }

        }
        public void SolvePart2()
        {
            var rawLines = Input.Split('\n');
            foreach (var line in rawLines)
            {
                //var list = line.Split(" ").Select(int.Parse).ToList();
            }
        }
    }
}
