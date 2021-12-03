using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Tests.Stub
{
    public class StubRepository<T> : IRepository<T>
    {
        private readonly List<T> _internalStore = new();

        public ReadOnlyCollection<T> InternalStore => _internalStore.AsReadOnly();

        public Task InsertAsync(T entity)
        {
            _internalStore.Add(entity);

            // original repository needs to invoke SaveChanges?

            return Task.CompletedTask;
        }

        public Task RemoveAsync(T entity)
        {
            _internalStore.Remove(entity);

            // original repository needs to invoke SaveChanges?
            
            return Task.CompletedTask;
        }
    }
}