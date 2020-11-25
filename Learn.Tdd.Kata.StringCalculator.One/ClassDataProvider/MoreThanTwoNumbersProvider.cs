using System;
using System.Collections;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class MoreThanTwoNumbersProvider : IEnumerable<object[]>
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public string Delimiter { get; set; }

        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public bool? AllowNegatives { get; set; }

        public IEnumerator<object[]> GetEnumerator()
        {
            if (string.IsNullOrEmpty(Delimiter))
                throw new Exception($"{nameof(Delimiter)} is required");

            if (!AllowNegatives.HasValue)
                throw new Exception($"{nameof(AllowNegatives)} is required");

            // TODO:
            // for random recurrence
            //      get random numbers
            //      calculate sum
            //      prepare input

            if (AllowNegatives.Value)
            {
                yield return new object[] { $"-4     {Delimiter}     -5{Delimiter}     6{Delimiter}     8 = ??" };
                yield return new object[] { $"-4     {Delimiter}     -5 = ??" };
                yield return new object[] { $"-4     {Delimiter}     -5{Delimiter}     9 = ??" };
                yield return new object[] { $"-4     {Delimiter}      -5{Delimiter}     9{Delimiter}     78 = ??" };
            }
            else
            {
                yield return new object[] { $"4     {Delimiter}     5{Delimiter}     6{Delimiter}     8 = 23" };
                yield return new object[] { $"4     {Delimiter}     5 = 9" };
                yield return new object[] { $"4     {Delimiter}     5{Delimiter}     9 = 18" };
                yield return new object[] { $"4     {Delimiter}     5{Delimiter}     9{Delimiter}     78 = 96" };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}