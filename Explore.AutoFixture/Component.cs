using System.Collections.Generic;

namespace Explore.AutoFixture
{
    internal class Component
    {
        public IList<Repository> Repositories { get; } = new List<Repository>();
    }
}