namespace Explore.AutoFixture.DataStore
{
    internal class DataStore
    {
        public Repository.Repository Repository { get; }

        public DataStore(Repository.Repository repository) => Repository = repository;
    }
}