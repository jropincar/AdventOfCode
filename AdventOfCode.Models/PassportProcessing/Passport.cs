using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AdventOfCode.Models.PassportProcessing
{
    public class Passport
    {
        public int byr {get; set; }
        public int iyr {get; set; }
        public int eyr {get; set; }
        public string hgt { get; set; }
        [JsonIgnore]
        public string measurement => hgt != null && hgt.Length > 2 ? hgt[^2..] : null;
        [JsonIgnore]
        public int hgtCm => measurement == "cm" ? Convert.ToInt32(hgt[..^2]) : 0;
        [JsonIgnore]
        public int hgtIn => measurement == "in" ? Convert.ToInt32(hgt[..^2]) : 0;
        public string hcl {get; set; }
        public string ecl {get; set; }
        public string pid {get; set; }
        public string cid {get; set; }
    }
}
