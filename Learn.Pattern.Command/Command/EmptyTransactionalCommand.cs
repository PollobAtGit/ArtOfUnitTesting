using System.Threading.Tasks;

namespace Learn.Pattern.Command.Command
{
    public class EmptyTransactionalCommand : ITransactionalCommand
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}