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
        private readonly ITestOutputHelper _outputHelper;
        private readonly Calculator.StringCalculator _calculator;

        public StringCalculatorShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _calculator = new Fixture().Create<Calculator.StringCalculator>();
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
        [ClassData(typeof(MoreThanTwoOnlyPositiveNumbersSeparatedByCommaProvider))]
        public void Return_Added_Value_Provided_That_The_Received_String_Contains_Multiple_Numbers(string input)
        {
            var result = _calculator.Add(ExtractInputPortionFromStatement(input));

            result.ShouldBe(ExtractResultPortionFromStatement(input));
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByNewLineProvider))]
        public void Return_Added_Value_Provided_That_The_Received_String_Has_New_Line_As_Separator(string input)
        {
            var result = _calculator.Add(ExtractInputPortionFromStatement(input));

            result.ShouldBe(ExtractResultPortionFromStatement(input));
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByDelimiterDefinedAtBeginningOfInput))]
        public void Return_Added_Value_Provided_That_The_Received_String_Has_Changing_Delimiter_Defined_As_The_Third_Character(string input)
        {
            var result = _calculator.Add(ExtractInputPortionFromStatement(input));

            result.ShouldBe(ExtractResultPortionFromStatement(input));
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNegativeNumbersSeparatedByCommaProvider))]
        public void Throw_Exception_Provided_That_The_Received_Input_Contains_Negative_Numbers(string input)
        {
            Action act = () => _calculator.Add(ExtractInputPortionFromStatement(input));
            act.ShouldThrow<NegativeNumbersAreNotAllowedException>();
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNegativeNumbersSeparatedByCommaProvider))]
        public void Throw_Exception_With_Negative_Numbers_That_Were_Provided_In_The_Received_Input(string input)
        {
            input = ExtractInputPortionFromStatement(input);

            Action act = () => _calculator.Add(input);

            var expectedException = act.ShouldThrow<NegativeNumbersAreNotAllowedException>();

            expectedException.NegativeNumbers.ShouldNotBeEmpty();

            expectedException.NegativeNumbers
                .Count(x => x < 0)
                .ShouldBe(expectedException.NegativeNumbers.Count);

            _outputHelper.WriteLine(string.Join(", ", expectedException.NegativeNumbers));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Return_Add_Method_Invocation_Count(int invocationCount)
        {
            foreach (var _ in Enumerable.Range(0, invocationCount))
                _calculator.Add("");

            var calledCount = _calculator.GetCalledCount();

            calledCount.ShouldBe(invocationCount);
        }

        [Theory]
        [ClassData(typeof(SingleNumberProvider))]
        [ClassData(typeof(TwoNumbersWithSameValueProvider))]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByNewLineProvider))]
        [ClassData(typeof(MoreThanTwoOnlyPositiveNumbersSeparatedByCommaProvider))]
        [ClassData(typeof(MoreThanTwoNumbersSeparatedByDelimiterDefinedAtBeginningOfInput))]
        public void Raise_Add_Occurred_Event_Provided_That_Add_Method_Is_Invoked(string input)
        {
            var hasInvoked = false;

            _calculator.AddOccurred += (x, y) => hasInvoked = true;

            _calculator.Add(ExtractInputPortionFromStatement(input));

            hasInvoked.ShouldBe(true);
        }

        [Theory]
        [ClassData(typeof(MoreThanTwoNegativeNumbersSeparatedByCommaProvider))]
        public void Raise_Add_Occurred_Event_Provided_That_Add_Method_Is_Invoked_And_Input_Contains_Negative_Numbers(string input)
        {
            var hasInvoked = false;

            _calculator.AddOccurred += (x, y) => hasInvoked = true;

            Action act = () => _calculator.Add(ExtractInputPortionFromStatement(input));
            act.IgnoreException();

            hasInvoked.ShouldBe(true);
        }

        [Theory]
        [InlineData("//+\n2 + 1001 = 2")]
        [InlineData("//+\n2 + 1001 + 5 = 7")]
        [InlineData("//+\n2 + 10001 + 5 = 7")]
        [InlineData("//+\n2 + 2001 + 5 = 7")]
        [InlineData("//+\n2 + 1000 + 5 = 1007")]
        public void Ignore_Numbers_Greater_Than_1000(string input)
        {
            var result = _calculator.Add(ExtractInputPortionFromStatement(input));

            result.ShouldBe(ExtractResultPortionFromStatement(input));
        }

        [Theory]
        [InlineData("//+\n1001 = 0")]
        [InlineData("//+\n1001 +1001= 0")]
        [InlineData("//+\n1001 +1001 + 2001= 0")]
        public void Return_0_Provided_That_All_Numbers_Are_Greater_Than_1000(string input)
        {
            var result = _calculator.Add(ExtractInputPortionFromStatement(input));

            result.ShouldBe(ExtractResultPortionFromStatement(input));
        }

        private static string ExtractInputPortionFromStatement(string input) => input.Split("=").First();

        private static int ExtractResultPortionFromStatement(string input)
        {
            var last = input.Split("=").Last();

            return int.TryParse(last, out var expectedResult)
                ? expectedResult
                : int.MinValue;
        }
    }
}

/*
 *TODO:
 * 1. Invalid numbers
 *
 */
