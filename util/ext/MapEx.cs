using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class MapEx
    {
        public static V get<K, V>(this Dictionary<K, V> map, K key)
        {
            if (map.TryGetValue(key, out V value))
                return value;
            return default(V);
        }

        public static bool get<K, V>(this Dictionary<K, V> map, K key, out object value, Type type)
        {
            value = null;
            if (map.TryGetValue(key, out V obj))
            {
                try
                {
                    value = Convert.ChangeType(obj, type);
                    return true;
                }
                catch { }
            }
            return false;
        }
    }
}
