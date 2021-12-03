using System.Threading.Tasks;
using Learn.Pattern.Command.Command;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Tests.Stub;
using Shouldly;
using Xunit;

namespace Learn.Pattern.Command.Tests.Tests
{
    public class RemoveAgentCommandTests
    {
        [Fact]
        public async Task Should_Insert_Into_Repository()
        {
            var repository = new StubRepository<Agent>();

            var agent = new Agent();

            await repository.InsertAsync(agent);
            
            // Precondition
            
            repository.InternalStore.ShouldContain(agent);
            
            // Arrange

            var command = new RemoveAgentCommand(repository);

            command.SetEntity(agent);
            
            // Act

            await command.ExecuteAsync();

            // Assert

            repository.InternalStore.ShouldNotContain(agent);
        }
    }
}