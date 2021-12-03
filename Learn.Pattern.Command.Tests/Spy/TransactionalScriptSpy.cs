using System.Linq;
using Learn.Pattern.Command.Command;
using Learn.Pattern.Command.Transaction;

namespace Learn.Pattern.Command.Tests.Spy
{
    public class TransactionalScriptSpy : TransactionalScript
    {
        public ITransactionalCommand Pop()
        {
            if (!Commands.Any())
                return new EmptyTransactionalCommand();

            var command = Commands[^1];

            Commands.RemoveAt(Commands.Count - 1);

            return command;
        }
    }
}