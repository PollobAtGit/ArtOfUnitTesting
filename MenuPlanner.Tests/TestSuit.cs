using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using MenuPlanner.Core;
using Newtonsoft.Json;
using Shouldly;
using Xunit.Abstractions;

namespace MenuPlanner.Tests
{
    public class TestSuitBase<T> : TestSuitBase
    {
        public T Sut { get; set; }

        public TestSuitBase(ITestOutputHelper outputHelper) : base(outputHelper)
        {

        }

        protected Sut<T> CreateSut() => new Sut<T>(this);

        //protected TController CreateControllerSut<TController>() where TController : Controller => new ControllerObjectMother<TController>().Create(Fixture);
    }

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

        //protected void ConfigureOptions<T>(T v) where T : class
        //{
        //    Fixture.Inject(Options.Create(v));
        //}

        protected void Fail()
        {
            true.ShouldBeFalse();
        }
    }

    public class VerifyDsl
    {
        private readonly TestSuitBase.OutputHelperImp _outputHelper;

        public VerifyDsl(TestSuitBase.OutputHelperImp outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public VerifyDsl Verify_Defined<T>(T v, bool shouldWriteVerifiedContentToOutput = true) where T : class
        {
            v.ShouldNotBeNull();

            if (shouldWriteVerifiedContentToOutput)
                _outputHelper.WriteLine(v);

            return this;
        }

        public VerifyDsl Verify_That_Service_Is_Defined<T>(T v) where T : class
        {
            v.ShouldNotBeNull();

            _outputHelper.WriteLine($"Instance of [{typeof(T).Name}] is defined");

            return this;
        }


        public VerifyDsl Verify_Undefined<T>(T v) where T : class
        {
            v.ShouldBeNull();

            _outputHelper.WriteLine($"Instance of [{typeof(T).Name}] is undefined");

            return this;
        }


        public VerifyDsl Verify(Action act)
        {
            act();

            return this;
        }

        public VerifyDsl Verify_Contains(Func<string> func, string verifyString)
        {
            var v = func();

            _outputHelper.XUnitOutputHelper.WriteLine($"{nameof(Verify_Contains)}: {v}");

            v.ShouldContain(verifyString);

            return this;
        }

        public VerifyDsl Verify_Value_Matches<T>(Func<T> factory, T verifyValue, string propertyName = "")
        {
            var v = factory();

            var propertyFriendlyName = propertyName.IsUndefined() ? "" : $" (for property [{propertyName}]) ";

            _outputHelper.XUnitOutputHelper.WriteLine($"{nameof(Verify_Value_Matches)}{propertyFriendlyName}: {v}");

            v.ShouldBe(verifyValue);

            return this;
        }
    }
}