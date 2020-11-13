using Newtonsoft.Json;

namespace Explore.XUnit
{
    public static class Extensions
    {
        public static T DeepClone<T>(this T o) => JsonConvert.DeserializeObject<T>(o.SerializeAsJson());

        public static string SerializeAsJson<T>(this T o) => JsonConvert.SerializeObject(o);
    }
}
