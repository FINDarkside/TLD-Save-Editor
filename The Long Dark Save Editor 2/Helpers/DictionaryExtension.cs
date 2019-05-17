using System.Collections.Generic;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    static class DictionaryExtension
    {
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : class
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : null;
        }
    }
}
