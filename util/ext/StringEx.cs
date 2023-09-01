using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class StringEx
    {
        public static char last(this string str)
            => str[str.Length - 1];

        public static char[] paste(this char[] dst, int off, string value)
        {
            var src = value.ToCharArray();
            Buffer.BlockCopy(src, 0, dst, off * 2, src.Length * 2);
            return dst;
        }

        public static string merge(this string[] arr, string sep)
        {
            return string.Join(sep, arr);
        }

        public static string jump(this string str, int count)
        {
            return str.Substring(count);
        }

        public static string cut(this string str, int count)
        {
            if (null == str)
                return null;
            if (str.Length <= count)
                return "";
            return str.Substring(0, str.Length - count);
        }

        public static byte[] utf8(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static string utf8(this byte[] data)
        {
            return Encoding.UTF8.GetString(data, 0, data.Length);
        }

        public static string utf8(this byte[] data, int offset, int count)
        {
            return Encoding.UTF8.GetString(data, offset, count);
        }

        public static string value(this string text, string begin, string end)
        {
            var bi = 0;
            if (null != begin)
            {
                bi = text.IndexOf(begin);
                if (bi < 0)
                    return null;
                bi += begin.Length;
            }
            var ei = text.IndexOf(end, bi);
            if (ei < 0)
                ei = text.Length;
            return text.Substring(bi, ei - bi);
        }

        public static string value(this string text, string begin, int count)
        {
            var bi = text.IndexOf(begin);
            if (bi < 0)
                return null;
            return text.Substring(bi + begin.Length, count);
        }

        public static int i32(this string text)
        {
            return int.Parse(text);
        }

        public static long i64(this string text)
        {
            return long.Parse(text);
        }
    }
}
