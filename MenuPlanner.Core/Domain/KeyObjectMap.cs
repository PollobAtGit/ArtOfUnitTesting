using System;
using System.Collections.Generic;

namespace MenuPlanner.Core.Domain
{
    public class KeyObjectMap<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Data { get; set; }
    }

    public class DateTimeToObjectMap<TValue> : KeyObjectMap<DateTime, TValue>
    {
    }

    public class IntKeyToObjectMap<TValue> : KeyObjectMap<int, TValue>
    {
    }

    public class StringKeyToObjectMap<TValue> : KeyObjectMap<string, TValue>
    {
    }
}