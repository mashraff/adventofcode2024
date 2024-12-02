using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{
    internal class Day2Problem : IDayProblem
    {
        string Input;
        public Day2Problem(string input)
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
                if (CheckSafety(line))
                {
                    safetyCount++;
                }
            }
            Console.WriteLine("part1: " + safetyCount.ToString());
        }
        bool CheckSafety(string row)
        {

            List<int> list = row.Split(" ").Select(int.Parse).ToList();


            var safe = true;
            bool? isIncreasing = null;
            for (int i = 1; i < list.Count; i++)
            {
                //same
                if (list[i] == list[i - 1])
                {
                    safe = false;
                    //Console.WriteLine("Unsafe - same");
                    break;
                }

                //inc and dec
                if (list[i] - list[i - 1] > 0)
                {
                    // this segment is increasing
                    if (isIncreasing == null)
                    {
                        isIncreasing = true;
                    }
                    else
                    {
                        if (isIncreasing == false)
                        {
                            //Console.WriteLine("Unsafe - went from decreasing to increasing");
                            safe = false;
                            break;
                        }

                    }
                }
                else
                {
                    //this segment is decreasing
                    if (isIncreasing == null)
                    {
                        isIncreasing = false;
                    }
                    else
                    {
                        if (isIncreasing == true)
                        {
                            //Console.WriteLine("Unsafe - went from increasing to decreasing");
                            safe = false;
                            break;
                        }
                    }
                }

                if (Math.Abs(list[i] - list[i - 1]) > 3)
                {
                    //Console.WriteLine("Unsafe - more then 2 inc/dec");
                    safe = false;
                    break;
                }
            }
            return safe;
        }

        public void SolvePart2()
        {
            var rawLines = Input.Split('\n');
            var safetyCount = 0;
            foreach (var line in rawLines)
            {
                var list = line.Split(" ").Select(int.Parse).ToList();
                if (CheckSafety(line))
                {
                    safetyCount++;
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var copyList = new List<int>(list);
                        copyList.RemoveAt(i);
                        var newLine = string.Join(" ", copyList);
                        var result = CheckSafety(newLine);
                        if (result)
                        {
                            safetyCount++;
                            break;
                        }
                        else
                        {
                            //Console.WriteLine("* Still unsafe, " + line + " went to " + newLine);
                        }
                    }
                }
            }
            Console.WriteLine("part2: " + safetyCount.ToString());
        }
    }
}
