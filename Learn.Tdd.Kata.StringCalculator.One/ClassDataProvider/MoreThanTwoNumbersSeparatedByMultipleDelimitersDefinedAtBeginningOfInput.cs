using System.Collections;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class MoreThanTwoNumbersSeparatedByMultipleDelimitersDefinedAtBeginningOfInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "//[*][%]\n1*2%3 == 6" };
            yield return new object[] { "//[*][%][||]\n1*2%3   ||8 == 14" };
            yield return new object[] { "//[**][%%]\n1**2%%3 =6" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}