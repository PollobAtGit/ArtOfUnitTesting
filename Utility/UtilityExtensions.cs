using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Utility
{
    public static class UtilityExtensions
    {
        public static Task<T> WrapInTask<T>(this T v) => Task.FromResult(v);

        public static List<T> WrapInList<T>(this T v) => new List<T>
        {
            v
        };

        public static bool IsDefault<T>(this T v) => EqualityComparer<T>.Default.Equals(v, default);

        public static bool IsUndefined(this string[] arguments) => arguments.Any(IsUndefined);

        public static bool IsUndefined(this string v)
        {
            var trimmed = v?.Trim();

            return string.IsNullOrEmpty(trimmed) || string.IsNullOrWhiteSpace(trimmed);
        }

        public static string ToJson<T>(this T obj, Formatting formatting = Formatting.None) => JsonConvert.SerializeObject(obj, formatting, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        public static string ToFormattedJson<T>(this T obj) => obj.ToJson(Formatting.Indented);

        public static T To<T>(this string contentAsJson) => JsonConvert.DeserializeObject<T>(contentAsJson);

        public static string StringJoin<T>(this IEnumerable<T> sequence, StringJoinSeparator separator = StringJoinSeparator.SemiColon) => string.Join(separator.GetSeparator(), sequence);

        public static string GetSeparator(this StringJoinSeparator separator)
        {
            return separator switch
            {
                StringJoinSeparator.NewLine => Environment.NewLine,
                StringJoinSeparator.Comma => ",",
                _ => ";"
            };
        }

        public static string ToCapCased(this string v) => Regex.Replace(v, "(\\B[A-Z])", " $1");
    }
}