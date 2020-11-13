namespace Explore.AutoFixture
{
    internal class DataStore
    {
        public Repository Repository { get; }

        public DataStore(Repository repository) => Repository = repository;
    }
}