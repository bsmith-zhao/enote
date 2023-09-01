using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class ArrayEx
    {
        public static T[] each<T>(this T[] arr, Action<int, T> func)
        {
            if (null != arr)
            {
                for (int i = 0; i < arr.Length; i++)
                    func(i, arr[i]);
            }
            return arr;
        }

        public static T[] array<T>(this T elem)
            => new T[] { elem };

        public static T item<T>(this T[] arr, int index)
        {
            if (null == arr || arr.Length <= index)
                return default(T);
            return arr[index];
        }

        public static void burn<T>(this T[] arr)
        {
            if (null == arr)
                return;
            Array.Clear(arr, 0, arr.Length);
        }

        public static T[] push<T>(this T[] src, params T[] elems)
        {
            var size = (src?.Length ?? 0) + elems.Length;
            var arr = new List<T>(size);
            arr.AddRange(elems);
            if (null != src)
                arr.AddRange(src);
            return arr.ToArray();
        }

        public static T[] append<T>(this T[] src, params T[] elems)
        {
            var size = (src?.Length ?? 0) + elems.Length;
            var arr = new List<T>(size);
            if (null != src)
                arr.AddRange(src);
            arr.AddRange(elems);
            return arr.ToArray();
        }

        public static T[] delByLowKey<T>(this T[] src, string elem)
        {
            if (null == src)
                return src;
            elem = elem?.ToLower();
            var arr = new List<T>();
            for (var i = 0; i < src.Length; i++)
            {
                if (elem == src[i]?.ToString().ToLower())
                    continue;
                arr.Add(src[i]);
            }
            return arr.ToArray();
        }

        public static T[] delete<T>(this T[] src, T elem) where T : IComparable
        {
            if (null == src)
                return src;
            var arr = new List<T>();
            for (var i = 0; i < src.Length; i++)
            {
                if (src[i] == null && elem == null)
                    continue;
                if (src[i]?.CompareTo(elem) == 0)
                    continue;
                arr.Add(src[i]);
            }
            return arr.ToArray();
        }

        public static T[] merge<T>(this T[] src, params T[][] arrs)
        {
            var list = new List<T>(src.Length + arrs.Sum(arr => arr.Length));
            list.AddRange(src);
            foreach (var arr in arrs)
            {
                list.AddRange(arr);
            }
            return list.ToArray();
        }

        public static T[] merge<T>(this T[] src, int fix, params T[][] arrs)
        {
            int size = Math.Max(src.Length + arrs.Sum(arr => arr.Length), fix);
            var list = new List<T>(size);

            list.AddRange(src);
            foreach (var arr in arrs)
            {
                list.AddRange(arr);
            }
            if (list.Count < fix)
            {
                list.AddRange(new T[fix - list.Count]);
            }

            if (list.Count == fix)
                return list.ToArray();

            return list.Take(fix).ToArray();
        }

        //public static T[] merge<T>(this T[][] arrs, int size = -1)
        //{
        //    if (size <= 0)
        //        size = arrs.Sum(arr => arr.Length);
        //    var list = new List<T>(size);
        //    foreach (var arr in arrs)
        //    {
        //        list.AddRange(arr);
        //    }
        //    return list.limit(size);
        //}

        public static T last<T>(this T[] arr)
        {
            return arr[arr.Length - 1];
        }

        public static T[] last<T>(this T[] arr, int count)
        {
            if (arr.Length <= count)
                return arr;
            return arr.Skip(arr.Length - count).ToArray();
        }

        public static T[] sub<T>(this T[] src, int offset, int count)
        {
            var dst = new T[count];
            if (count == 0)
                return dst;
            Array.Copy(src, offset, dst, 0, count);
            return dst;
        }

        public static T[] jump<T>(this T[] src, int offset)
        {
            return src.Skip(offset).ToArray();
        }

        public static T[] head<T>(this T[] src, int count)
        {
            return src.Take(count).ToArray();
        }

        public static T[] fix<T>(this T[] src, int count)
        {
            if (src.Length == count)
                return src;
            else if (src.Length > count)
                return src.head(count);
            var dst = new T[count];
            Array.Copy(src, dst, src.Length);
            return dst;
        }

        public static D[] conv<S, D>(this S[] src, Func<S, D> func)
        {
            if (null == src)
                return null;

            var dst = new D[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                dst[i] = func(src[i]);
            }
            return dst;
        }

        public static D[] conv<S, D>(this S[] src, Func<int, S, D> func)
        {
            if (null == src)
                return null;

            var dst = new D[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                dst[i] = func(i, src[i]);
            }
            return dst;
        }
    }
}
