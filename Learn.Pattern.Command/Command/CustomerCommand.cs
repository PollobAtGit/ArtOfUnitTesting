using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Command
{
    public abstract class CustomerCommand : ITransactionalCommand
    {
        protected Customer Customer { get; private set; }

        protected IRepository<Customer> Repository { get; }

        protected CustomerCommand(IRepository<Customer> repository)
        {
            Repository = repository;
        }

        public void SetEntity(Customer customer)
        {
            Guard.Against.Null(customer, nameof(customer));

            Customer = customer;
        }

        public abstract Task ExecuteAsync();
    }
}