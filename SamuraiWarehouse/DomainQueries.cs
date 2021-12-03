using System.Linq;
using Utility;

namespace SamuraiWarehouse
{
    public static class DomainQueries
    {
        public class DomainQuery<T>
        {
            public IQueryable<T> Queryable { get; }

            public DomainQuery(IQueryable<T> queryable)
            {
                Queryable = queryable;
            }
        }

        public static DomainQuery<T> GetDomainQueries<T>(this IQueryable<T> query) => new DomainQuery<T>(query);

        public static DomainQuery<Samurai> GetSamuraiWithNames(this DomainQuery<Samurai> queryObj)
        {
            return new DomainQuery<Samurai>(queryObj.Queryable.Where(x => !string.IsNullOrWhiteSpace(x.Name)));
        }

        public static DomainQuery<Samurai> GetSamuraiWhoFoughtInBattles(this DomainQuery<Samurai> queryObj)
        {
            return new DomainQuery<Samurai>(queryObj.Queryable.Where(x => !x.SamuraiBattles.IsDefault() && x.SamuraiBattles.Any()));
        }

        public static DomainQuery<Samurai> GetRegisteredSamurais(this DomainQuery<Samurai> queryObj)
        {
            return new DomainQuery<Samurai>(queryObj.Queryable.Where(x => x.Id > 50));
        }

        public static DomainQuery<Quote> GetQuotesWithNames(this DomainQuery<Quote> queryObj)
        {
            return new DomainQuery<Quote>(queryObj.Queryable.Where(x => !string.IsNullOrWhiteSpace(x.Text)));
        }

        public static DomainQuery<Quote> GetOrphanedQuotes(this DomainQuery<Quote> queryObj)
        {
            // ReSharper disable once MergeIntoPattern
            return new DomainQuery<Quote>(queryObj.Queryable.Where(x => x.Samurai.IsDefault())); // TODO: will it be properly translated to sql query?
        }
    }
}
