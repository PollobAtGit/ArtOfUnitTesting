using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("NUnitTest")]
namespace InternalChecker
{
    internal class InternalMember
    {
        internal Guid Id { get; }

        internal InternalMember(Guid id)
        {
            Id = id;
        }
    }
}
