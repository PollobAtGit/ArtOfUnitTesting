using System.Threading.Tasks;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Command
{
    public class InsertCustomerCommand : CustomerCommand
    {
        public InsertCustomerCommand(IRepository<Customer> repository) : base(repository)
        {
        }

        public override async Task ExecuteAsync()
        {
            await Repository.InsertAsync(Customer);
        }
    }
}