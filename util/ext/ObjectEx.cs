using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class ObjectEx
    {
        public static object @new(this Type type)
            => Activator.CreateInstance(type);

        public static T @new<T>(this Type type)
            => (T)Activator.CreateInstance(type);

        public static void swap<T>(this T obj, ref T a, ref T b)
        {
            var t = b;
            b = a;
            a = t;
        }

        // swap test
        //var a = 1;
        //var b = 2;
        //a = a.swap(ref b);
        //$"a={a}".debug();
        //$"b={b}".debug();
    }
}
