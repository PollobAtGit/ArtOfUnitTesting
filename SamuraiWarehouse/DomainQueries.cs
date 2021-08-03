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

        public static DomainQuery<Samurai> GetDomainQueries(this IQueryable<Samurai> query)
        {
            return new DomainQuery<Samurai>(query);
        }

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
    }
}
