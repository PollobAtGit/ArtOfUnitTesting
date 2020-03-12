using System;
using AUT.Revise;
using FluentAssertions;
using Moq;
using Xunit;

namespace AUT.Test.Tests
{
    public class ExtensionManagerFactoryShould
    {
        [Fact]
        public void Throw_Exception_Provided_That_Instance_Is_Requested_Before_SetExtensionManager_Is_Invoked()
        {
            // interesting this test's success depends on in which order these tests run (when ran in same session) because there's usage of 'static'
            Func<IExtensionManager> act = ExtensionManagerFactory.Create;

            act.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage($"Extension manager is not set. Invoke {nameof(ExtensionManagerFactory.SetExtensionManager)} to set extension manager");
        }

        [Fact]
        public void Return_The_Same_Instance_When_Requested_That_Has_Been_Set_Via_SetExtensionManager()
        {
            var extensionManagerMock = new Mock<IExtensionManager>();

            ExtensionManagerFactory.SetExtensionManager(extensionManagerMock.Object);

            ExtensionManagerFactory.Create().Should().BeSameAs(extensionManagerMock.Object);
        }
    }
}
