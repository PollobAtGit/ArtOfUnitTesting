using System;

namespace Service.Implementation
{
    internal class InternalMember
    {
        internal Guid Id { get; }

        internal InternalMember(Guid guid)
        {
            Id = guid;
        }
    }
}
