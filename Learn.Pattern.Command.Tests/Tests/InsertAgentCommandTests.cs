using System.Threading.Tasks;
using Learn.Pattern.Command.Command;
using Learn.Pattern.Command.Model;
using Learn.Pattern.Command.Tests.Stub;
using Shouldly;
using Xunit;

namespace Learn.Pattern.Command.Tests.Tests
{
    public class InsertAgentCommandTests
    {
        [Fact]
        public async Task Should_Insert_Into_Repository()
        {
            // Arrange

            var repository = new StubRepository<Agent>();

            var command = new InsertAgentCommand(repository);

            var agent = new Agent();
            
            command.SetEntity(agent);
            
            // Act

            await command.ExecuteAsync();

            // Assert

            repository.InternalStore.ShouldContain(agent);
        }
    }
}