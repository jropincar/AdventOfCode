using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Models.PassportProcessing;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.VisualBasic;

namespace AdventOfCode.Services.Services.Validators
{
    public interface IPassportValidator : IValidator<Passport>
    {
        new ValidationResult Validate(Passport context);
    }
    public class PassportValidator : AbstractValidator<Passport>, IPassportValidator
    {
        
        private readonly List<string> _eyeColors = new List<string>{ "amb","blu","brn","gry","grn","hzl","oth"};
        public PassportValidator()
        {
            RuleFor(x => x.byr).NotNull().InclusiveBetween(1920, 2002);
            RuleFor(x => x.iyr).NotNull().InclusiveBetween(2010, 2020);
            RuleFor(x => x.eyr).NotNull().InclusiveBetween(2020, 2030);
            RuleFor(x => x.hgt)
                .NotNull()
                .MinimumLength(3);
            RuleFor(x => x.hgtCm)
                .InclusiveBetween(150, 193)
                .When(z => z.measurement == "cm");
            RuleFor(x => x.hgtIn).InclusiveBetween(59, 76)
                .When(z => z.measurement == "in");
            RuleFor(x => x.hcl).NotNull().Matches("^#[0-9a-f]{6}");
            RuleFor(x => x.ecl).NotNull().Must(x=> _eyeColors.Contains(x));
            RuleFor(x => x.pid).NotNull().Matches("^[0-9]{9}$");
        }
    }
}