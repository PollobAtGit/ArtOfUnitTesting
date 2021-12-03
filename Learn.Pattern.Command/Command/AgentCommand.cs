using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Command
{
    public abstract class AgentCommand : ITransactionalCommand
    {
        protected Agent Agent { get; private set; }

        protected IRepository<Agent> Repository { get; }

        protected AgentCommand(IRepository<Agent> repository)
        {
            Repository = repository;
        }

        public void SetEntity(Agent agent)
        {
            Guard.Against.Null(agent, nameof(agent));

            Agent = agent;
        }

        public abstract Task ExecuteAsync();
    }
}