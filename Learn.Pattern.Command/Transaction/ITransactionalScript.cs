using System.Threading.Tasks;
using Learn.Pattern.Command.Command;

namespace Learn.Pattern.Command.Transaction
{
    public interface ITransactionalScript
    {
        void SetCommand(ITransactionalCommand command, ITransactionalCommand undoCommand);

        Task ExecuteAsync();
    }
}