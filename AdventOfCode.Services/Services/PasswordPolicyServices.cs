using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Models;
using AdventOfCode.Models.PasswordPolicy;
using AdventOfCode.Services.Interfaces;
using AdventOfCode.Services.Mappers;

namespace AdventOfCode.Services.Services
{
    public class PasswordPolicyServices : IServices
    {
        private readonly PasswordPolicyConfig _passwordPolicyConfig;
        private readonly PasswordPolicyMapper _passwordPolicyMapper;
        public PasswordPolicyServices(PasswordPolicyConfig passwordPolicyConfig, PasswordPolicyMapper passwordPolicyMapper)
        {
            _passwordPolicyConfig = passwordPolicyConfig;
            _passwordPolicyMapper = passwordPolicyMapper;
        }
        public int Run()
        {
            var lines = File.ReadAllLines(_passwordPolicyConfig.DataSetUrl).ToList();
            var passwordsAndPolicies = _passwordPolicyMapper.Map(lines);
            return _passwordPolicyConfig.ByOccurrence ? RunPasswordOccurrencePolicy(passwordsAndPolicies) : RunPasswordPositionPolicy(passwordsAndPolicies); 
        }

        private static int RunPasswordPositionPolicy(List<Password> passwordsAndPolicies)
        {
            var correct = 0;
            foreach (var passwordAndPolicy in passwordsAndPolicies)
            {
                //Plus ones because their systems don't recognize index 0 LOL!!!
                //Also note the (^) symbol. Its an exclusive or
                if (!(passwordAndPolicy.Value.ElementAt(passwordAndPolicy.Policy.LowConstraint - 1) ==
                      passwordAndPolicy.Policy.Character
                      ^ passwordAndPolicy.Value.ElementAt(passwordAndPolicy.Policy.HighConstraint - 1) ==
                      passwordAndPolicy.Policy.Character)) continue;
                correct++;
            }
            return correct;
        }

        private static int RunPasswordOccurrencePolicy(List<Password> passwordsAndPolicies)
        {
            var correct = 0;
            foreach (var passwordAndPolicy in passwordsAndPolicies)
            {
                var occurrences = passwordAndPolicy.Value.Count(x => x == passwordAndPolicy.Policy.Character);
                if (occurrences > passwordAndPolicy.Policy.HighConstraint ||
                    occurrences < passwordAndPolicy.Policy.LowConstraint) continue;
                Console.WriteLine($"There are at least {passwordAndPolicy.Policy.LowConstraint} and as many as {passwordAndPolicy.Policy.HighConstraint} occurrences of {passwordAndPolicy.Policy.Character} in {passwordAndPolicy.Value}");
                correct++;
            }
            return correct;
        }
    }
}
