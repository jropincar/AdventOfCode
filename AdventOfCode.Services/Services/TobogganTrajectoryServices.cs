using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Models.TobogganTrajectory;
using AdventOfCode.Services.Interfaces;

namespace AdventOfCode.Services.Services
{
    public class TobogganTrajectoryServices : IServices
    {
        private readonly TobogganTrajectoryConfig _tobogganTrajectoryConfig;

        public TobogganTrajectoryServices(TobogganTrajectoryConfig tobogganTrajectoryConfig)
        {
            _tobogganTrajectoryConfig = tobogganTrajectoryConfig;
        }
        public int Run()
        {
            var lines = File.ReadAllLines(_tobogganTrajectoryConfig.DataSetUrl).ToList();
            return RunTobogganTrajectory(lines);
        }

        public int RunTobogganTrajectory(List<string> lines)
        {
            int rightLocation = 0, trees = 0;
            for (var x = 0; x < lines.Count; x += _tobogganTrajectoryConfig.Down)
            {
                var currentLine = lines[x].ToCharArray();
                var spotToCheck = rightLocation % currentLine.Length;
                var path = currentLine.ElementAt(spotToCheck);
                if (path == '#')
                {
                    trees += 1;
                }
                rightLocation += _tobogganTrajectoryConfig.Right;
            }
            return trees;
        }
    }
}
