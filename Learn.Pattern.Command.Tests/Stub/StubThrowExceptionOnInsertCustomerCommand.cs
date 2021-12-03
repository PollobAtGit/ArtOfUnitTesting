using System;
using System.Threading.Tasks;
using Learn.Pattern.Command.Command;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Repository;

namespace Learn.Pattern.Command.Tests.Stub
{
    public class StubThrowExceptionOnInsertCustomerCommand : InsertCustomerCommand
    {
        public StubThrowExceptionOnInsertCustomerCommand(IRepository<Customer> repository) : base(repository)
        {
        }

        public override Task ExecuteAsync()
        {
            throw new Exception("db exception occurred");
        }
    }
}