using System.Threading.Tasks;

namespace Learn.Pattern.Command.Repository
{
    public interface IRepository<in T>
    {
        Task InsertAsync(T entity);
        
        Task RemoveAsync(T entity);
    }
}