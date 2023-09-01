using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util.ext;

namespace util
{
    public static class Test
    {
        public static void hexLog(this byte[] data, string name)
        {
            $"{name} size: {data.Length}, {data.hex()}".msg();
        }

        public static void b64Log(this byte[] data, string name)
        {
            $"{name} size: {data.Length}, {data.b64()}".msg();
        }

        public static void evalTime(this string name, Action func)
        {
            var begin = DateTime.UtcNow;
            $"<{name}> begin".msg();
            func();
            var span = DateTime.UtcNow - begin;
            $"<{name}> time cost: {span}".msg();
        }
    }
}
