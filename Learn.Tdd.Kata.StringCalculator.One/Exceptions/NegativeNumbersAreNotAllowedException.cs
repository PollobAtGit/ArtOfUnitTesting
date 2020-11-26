using System;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.Exceptions
{
    public class NegativeNumbersAreNotAllowedException : Exception
    {
        public List<int> NegativeNumbers { get; }

        public NegativeNumbersAreNotAllowedException(List<int> negativeNumbers) => NegativeNumbers = negativeNumbers;
    }
}