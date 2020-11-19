using System;
using System.Linq;
using Learn.Tdd.Kata.StringCalculator.One.Exceptions;

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

            var numbers = parts.Last().Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var negativeNumbers = numbers
                .Where(x => x.StartsWith("-"))
                .Select(x => x)
                .ToList();

            if (negativeNumbers.Any())
                throw new NegativeNumbersAreNotAllowedException(negativeNumbers);

            if (numbers.Count == 1)
                return int.Parse(numbers.First());

            if (numbers.Count > 1)
                return numbers.Select(int.Parse).Sum();

            throw new NotImplementedException();
        }
    }
}