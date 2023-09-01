using util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using util.ext;

namespace util.crypt
{
    public static class AesCtr
    {
        public static int ctrBlock(this int size)
            => (size / 16 + 1) * 16;

        public static byte[] ctrConv(this byte[] key, byte[] src, byte[] nonce, long counter)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;
                var enc = aes.CreateEncryptor();
                return ctrConv(enc, src, nonce, counter);
            }
        }

        public static byte[] ctrConv(this ICryptoTransform enc, byte[] src, byte[] nonce, long counter)
        {
            var chain = new byte[src.Length.ctrBlock()];
            chain.ctrSetNon(chain.Length, nonce);
            chain.ctrSetCtr(chain.Length, counter);

            var dst = new byte[chain.Length];
            enc.TransformBlock(chain, 0, chain.Length, dst, 0);

            dst.xor(0, src, 0, src.Length);

            return dst;
        }

        public static byte[] ctrSetNon(this byte[] chain, int size, byte[] nonce)
        {
            for (int i = 0; i < size; i += 16)
            {
                Buffer.BlockCopy(nonce, 0, chain, i, 8);
            }
            return chain;
        }

        public static void ctrSetCtr(this byte[] chain, int size, long counter)
        {
            for (int i = 8; i < size; i += 16)
            {
                Buffer.BlockCopy((counter++).bytes(), 0, chain, i, 8);
            }
        }

        //public static void ctrSetCtrDecr(this byte[] chain, long begin, int count)
        //{
        //    count = count * 16;
        //    for (int i = 8; i < count; i += 16)
        //    {
        //        Array.Copy((begin--).bytes(), 0, chain, i, 8);
        //    }
        //}

        //unsafe public static void ctrSetNonByPtr(this byte[] chain, long nonce)
        //{
        //    fixed (byte* P0 = chain)
        //    {
        //        long* ptr = (long*)P0;
        //        int count = chain.Length / 16;
        //        while (count-- > 0)
        //        {
        //            *ptr = nonce;
        //            ptr += 2;
        //        }
        //    }
        //}

        //unsafe public static void ctrSetCtrByPtr(this byte[] chain, long begin, int count)
        //{
        //    fixed (byte* P0 = chain)
        //    {
        //        long* ptr = (long*)(P0 + 8);
        //        while (count-- > 0)
        //        {
        //            *ptr = begin++;
        //            ptr += 2;
        //        }
        //    }
        //}

        //unsafe public static void ctrSetCtrByPtrBack(this byte[] chain, long begin, int count)
        //{
        //    fixed (byte* P0 = chain)
        //    {
        //        long* ptr = (long*)(P0 + 8);
        //        while (count-- > 0)
        //        {
        //            *ptr = begin--;
        //            ptr += 2;
        //        }
        //    }
        //}
    }
}
