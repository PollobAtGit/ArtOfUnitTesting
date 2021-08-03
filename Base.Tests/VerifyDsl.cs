using System;
using System.Collections.Generic;
using Shouldly;
using Utility;

namespace Base.Tests
{
    public class VerifyDsl
    {
        private readonly TestSuitBase.OutputHelperImp _outputHelper;

        public VerifyDsl(TestSuitBase.OutputHelperImp outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public VerifyDsl Verify_Collection_Is_Populated<T>(List<T> v) where T : class
        {
            v.ShouldNotBeEmpty();
            
            _outputHelper.XUnitOutputHelper.WriteLine($"Collection of [{typeof(T).Name}] is not empty");

            return this;
        }

        public VerifyDsl Verify_Collection_Is_Empty<T>(List<T> v) where T : class
        {
            v.ShouldBeEmpty();

            _outputHelper.XUnitOutputHelper.WriteLine($"Collection of [{typeof(T).Name}] is empty");

            return this;
        }

        public VerifyDsl Verify_Defined<T>(T v) where T : class
        {
            v.ShouldNotBeNull();

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