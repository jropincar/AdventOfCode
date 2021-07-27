using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Models.ReportRepair;
using AdventOfCode.Services.Interfaces;

namespace AdventOfCode.Services.Services
{
    public class ReportRepairServices : IServices
    {
        private readonly ReportRepairConfig _reportRepairConfig;
        public ReportRepairServices(ReportRepairConfig reportRepairConfig)
        {
            _reportRepairConfig = reportRepairConfig;
        }
        public int Run()
        {
            var lines = File.ReadAllLines(_reportRepairConfig.DataSetUrl).ToList();
            var numbers = lines.Select(int.Parse).OrderBy(x => x).ToList();
            return _reportRepairConfig.AmountOfNumbers == 2 ? TwoNumberReportRepair(numbers) : ThreeNumberReportRepair(numbers);
        }

        private int TwoNumberReportRepair(List<int> numbers)
        {
           
            var leftStart = 0;
            var rightStart = numbers.Count() - 1;
            while (leftStart < rightStart)
            {
                var sum = numbers.ElementAt(rightStart) + numbers.ElementAt(leftStart);
                if (sum == _reportRepairConfig.Year)
                {
                    var answer = numbers.ElementAt(rightStart) * numbers.ElementAt(leftStart);
                    return answer;
                }
                else if (sum < _reportRepairConfig.Year) leftStart++;
                else rightStart--;
            }

            return -1;
        }

        private int ThreeNumberReportRepair(List<int> numbers)
        {
            for (var i = 0; i < numbers.Count() - 2; i++)
            {
                var left = i + 1;
                var right = numbers.Count() - 1;
                while (left < right)
                {
                    if (numbers.ElementAt(i) + numbers.ElementAt(left) + numbers.ElementAt(right) ==
                        _reportRepairConfig.Year)
                    {
                        var answer = numbers.ElementAt(right) * numbers.ElementAt(left) * numbers.ElementAt(i);
                        return answer;
                    }
                    if (numbers.ElementAt(i) + numbers.ElementAt(left) + numbers.ElementAt(right) <
                        _reportRepairConfig.Year)
                        left++;
                    else
                        right--;
                }
            }
            return -1;

        }
    }
}
