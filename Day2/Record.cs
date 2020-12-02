using System.Text.RegularExpressions;

namespace Day2
{
    internal class Record
    {
        private const int C_LOWER_INDEX = 1;

        private readonly Range range;
        private readonly string password;
        private readonly Regex inputRegex = new Regex(@"(\d+)-(\d+) (\w): (\w+)");

        public Record(string inputLine)
        {
            Match match = inputRegex.Match(inputLine);

            int lower = int.Parse(match.Groups[C_LOWER_INDEX].Value);
            int upper = int.Parse(match.Groups[C_LOWER_INDEX + 1].Value);
            char character = match.Groups[C_LOWER_INDEX + 2].Value[0];

            range = new Range(lower, upper, character);
            password = match.Groups[C_LOWER_INDEX + 3].Value;
        }

        public bool IsPasswordValid() => range.IsPhraseInRange(password);

        public bool IsPasswordUltraValid() => range.IsPhraseValidWithNewPolicy(password);
    }
}
