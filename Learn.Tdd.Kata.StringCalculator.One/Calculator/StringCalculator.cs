using System;
using System.Collections.Generic;
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
                    : new[] {input};

                var delimiters = isDelimiterDefinedAtTheBeginning
                    ? ExtractDelimiters(parts.First().TrimStart('/').TrimStart('/'))
                    : new[] {",", "\n"};

                var splittedNumbers = parts.Last().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                var numbers = splittedNumbers
                    .Select(x => int.Parse(x.Trim()))
                    .Where(x => x <= MaxAllowedValue)
                    .ToList();

                var negativeNumbers = numbers.Where(x => x < 0).ToList();

                if (negativeNumbers.Any())
                    throw new NegativeNumbersAreNotAllowedException(negativeNumbers);

                return numbers.Sum();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                _invocationCount += 1;
                AddOccurred?.Invoke(null, default);
            }

            throw new NotImplementedException();
        }

        private static string[] ExtractDelimiters(string parts)
        {
            return parts
                .Split("][")
                .Select(x => x.Trim('[', ']'))
                .ToArray();
        }

        public int GetCalledCount() => _invocationCount;

        public event Action<string, int> AddOccurred;
    }
}