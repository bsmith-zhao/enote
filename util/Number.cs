using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util
{
    public static class Number
    {
        public const long KB = 1024;
        public const long MB = KB * KB;
        public const long GB = MB * KB;
        public const long TB = GB * KB;

        public static string[] ByteUnits = { "", "K", "M", "G", "T" };
        public static string byteSize(this long size)
        {
            if (size <= KB)
                return $"{size}{ByteUnits[0]}";

            int ui = 0;
            double num = size * 1.0;
            while (num > 1000 && ui < ByteUnits.Length - 1)
            {
                num = num / KB;
                ui++;
            }
            return num.ToString("0.##") + ByteUnits[ui];
        }

        public static bool isByteSize(this string str, out long unit)
        {
            unit = 1;
            switch (char.ToUpper(str[str.Length - 1]))
            {
                case 'K': unit = KB; break;
                case 'M': unit = MB; break;
                case 'G': unit = GB; break;
                case 'T': unit = TB; break;
            }
            return unit > 1;
        }

        public static long byteSize(this string str)
        {
            str = str?.Trim();
            if (str == null || str.Length == 0)
                return 0;

            if (isByteSize(str, out var unit))
                str = str.Substring(0, str.Length - 1).Trim();

            if (double.TryParse(str, out var size))
                return (long)(size * unit);

            return 0;
        }

        public static double num(this string str)
        {
            if (double.TryParse(str, out var value))
                return value;
            else if (str.isByteSize(out var unit))
                return str.byteSize();
            return 0;
        }

        //public static string GSize(string v)
        //{
        //    v = v?.Trim().ToUpper();
        //    if (null == v || v.Length == 0) return null;
        //    if (v[v.Length - 1] == 'G') v = v.Substring(0, v.Length - 1);
        //    try
        //    {
        //        return decimal.Parse(v) + "G";
        //    }
        //    catch { return null; }
        //}

        //public static string percentText(this int value)
        //{
        //    return (value > 0) ? $"{value}%" : "NA%";
        //}

        //public static int percent(this long value, long total)
        //{
        //    return total <= 0 ? 0 : (int)(value * 100 / total);
        //}

        public static T min<T>(this T a, T b) where T : IComparable
        {
            if (a.CompareTo(b) <= 0)
            {
                return a;
            }
            return b;
        }

        public static T max<T>(this T a, T b) where T : IComparable
        {
            if (a.CompareTo(b) >= 0)
            {
                return a;
            }
            return b;
        }

        public static T limit<T>(this T value, T min, T max) where T : IComparable
        {
            if (value.CompareTo(min) < 0)
                return min;
            if (value.CompareTo(max) > 0)
                return max;
            return value;
        }

        //public static bool @in<T>(this T value, T min, T max) 
        //    where T : IComparable
        //    => value.CompareTo(min) >= 0
        //    && value.CompareTo(max) <= 0;

        public static byte[] bytes(this long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static long i64(this byte[] data, int offset = 0)
        {
            return BitConverter.ToInt64(data, offset);
        }

        public static byte[] bytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static long i64(this int value)
            => value;

        public static int i32(this int value)
            => value;

        public static int i32(this float value)
            => (int)value;

        public static int i32(this double value)
            => (int)value;

        public static int i32(this long value)
            => (int)value;

        public static int i32(this byte[] data, int offset = 0)
        {
            return BitConverter.ToInt32(data, offset);
        }

        public static int i32(this string text, int @base = 10)
            => Convert.ToInt32(text, @base);

        public static int i32h(this string text)
            => Convert.ToInt32(text, 16);

        public static string hex(this int value)
            => Convert.ToString(value, 16);

        public static string hex(this int value, int len)
            => value.ToString($"X{len}");

        public static int abs(this int value)
            => Math.Abs(value);

        public static int kb(this int value)
            => value * 1024;

        public static int mb(this int value)
            => value * 1024 * 1024;

        // int - hex convert
        //string h;
        //int v;
        //(h=123.hex(5)).debug();
        //(v=h.i32h()).debug();

        //h = "FFFFFF";
        //    (v = h.i32h()).debug();

        //v = 0x000F5;
        //    (h = v.hex(7)).debug();
    }
}
