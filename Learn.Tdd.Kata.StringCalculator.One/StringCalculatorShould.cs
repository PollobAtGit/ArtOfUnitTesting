using System;
using System.Linq;
using AutoFixture;
using Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider;
using Learn.Tdd.Kata.StringCalculator.One.Exceptions;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Learn.Tdd.Kata.StringCalculator.One
{
    public class StringCalculatorShould
    {
        private readonly Fixture _fixture;
        private readonly ITestOutputHelper _outputHelper;
        private readonly Calculator.StringCalculator _calculator;

        public StringCalculatorShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
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

        [Theory]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByCommaProvider))]
        public void Return_Added_Value_Provided_That_The_Received_String_Contains_Multiple_Numbers(string input)
        {
            var parts = input.Split("=");

            _calculator
                .Add(string.Join("", parts.First()))
                .ShouldBe(int.Parse(parts.Last().Trim()));
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByNewLineProvider))]
        public void Return_Added_Value_Provided_That_The_Received_String_Has_New_Line_As_Separator(string input)
        {
            var parts = input.Split("=");

            _calculator
                .Add(string.Join("", parts.First()))
                .ShouldBe(int.Parse(parts.Last().Trim()));
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByDelimiterDefinedAtBeginningOfInput))]
        public void Return_Added_Value_Provided_That_The_Received_String_Has_Changing_Delimiter_Defined_As_The_Third_Character(string input)
        {
            var parts = input.Split("=");

            _calculator
                .Add(string.Join("", parts.First()))
                .ShouldBe(int.Parse(parts.Last().Trim()));
        }

        [Theory]
        [InlineData("-4,4")]
        [InlineData("4,-4")]
        [InlineData("-4,-4")]
        public void Throw_Exception_Provided_That_The_Received_Input_Contains_Negative_Numbers(string input)
        {
            Action act = () => _calculator.Add(input);
            act.ShouldThrow<NegativeNumbersAreNotAllowedException>();
        }

        [Theory]
        [InlineData("-4,4")]
        [InlineData("4,-4")]
        [InlineData("-4,-4")]
        public void Throw_Exception_With_Negative_Numbers_That_Were_Provided_In_The_Received_Input(string input)
        {
            Action act = () => _calculator.Add(input);

            var expectedException = act.ShouldThrow<NegativeNumbersAreNotAllowedException>();

            expectedException.NegativeNumbers.ShouldNotBeEmpty();

            expectedException.NegativeNumbers
                .Select(int.Parse)
                .Count(x => x < 0)
                .ShouldBe(expectedException.NegativeNumbers.Count);

            _outputHelper.WriteLine(string.Join(", ", expectedException.NegativeNumbers));
        }
    }
}
