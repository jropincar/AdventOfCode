using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AdventOfCode.Models.PassportProcessing;
using AdventOfCode.Services.Interfaces;
using AdventOfCode.Services.Services.Validators;
using Newtonsoft.Json;

namespace AdventOfCode.Services.Services
{
    public class PassportProcessingServices : IServices
    {
        private readonly IPassportValidator _passportValidator;
        private readonly PassportProcessingConfig _passportProcessingConfig;

        public PassportProcessingServices(PassportProcessingConfig passportProcessingConfig, IPassportValidator passportValidator)
        {
            _passportProcessingConfig = passportProcessingConfig;
            _passportValidator = passportValidator;
        }
        public int Run()
        {
            var line = File.ReadAllText(_passportProcessingConfig.DataSetUrl);
            var lines = line.Split("\r\n\r").ToList();
            return RunPassportProcessingSmart(lines);
        }

        private int RunPassportProcessingSmart(List<string> lines)
        {
            return (from line in lines
                select line.Replace("\r", " ")
                    .Replace("\n", " ")
                    .Replace("\r\n", " ")
                    .Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToDictionary(x => x.Split(':')[0], x => x.Split(':')[1])
                into passportDictionary
                select JsonConvert.SerializeObject(passportDictionary, Formatting.Indented)
                into json
                select JsonConvert.DeserializeObject<Passport>(json)).Count(passport => _passportValidator.Validate((Passport) passport).IsValid);
        }

        //Wrote this for the first star. Its dumber than the one above.
        private int RunPassportProcessingDumb(List<string> lines)
        {
            var valid = 0;
            foreach (var line in lines)
            {
                var passport = line.Replace("\r", " ")
                    .Replace("\n", " ")
                    .Replace("\r\n", " ")
                    .Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToList();
                if (passport.Count() == 8 || (passport.Count() == 7 && passport.All(x => !x.Contains("cid"))))
                {
                    Console.WriteLine("valid");
                    valid++;

                }
                else
                {
                    Console.WriteLine("not valid");
                }
            }
            return valid;
        }
    }
}
