namespace AdventOfCode.Models.PasswordPolicy
{
    public class Policy
    {
        public int LowConstraint { get; set; }
        public int HighConstraint { get; set; }
        public char Character { get; set; }
    }
}