using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Learn.Tdd.Kata.StringCalculator.One.ClassDataProvider
{
    public class SingleNumberProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() =>
            Enumerable
                .Range(-10, 20)
                .Select(x => new object[] { x.ToString() })
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}