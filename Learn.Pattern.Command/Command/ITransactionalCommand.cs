using System.Threading.Tasks;

namespace Learn.Pattern.Command.Command
{
    public interface ITransactionalCommand
    {
        Task ExecuteAsync();
    }
}