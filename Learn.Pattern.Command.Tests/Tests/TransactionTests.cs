using System.Threading.Tasks;
using AutoFixture;
using Base.Tests;
using Learn.Pattern.Command.Command;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Tests.Spy;
using Learn.Pattern.Command.Tests.Stub;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Learn.Pattern.Command.Tests.Tests
{
    public class TransactionTests : TestSuitBase<TransactionalScriptSpy>
    {
        public TransactionTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task Should_Remove_Inserted_Entity_On_Error()
        {
            // Arrange

            var agentRepository = Fixture.Create<StubRepository<Agent>>();
            var customerRepository = Fixture.Create<StubRepository<Customer>>();

            var insertAgentCommand = new InsertAgentCommand(agentRepository);
            var removeAgentCommand = new RemoveAgentCommand(agentRepository);

            var insertCustomerCommand = new StubThrowExceptionOnInsertCustomerCommand(customerRepository);

            var agent = Fixture.Create<Agent>();
            var customer = Fixture.Create<Customer>();

            insertAgentCommand.SetEntity(agent);
            removeAgentCommand.SetEntity(agent);
            
            insertCustomerCommand.SetEntity(customer);

            CreateSut().AndAssignToSutProperty();

            Sut.SetCommand(insertAgentCommand, removeAgentCommand);
            Sut.SetCommand(insertCustomerCommand, new RemoveCustomerCommand(customerRepository));

            // Act

            await Sut.ExecuteAsync();

            // Assert

            agentRepository.InternalStore.ShouldBeEmpty();
        }

        [Fact]
        public async Task Should_Execute_Given_Command()
        {
            // Arrange

            var agentRepository = Fixture.Create<StubRepository<Agent>>();
            var customerRepository = Fixture.Create<StubRepository<Customer>>();

            var insertAgentCommand = new InsertAgentCommand(agentRepository);
            var insertCustomerCommand = new InsertCustomerCommand(customerRepository);

            var agent = Fixture.Create<Agent>();
            var customer = Fixture.Create<Customer>();

            insertAgentCommand.SetEntity(agent);
            insertCustomerCommand.SetEntity(customer);

            CreateSut().AndAssignToSutProperty();

            Sut.SetCommand(insertAgentCommand, new RemoveAgentCommand(agentRepository));
            Sut.SetCommand(insertCustomerCommand, new RemoveCustomerCommand(customerRepository));

            // Act

            await Sut.ExecuteAsync();

            // Assert

            agentRepository.InternalStore.ShouldContain(agent);
            customerRepository.InternalStore.ShouldContain(customer);
        }

        [Fact]
        public void Should_Set_Commands_In_Order()
        {
            // Arrange

            CreateSut().AndAssignToSutProperty();

            var agentRepository = new StubRepository<Agent>();
            var customerRepository = new StubRepository<Customer>();

            var insertAgentCommand = new InsertAgentCommand(agentRepository);
            var insertCustomerCommand = new InsertCustomerCommand(customerRepository);

            // Act

            Sut.SetCommand(insertAgentCommand, new RemoveAgentCommand(agentRepository));
            Sut.SetCommand(insertCustomerCommand, new RemoveCustomerCommand(customerRepository));

            var firstPoppedCommand = Sut.Pop();
            var secondPoppedCommand = Sut.Pop();
            var lastPoppedCommand = Sut.Pop();

            // Assert

            firstPoppedCommand.ShouldBe(insertCustomerCommand);
            secondPoppedCommand.ShouldBe(insertAgentCommand);
            lastPoppedCommand.ShouldBeOfType<EmptyTransactionalCommand>();
        }
    }
}