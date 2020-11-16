namespace Explore.Model.DataStore
{
    public class DataStore
    {
        public Repository.Repository Repository { get; }

        public DataStore(Repository.Repository repository) => Repository = repository;
    }
}