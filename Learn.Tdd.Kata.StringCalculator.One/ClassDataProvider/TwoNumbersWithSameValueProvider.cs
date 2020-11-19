using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class TwoNumbersWithSameValueProvider : IEnumerable<object[]>
    {
        private readonly Fixture _fixture;

        public TwoNumbersWithSameValueProvider() => _fixture = new Fixture();

        public IEnumerator<object[]> GetEnumerator()
        {
            var randomNumbers = _fixture.CreateMany<int>(20);

            return randomNumbers
                .Select(x => new object[] { x + "," + x })
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}