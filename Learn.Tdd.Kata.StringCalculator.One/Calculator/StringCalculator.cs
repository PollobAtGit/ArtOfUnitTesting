using System;
using System.Linq;
using Learn.Tdd.Kata.StringCalculator.One.Exceptions;

namespace Learn.Tdd.Kata.StringCalculator.One.Calculator
{
    public class StringCalculator
    {
        private int _invocationCount;
        private const int MaxAllowedValue = 1000;

        public int Add(string input)
        {
            try
            {
                if (input == "")
                    return 0;

                var isDelimiterDefinedAtTheBeginning = input.StartsWith("//");

                var parts = isDelimiterDefinedAtTheBeginning
                    ? input.Split("\n")
                    : new[] { input };

                var delimiters = isDelimiterDefinedAtTheBeginning
                    ? new[] { parts.First().Trim('/').Trim('/') }
                    : new[] { ",", "\n" };

                var numbers = parts.Last()
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x.Trim()))
                    .Where(x => x <= MaxAllowedValue)
                    .ToList();

                var negativeNumbers = numbers.Where(x => x < 0).ToList();

                if (negativeNumbers.Any())
                    throw new NegativeNumbersAreNotAllowedException(negativeNumbers);

                return numbers.Sum();
            }
            finally
            {
                _invocationCount += 1;
                AddOccurred?.Invoke(null, default);
            }

            throw new NotImplementedException();
        }

        public int GetCalledCount() => _invocationCount;

        public event Action<string, int> AddOccurred;
    }
}