using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    internal class Day1Problem : IDayProblem
    {
        string Input;
        public Day1Problem(string input) 
        {
            this.Input = input;
        }


        public void SolvePart1()
        {
            var rawLines = Input.Split('\n');
            var leftList = new List<int>();
            var rightList = new List<int>();
            foreach (var line in rawLines)
            {
                var split = line.Split("   ");
                leftList.Add(int.Parse(split[0]));
                rightList.Add(int.Parse(split[1]));
            }

            leftList.Sort();
            rightList.Sort();
            var totalDistance = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                var distance = Math.Abs(leftList[i] - rightList[i]);
                totalDistance += distance;
            }

            Console.WriteLine("part1: " + totalDistance);
        }

        public void SolvePart2()
        {
            var rawLines = Input.Split('\n');
            var leftList = new List<int>();
            var rightList = new List<int>();
            foreach (var line in rawLines)
            {
                var split = line.Split("   ");
                leftList.Add(int.Parse(split[0]));
                rightList.Add(int.Parse(split[1]));
            }
            long totalSum = 0;
            foreach (int leftItem in leftList)
            {
                var countInList2 = rightList.Count(x => x == leftItem);
                var score = leftItem * countInList2;
                totalSum += score;
            }

            Console.WriteLine("part2: " + totalSum);
        }
    }
}
