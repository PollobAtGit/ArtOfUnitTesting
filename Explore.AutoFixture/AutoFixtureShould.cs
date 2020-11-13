using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Abstractions;

namespace Explore.AutoFixture
{
    public class AutoFixtureShould
    {
        private readonly Fixture _fixture;
        private readonly ITestOutputHelper _outputHelper;

        public AutoFixtureShould(ITestOutputHelper outputHelper)
        {
            _fixture = new Fixture();
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Create_Random_Non_Zero_Integer_When_Requested()
        {
            var randomInteger = _fixture.Create<int>();

            randomInteger.Should().NotBe(0);

            _outputHelper.WriteLine(randomInteger.ToString());
        }

        [Fact]
        public void Create_Non_Null_And_Non_Empty_String_When_Requested()
        {
            var randomString = _fixture.Create<string>();

            randomString.Should().NotBeNullOrWhiteSpace();

            _outputHelper.WriteLine(randomString);
        }

        [Fact]
        public void Create_Seeded_String_When_Requested()
        {
            const string prefix = "[TYU]";

            var randomString = _fixture.Create(prefix);

            randomString.Should().StartWith(prefix);
            randomString.Should().NotBeNullOrWhiteSpace();

            _outputHelper.WriteLine(randomString);
        }

        [Fact]
        public void Create_Complex_Type_When_Requested()
        {
            var dataStore = _fixture.Create<Repository>();

            dataStore.Should().NotBeNull();

            dataStore.Index.Should().NotBe(0);
            dataStore.Identifier.Should().StartWith(nameof(Repository.Identifier));

            _outputHelper.WriteLine(JsonConvert.SerializeObject(dataStore));
        }

        [Fact]
        public void Create_Nested_Dependent_Objects_As_Per_Automatic_Auto_Fixture_Behavior_When_Requested()
        {
            var dataStore = _fixture.Create<DataStore>();

            dataStore.Should().NotBeNull();
            dataStore.Repository.Should().NotBeNull();

            dataStore.Repository.Index.Should().NotBe(0);
            dataStore.Repository.Identifier.Should().StartWith(nameof(Repository.Identifier));

            _outputHelper.WriteLine(JsonConvert.SerializeObject(dataStore));
        }

        [Fact]
        public void Fail_To_Create_An_Fake_Instance_Of_The_Abstract_Type_When_Requested()
        {
            Action act = () => _fixture.Create<IRepository>();

            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Inject_Fake_Implementation_Of_An_Abstract_Type_If_Registered()
        {
            _fixture.Register<IRepository>(() => _fixture.Create<Repository>());

            var repository = _fixture.Create<IRepository>();

            repository.Should().NotBeNull();
            repository.Index.Should().NotBe(0);
            repository.Identifier.Should().StartWith(nameof(Repository.Identifier));

            _outputHelper.WriteLine(JsonConvert.SerializeObject(repository));
        }

        [Fact]
        public void Create_A_Sequence_Of_Non_Empty_And_Non_Null_String()
        {
            const string prefix = "SEED";

            var randomStrings = _fixture.CreateMany(prefix).ToList();

            randomStrings.Should().NotBeEmpty();

            foreach (var randomString in randomStrings)
                randomString.Should().StartWith(prefix);

            _outputHelper.WriteLine(string.Join(", ", randomStrings));
        }

        [Fact]
        public void Create_A_Sequence_Of_Non_Null_Objects_Of_Requested_Type()
        {
            var repositories = _fixture.CreateMany<Repository>().ToList();

            repositories.Should().NotBeEmpty();

            foreach (var repository in repositories)
                repository.Should().NotBeNull();

            _outputHelper.WriteLine(string.Join(", ", repositories.Select(JsonConvert.SerializeObject)));
        }

        [Fact]
        public void Add_Randomly_Created_Sequence_Of_Repositories_To_Component_Repository_List()
        {
            var component = _fixture.Create<Component>();

            component.Should().NotBeNull();

            component.Repositories.Should().BeEmpty();

            _fixture.AddManyTo(component.Repositories);

            component.Repositories.Should().HaveCount(3);

            _outputHelper.WriteLine(string.Join(", ", component.Repositories.Select(JsonConvert.SerializeObject)));
        }

        [Fact]
        public void Have_Default_Values_For_Properties_Provided_That_Auto_Properties_Are_Omitted()
        {
            var repository = _fixture
                .Build<Repository>()
                .OmitAutoProperties()
                .Create();

            repository.Index.Should().Be(0);
            repository.Identifier.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Have_Default_Value_For_Properties_That_Are_Disabled()
        {
            var repository = _fixture
                .Build<Repository>()
                .Without(x => x.Index)
                .Create();

            repository.Index.Should().Be(0);
            repository.Identifier.Should().NotBeEmpty();

            _outputHelper.WriteLine(JsonConvert.SerializeObject(repository));
        }

        [Fact]
        public void Add_Multiple_Instances_Of_Repository_To_A_Collection_Of_Repositories()
        {
            var repositories = new List<Repository>() as ICollection<Repository>;
            _fixture.AddManyTo(repositories);

            repositories.Should().NotBeEmpty();
        }
    }
}
