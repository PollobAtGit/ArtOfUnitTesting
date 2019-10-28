using System;
using InternalChecker;
using NUnit.Framework;

namespace NUnitTest
{
    [TestFixture]
    public class InternalsTester
    {
        [Test]
        public void Should_Be_Able_To_Access_Internal_Members()
        {
            var id = Guid.NewGuid();

            // following is not accessible
            //var internalMember = new Service.Implementation.InternalMember(id);

            var internalMember = new InternalMember(id);
            Assert.AreEqual(internalMember.Id, id);
        }
    }
}
