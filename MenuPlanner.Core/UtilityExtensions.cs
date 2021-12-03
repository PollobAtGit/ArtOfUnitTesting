using System.Threading.Tasks;

namespace MenuPlanner.Core
{
    public static class UtilityExtensions
    {
        public static bool IsUndefined(this string v)
        {
            var trimmed = v?.Trim();

            return string.IsNullOrEmpty(trimmed) || string.IsNullOrWhiteSpace(trimmed);
        }

        public static Task<T> WrapInTask<T>(this T v) => Task.FromResult(v);
    }
}
