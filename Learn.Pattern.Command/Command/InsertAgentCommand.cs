using System.Threading.Tasks;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Command
{
    public class InsertAgentCommand : AgentCommand
    {
        public InsertAgentCommand(IRepository<Agent> repository) : base(repository)
        {
        }

        public override async Task ExecuteAsync()
        {
            await Repository.InsertAsync(Agent);
        }
    }
}