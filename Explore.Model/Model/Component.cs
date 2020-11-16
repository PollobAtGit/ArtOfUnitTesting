using System.Collections.Generic;

namespace Explore.Model.Model
{
    public class Component
    {
        public IList<Repository.Repository> Repositories { get; } = new List<Repository.Repository>();
    }
}