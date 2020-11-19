using System;
using System.Collections.Generic;

namespace Learn.Tdd.Kata.StringCalculator.One.Exceptions
{
    public class NegativeNumbersAreNotAllowedException : Exception
    {
        public List<string> NegativeNumbers { get; }

        public NegativeNumbersAreNotAllowedException(List<string> negativeNumbers) => NegativeNumbers = negativeNumbers;
    }
}