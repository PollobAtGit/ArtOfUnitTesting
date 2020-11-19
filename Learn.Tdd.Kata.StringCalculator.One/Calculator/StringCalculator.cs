using System;
using System.Linq;

namespace Learn.Tdd.Kata.StringCalculator.One.Calculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;

            var isDelimiterDefinedAtTheBeginning = input.StartsWith("//");

            var parts = isDelimiterDefinedAtTheBeginning
                ? input.Split("\n")
                : new[]
                {
                    input
                };

            var delimiters = isDelimiterDefinedAtTheBeginning
                ? new[] { parts.First().Trim('/').Trim('/') }
                : new[] { ",", "\n" };

            var numbers = parts.Last().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Length == 1)
                return int.Parse(numbers.First());

            if (numbers.Length > 1)
                return numbers.Select(x => int.Parse(x.Trim())).Sum();

            throw new NotImplementedException();
        }
    }
}