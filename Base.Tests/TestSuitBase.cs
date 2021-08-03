using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Base.Tests
{
    public class TestSuitBase
    {
        protected OutputHelperImp OutputHelper { get; }

        public Fixture Fixture { get; } = new Fixture();

        public TestSuitBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = new OutputHelperImp(outputHelper);

            Fixture
                .Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(x => Fixture.Behaviors.Remove(x));

            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            Fixture.Register(() => new Point(30, 30));

            Fixture.Register(() =>
            {
                return Fixture
                    .Build<ActionDescriptor>()
                    .Without(x => x.Parameters)
                    .Without(x => x.BoundProperties)
                    .With(x => x.EndpointMetadata, new List<object> { new ApiControllerAttribute() })
                    .Create();
            });

            Fixture.Register(() => new ParameterDescriptor());

            // TODO: Inject repository
            //Fixture.Inject(new StubRepository());

            Fixture.Customize(new AutoMoqCustomization());
        }

        public VerifyDsl Start_Verifying() => new VerifyDsl(OutputHelper);

        public class OutputHelperImp
        {
            public ITestOutputHelper XUnitOutputHelper { get; }

            public OutputHelperImp(ITestOutputHelper outputXUnitOutputHelper) => XUnitOutputHelper = outputXUnitOutputHelper;

            public void WriteLine<T>(T v)
            {
                XUnitOutputHelper
                    .WriteLine(JsonConvert.SerializeObject(v, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
            }
        }
    }

    public class TestSuitBase<T> : TestSuitBase
    {
        public T Sut { get; set; }

        public TestSuitBase(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        protected Sut<T> CreateSut() => new Sut<T>(this);

        protected TController CreateControllerSut<TController>() where TController : Controller
        {
            return new ControllerObjectMother<TController>()
                .Create(Fixture);
        }
    }
}