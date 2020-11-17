using System;

namespace Explore.Model.Model
{
    [Flags]
    public enum Os
    {
        Windows = 1 << 0,
        Linux = 1 << 1,
        FreeBsd = 1 << 2
    }
}