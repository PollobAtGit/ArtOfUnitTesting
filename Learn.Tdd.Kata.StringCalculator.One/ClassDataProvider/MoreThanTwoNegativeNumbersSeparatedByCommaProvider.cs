using System.Collections;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class MoreThanTwoNegativeNumbersSeparatedByCommaProvider : IEnumerable<object[]>
    {
        private readonly MoreThanTwoNumbersProvider _numbersProvider = new MoreThanTwoNumbersProvider
        {
            Delimiter = ",",
            AllowNegatives = true
        };

        public IEnumerator<object[]> GetEnumerator() => _numbersProvider.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}