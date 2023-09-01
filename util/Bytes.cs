using util;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace util
{
    public static class Bytes
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int memcmp(byte[] src, byte[] dst, int cnt);

        public static bool isSame(this byte[] src, byte[] dst, int cnt)
            => memcmp(src, dst, cnt) == 0;

        //public static void copyTo(this byte[] src, byte[] dst, int dstPos = 0)
        //{
        //    Array.Copy(src, 0, dst, dstPos, src.Length);
        //}

        //public static byte[] clone(this byte[] src)
        //{
        //    var dst = new byte[src.Length];
        //    src.CopyTo(dst, 0);
        //    return dst;
        //}

        //public static bool same(this byte[] src, byte[] dst, int size = -1)
        //{
        //    if (size <= 0)
        //        size = src.Length.min(dst.Length);
        //    //for (int i = 0; i < size; i++)
        //    //{
        //    //    if (src[i] != dst[i]) return false;
        //    //}
        //    //return true;
        //    return Bytes.memcmp(src, dst, size) == 0;
        //}

        //public unsafe static void xorByPtr(this byte[] data, int dataOffset, byte[] key, int keyOffset, int count)
        //{
        //    int div = count / 8;
        //    fixed (byte* D0 = data, K0 = key)
        //    {
        //        long* dptr = (long*)(D0 + dataOffset);
        //        long* kptr = (long*)(K0 + keyOffset);

        //        for (int i = 0; i < div; i++)
        //        {
        //            *(dptr + i) ^= *(kptr + i);
        //        }
        //    }

        //    dataOffset += div * 8;
        //    keyOffset += div * 8;
        //    count = count % 8;
        //    while (count > 0)
        //    {
        //        data[dataOffset++] ^= key[keyOffset++];
        //        count--;
        //    }
        //}

        public static void xor(this byte[] src, int srcOff, byte[] other, int otherOff, int count)
        {
            while (count > 0)
            {
                src[srcOff++] ^= other[otherOff++];
                count--;
            }
        }

        public static string b64(this byte[] data)
            => Convert.ToBase64String(data);

        public static string b64(this byte[] data, int off, int len)
            => Convert.ToBase64String(data, off, len);

        public static byte[] b64(this string code)
        {
            switch (code.Length % 4)
            {
                case 1:
                    return Convert.FromBase64String($"{code}===");
                case 2:
                    return Convert.FromBase64String($"{code}==");
                case 3:
                    return Convert.FromBase64String($"{code}=");
                default:
                    return Convert.FromBase64String(code);
            }
        }

        public static void hexLow(this List<byte[]> srcs, int cnt, char[] chars, int off)
            => hex(srcs, cnt, chars, off);

        public static void hex(this List<byte[]> srcs, int cnt, char[] chars, int ci)
        {
            int v, bi, len;
            foreach (var bytes in srcs)
            {
                len = Math.Min(bytes?.Length ?? 0, cnt);
                bi = 0;
                while (bi < len)
                {
                    v = bytes[bi] >> 4;
                    chars[ci++] = (char)(55 + v + (((v - 10) >> 31) & -7));
                    v = bytes[bi++] & 0xF;
                    chars[ci++] = (char)(55 + v + (((v - 10) >> 31) & -7));
                }
                cnt -= len;
                if (cnt <= 0)
                    break;
            }
        }

        public static string hex(this byte[] bytes)
        {
            char[] chars = new char[bytes.Length * 2];
            int v, ci = 0, bi = 0;
            while (bi < bytes.Length)
            {
                v = bytes[bi] >> 4;
                chars[ci++] = (char)(55 + v + (((v - 10) >> 31) & -7));
                v = bytes[bi++] & 0xF;
                chars[ci++] = (char)(55 + v + (((v - 10) >> 31) & -7));
            }
            return new string(chars);
        }

        public static byte[] hex(this string chars)
        {
            if (chars.Length % 2 == 1)
                throw new Exception("hex must be even!!");

            byte[] bytes = new byte[chars.Length / 2];
            int low, high, ci = 0, bi = 0;
            while (bi < bytes.Length)
            {
                low = chars[ci++];
                low = low - (low < 58 ? 48 : (low < 97 ? 55 : 87));
                high = chars[ci++];
                high = high - (high < 58 ? 48 : (high < 97 ? 55 : 87));
                bytes[bi++] = (byte)((low << 4) + high);
            }

            return bytes;
        }

        //public static byte[] HexToBytesX38(string hex)
        //{
        //    if (hex.Length % 2 == 1) throw new Exception("hex must be even!!");
        //    byte[] bytes = new byte[hex.Length >> 1];
        //    for (int i = 0; i < bytes.Length; i++)
        //    {
        //        bytes[i] = (byte)((GetHexValue(hex[i << 1]) << 4) + (GetHexValue(hex[(i << 1) + 1])));
        //    }
        //    return bytes;
        //}
        //public static int GetHexValue(int value)
        //{
        //    // int value = (int)hex;
        //    //For uppercase A-F letters:
        //    // return value - (value < 58 ? 48 : 55);
        //    //For lowercase a-f letters:
        //    //return val - (val < 58 ? 48 : 87);
        //    //Or the two combined, but a bit slower:
        //    return value - (value < 58 ? 48 : (value < 97 ? 55 : 87));
        //}
        //public static string BytesToHexX38(byte[] bytes)
        //{
        //    char[] cs = new char[bytes.Length * 2];
        //    int b;
        //    for (int i = 0; i < bytes.Length; i++)
        //    {
        //        b = bytes[i] >> 4;
        //        cs[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
        //        b = bytes[i] & 0xF;
        //        cs[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
        //    }
        //    return new string(cs);
        //}
    }
}
