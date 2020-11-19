using System.Collections;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class MoreThanTwoNumbersSeparatedByDelimiterDefinedAtBeginningOfInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "//;\n1;2 = 3" };
            yield return new object[] { "//,\n1,2 = 3" };
            yield return new object[] { "//|\n1|2 = 3" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}