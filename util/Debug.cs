using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util
{
    public static class Debug
    {
        public static Action<object> output = Console.WriteLine;

        public static void debug(this object msg)
            => show(msg?.ToString() ?? "<null>");

        static void show(string msg)
            => output?.Invoke($"[{DateTime.UtcNow}]<debug>{msg}");
    }
}
