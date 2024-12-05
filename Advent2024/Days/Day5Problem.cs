using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Days
{

    internal class Rule
    {
        public int BeforePage { get; set; }
        public int AfterPage  { get; set; }
    }

    internal class Day5Problem : IDayProblem
    {
        string Input;
        public Day5Problem(string input)
        {
            this.Input = input;
        }
        public void SolvePart1()
        {
            var sections = Input.Split("\r\n\r\n");
            var rulesRaw = sections[0].Split("\r\n");
            var updates = sections[1].Split("\r\n");

            var rules = new List<Rule>();
            foreach (var ruleRaw in rulesRaw)
            {
                var rule = new Rule()
                {
                    BeforePage = int.Parse(ruleRaw.Split('|')[0]),
                    AfterPage = int.Parse(ruleRaw.Split('|')[1])
                };
                rules.Add(rule);
            }
            var sum = 0;
            foreach (var update in updates)
            {
                sum += CheckValidity(update, rules);
            }
            Console.WriteLine("part1: " + sum.ToString());
        }

        internal int CheckValidity(string updateRaw, List<Rule> rules)
        {
            var updates = Array.ConvertAll(updateRaw.Split(','), int.Parse).ToList();
            var seenPages = new HashSet<int>();
            foreach (var currentPage in updates)
            {
                seenPages.Add(currentPage);
                var applicableRules = rules.Where(x => x.AfterPage == currentPage).ToList();
                foreach (var rule in applicableRules)
                {
                    if (updates.Contains(rule.BeforePage))
                    {
                        var found = seenPages.Contains(rule.BeforePage);
                        if (!found)
                            return 0;
                    }
                }
            }

            var middleIndex = updates.Count / 2;
            return updates[middleIndex];
        }

        internal string MakeItValid(string updateRaw, List<Rule> rules)
        {
            var updates = Array.ConvertAll(updateRaw.Split(','), int.Parse).ToList();
            var seenPages = new HashSet<int>();
            for (int i=0; i<updates.Count; i++)
            {
                var currentPage = updates[i];
                seenPages.Add(currentPage);
                var applicableRules = rules.Where(x => x.AfterPage == currentPage).ToList();
                foreach (var rule in applicableRules)
                {
                    if (updates.Contains(rule.BeforePage))
                    {
                        var found = seenPages.Contains(rule.BeforePage);
                        if (!found)
                        {
                            var indexOfBeforePage = updates.FindIndex(x => x == rule.BeforePage);
                            var indexOfCurrentPage = i;
                            //swap
                            updates[indexOfBeforePage] = currentPage;
                            updates[indexOfCurrentPage] = rule.BeforePage;
                            return string.Join(',', updates);
                        }
                            
                    }
                }
            }
            return string.Empty;
        }


        public void SolvePart2()
        {
            var sections = Input.Split("\r\n\r\n");
            var rulesRaw = sections[0].Split("\r\n");
            var updates = sections[1].Split("\r\n");

            var rules = new List<Rule>();
            foreach (var ruleRaw in rulesRaw)
            {
                var rule = new Rule()
                {
                    BeforePage = int.Parse(ruleRaw.Split('|')[0]),
                    AfterPage = int.Parse(ruleRaw.Split('|')[1])
                };
                rules.Add(rule);
            }
            var sum = 0;
            foreach (var update in updates)
            {
                var isInValid = CheckValidity(update, rules) == 0;
                if (isInValid)
                {
                    var currentUpdate = update;
                    while (MakeItValid(currentUpdate, rules) != string.Empty)
                    {
                        currentUpdate = MakeItValid(currentUpdate, rules);
                    }
                    sum += CheckValidity(currentUpdate, rules);
                }
            }
            Console.WriteLine("part2: " + sum.ToString());
        }
    }
}
