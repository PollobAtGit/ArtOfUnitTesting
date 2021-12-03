using System.Threading.Tasks;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Command
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(IRepository<Customer> repository) : base(repository)
        {
        }

        public override async Task ExecuteAsync()
        {
            await Repository.RemoveAsync(Customer);
        }
    }
}