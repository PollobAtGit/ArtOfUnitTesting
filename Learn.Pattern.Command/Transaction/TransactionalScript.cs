using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Learn.Pattern.Command.Command;

namespace Learn.Pattern.Command.Transaction
{
    public class TransactionalScript : ITransactionalScript
    {
        protected List<ITransactionalCommand> Commands { get; } = new();
        
        private readonly List<ITransactionalCommand> _undoCommand = new();

        public void SetCommand(ITransactionalCommand command, ITransactionalCommand undoCommand)
        {
            Guard.Against.Null(command, nameof(command));
            Guard.Against.Null(undoCommand, nameof(undoCommand));

            Commands.Add(command);
            _undoCommand.Add(undoCommand);
        }

        public async Task ExecuteAsync()
        {
            var commandWithIndexPair = Commands
                .Select((x, i) => new
                {
                    TransactionCommand = x,
                    Index = i
                });

            foreach (var pair in commandWithIndexPair)
            {
                try
                {
                    await pair.TransactionCommand.ExecuteAsync();
                }
                catch (Exception _)
                {
                    foreach (var command in _undoCommand.Take(pair.Index))
                        await command.ExecuteAsync();
                }
            }
        }
    }
}