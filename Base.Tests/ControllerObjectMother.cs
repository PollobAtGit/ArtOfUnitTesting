using AutoFixture;
using Microsoft.AspNetCore.Mvc;

namespace Base.Tests
{
    public class ControllerObjectMother<T> where T : Controller
    {
        public T Create(Fixture fixture)
        {
            return fixture
                .Build<T>()
                .Without(x => x.ViewData)
                .Create();
        }
    }
}