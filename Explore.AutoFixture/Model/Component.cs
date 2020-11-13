using System.Collections.Generic;

namespace Explore.AutoFixture.Model
{
    internal class Component
    {
        public IList<Repository.Repository> Repositories { get; } = new List<Repository.Repository>();
    }
}