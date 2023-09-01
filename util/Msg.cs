using System;

namespace util
{
    public static class Log
    {
        public static Action<object> output;

        public static void msg(this object msg)
            => output?.Invoke(msg?.ToString() ?? "<null>");

        public static void msgj(this object obj)
            => output?.Invoke(obj.json());

        public static void logRecover(this object obj, Action func)
        {
            var fout = output;
            try
            {
                func();
            }
            finally
            {
                output = fout;
            }
        }
    }
}
