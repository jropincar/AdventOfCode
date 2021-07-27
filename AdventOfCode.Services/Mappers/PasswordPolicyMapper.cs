using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Models.PasswordPolicy;

namespace AdventOfCode.Services.Mappers
{
    public class PasswordPolicyMapper
    {
        public List<Password> Map(List<string> passwordLines)
        {
            var passwords = new List<Password>();
            foreach (var line in passwordLines)
            {
                var hyphenLocation = line.IndexOf('-', StringComparison.Ordinal);
                var colonLocation = line.IndexOf(':', StringComparison.Ordinal);
                passwords.Add(new Password
                {
                    Policy = new Policy
                    {
                        LowConstraint = Convert.ToInt32(line.Substring(0, hyphenLocation)),
                        HighConstraint = Convert.ToInt32(line[(hyphenLocation + 1)..(colonLocation - 2)]),
                        Character = line.ElementAt(colonLocation-1)
                    },
                    Value = line.Substring(colonLocation+2)
                });
            }
            return passwords;
        }
    }
}
