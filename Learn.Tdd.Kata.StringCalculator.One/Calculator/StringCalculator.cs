using System;
using System.Linq;

namespace Learn.Tdd.Kata.StringCalculator.One.Calculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;

            var numbers = input.Split(",");

            return numbers.Length switch
            {
                1 => int.Parse(numbers.First()),
                2 => int.Parse(numbers.First()) + int.Parse(numbers.Skip(1).First()),
                _ => throw new NotImplementedException()
            };
        }
    }
}