using Microsoft.Extensions.Primitives;

namespace GameShop.Models.Utils
{
    public static class QueryUtils
    {
        public static string TryGetQueryParam(IQueryCollection query, string key,  string defaultValue)
        {
            if (!query.ContainsKey(key)) return defaultValue;
            if (query.TryGetValue(key, out var inner))
            {
                defaultValue = inner.First();
            }
            return defaultValue;
        }
        public static int TryGetQueryParam(IQueryCollection query, string key, int defaultValue)
        {
            if (!query.ContainsKey(key)) return defaultValue;
            if (query.TryGetValue(key, out var inner))
            {
                defaultValue = int.Parse(inner.First());
            }
            return defaultValue;
        }
        public static double TryGetQueryParam(IQueryCollection query, string key, double defaultValue)
        {
            if (!query.ContainsKey(key)) return defaultValue;
            if (query.TryGetValue(key, out var inner))
            {
                defaultValue = double.Parse(inner.First());
            }
            return defaultValue;
        }
        public static bool TryGetQueryParam(IQueryCollection query, string key, bool defaultValue)
        {
            if (!query.ContainsKey(key)) return defaultValue;
            if (query.TryGetValue(key, out var inner))
            {
                defaultValue = bool.Parse(inner.First());
            }
            return defaultValue;
        }
        public static bool TryGetQueryParamCheckBox(IQueryCollection query, string key, bool defaultValue)
        {
            if (!query.ContainsKey(key)) return defaultValue;
            if (query.TryGetValue(key, out var inner))
            {
                defaultValue = inner.First() == "on";
            }
            return defaultValue;
        }
    }
}
