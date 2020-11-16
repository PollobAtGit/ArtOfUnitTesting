using System;

namespace Explore.Model.DataStore
{
    public class CatalogDataStore
    {
        public Guid Id { get; set; }

        public Repository.IRepository Repository { get; }

        public CatalogDataStore(Repository.IRepository repository) => Repository = repository;
    }
}