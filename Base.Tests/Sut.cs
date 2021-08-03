using AutoFixture;

namespace Base.Tests
{
    public class Sut<T>
    {
        private readonly T _instance;
        private readonly TestSuitBase<T> _testSuit;

        public Sut(TestSuitBase<T> testSuit)
        {
            _testSuit = testSuit;
            _instance = testSuit.Fixture.Create<T>();
        }

        public void AndAssignToSutProperty() => _testSuit.Sut = _instance;
    }
}