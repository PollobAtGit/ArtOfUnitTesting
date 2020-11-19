using System.Collections;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public abstract class MoreThanTwoNumbersProvider : IEnumerable<object[]>
    {
        public string Delimiter { get; protected set; }

        public IEnumerator<object[]> GetEnumerator()
        {
            // TODO:
            // for random recurrence
            //      get random numbers
            //      calculate sum
            //      prepare input

            yield return new object[] { $"4     {Delimiter}     5{Delimiter}     6{Delimiter}     8 = 23" };
            yield return new object[] { $"4     {Delimiter}     5 = 9" };
            yield return new object[] { $"4     {Delimiter}     5{Delimiter}     9 = 18" };
            yield return new object[] { $"4    {Delimiter}      5{Delimiter}     9{Delimiter}     78 = 96" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}