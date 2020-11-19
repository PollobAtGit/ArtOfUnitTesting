using System;
using System.Linq;
using AutoFixture;
using Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider;
using Shouldly;
using Xunit;

namespace Learn.Tdd.Kata.StringCalculator.One
{
    public class StringCalculatorShould
    {
        private readonly Fixture _fixture;
        private readonly Calculator.StringCalculator _calculator;

        public StringCalculatorShould()
        {
            _fixture = new Fixture();
            _calculator = _fixture.Create<Calculator.StringCalculator>();
        }

        [Fact]
        public void Return_Zero_For_Provided_That_Received_String_Is_Empty() => _calculator.Add("").ShouldBe(0);

        [Theory]
        [ClassData(typeof(SingleNumberProvider))]
        public void Return_The_Received_Number_Provided_That_Received_String_Contains_Only_Single_Number(string input)
        {
            _calculator.Add(input).ShouldBe(int.Parse(input));
        }

        [Theory]
        [ClassData(typeof(TwoNumbersWithSameValueProvider))]
        public void Return_Twice_The_Value_Of_The_Single_Number_Provided_That_The_Received_String_Contains_Two_Numbers_Having_Same_Value(string input)
        {
            var firstNumber = int.Parse(input.Split(",").First());
            _calculator.Add(input).ShouldBe(firstNumber + firstNumber);
        }
    }
}
