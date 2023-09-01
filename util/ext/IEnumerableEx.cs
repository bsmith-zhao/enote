using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class IEnumerableEx
    {
        public static T first<T>(this IEnumerable iter, Func<T, bool> func)
        {
            if (null != iter)
            {
                foreach (T elem in iter)
                {
                    if (func(elem))
                        return elem;
                }
            }
            return default(T);
        }

        public static IEnumerable<T> each<T>(this IEnumerable<T> iter, Action<T> func)
        {
            if (null != iter)
            {
                foreach (var e in iter)
                    func(e);
            }
            return iter;
        }

        public static IEnumerable each<T>(this IEnumerable iter, Action<T> func)
        {
            if (null != iter)
            {
                foreach (T e in iter)
                    func(e);
            }
            return iter;
        }

        public static HashSet<T> toSet<T>(this IEnumerable<T> iter)
        {
            var set = new HashSet<T>();
            foreach (var elem in iter)
                set.Add((T)elem);
            return set;
        }
    }
}
