using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Models.PasswordPolicy
{
    public class Password
    {
        public Policy Policy { get; set; }
        public string Value { get; set; }
    }
}
