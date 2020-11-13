﻿using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Explore.AutoFixture.Test
{
    public class AutoFixtureXUnitLibShould
    {
        [Theory]
        [AutoData]
        public void Return_Autogenerated_Primitive_Value(int integer)
        {
            integer.Should().NotBe(0);
        }
    }
}
