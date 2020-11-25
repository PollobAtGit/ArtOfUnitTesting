using System.Collections;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class MoreThanTwoOnlyPositiveNumbersSeparatedByCommaProvider : IEnumerable<object[]>
    {
        private readonly MoreThanTwoNumbersProvider _numbersProvider = new MoreThanTwoNumbersProvider
        {
            Delimiter = ",",
            AllowNegatives = false
        };

        public IEnumerator<object[]> GetEnumerator() => _numbersProvider.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}