using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using util.crypt;
using util.ext;

namespace util.crypt
{
    public class CbcPkcs7 : SymmeCrypt
    {
        public override int KeySize => 32;
        public override int IvSize => 16;

        public override byte[] Key { get; set; }

        public override bool decrypt(
            byte[] src, int srcOff, int srcLen, 
            ref byte[] iv, byte[] ad, 
            byte[] dst, int dstOff, out int dstLen)
        {
            dstLen = 0;
            if (srcLen % 16 != 0)
                return false;
            try
            {
                using (var aes = Key.aesInit(CipherMode.CBC, PaddingMode.PKCS7, iv))
                {
                    var dec = aes.CreateDecryptor();
                    int bodyLen = dec.TransformBlock(
                        src, srcOff, srcLen,
                        dst, dstOff);
                    var tail = dec.TransformFinalBlock(src, 0, 0);
                    if (tail.Length > 0)
                        tail.CopyTo(dst, dstOff + bodyLen);
                    iv = src.sub(srcOff + srcLen - 16, 16);
                    dstLen = bodyLen + tail.Length;
                }
                return true;
            }
            catch (CryptographicException)
            {
                return false;
            }
        }

        public override int encrypt(
            byte[] src, int srcOff, int srcLen, 
            ref byte[] iv, byte[] ad, 
            byte[] dst, int dstOff)
        {
            using (var aes = Key.aesInit(CipherMode.CBC, PaddingMode.PKCS7, iv))
            {
                var enc = aes.CreateEncryptor();
                int tailLen = srcLen % 16;
                int bodyLen = srcLen - tailLen;
                if (bodyLen > 0)
                    enc.TransformBlock(src, srcOff, bodyLen, dst, dstOff);
                var last = enc.TransformFinalBlock(src, srcOff + bodyLen, tailLen);
                last.CopyTo(dst, dstOff + bodyLen);
                iv = last;
                return bodyLen + last.Length;
            }
        }

        public override int inflate(int dataSize)
            => (dataSize / 16 + 1) * 16;

        //    public override int encrypt(byte[] src, int cnt, byte[] dst)
        //    {
        //        using (var aes = key.aesInit(CipherMode.CBC, pad, iv))
        //        {
        //            var enc = aes.CreateEncryptor();
        //            int tail = cnt % 16;
        //            int body = cnt - tail;
        //            if (body > 0)
        //                enc.TransformBlock(src, 0, body, dst, 0);
        //            iv = enc.TransformFinalBlock(src, body, tail);
        //            Buffer.BlockCopy(iv, 0, dst, body, iv.Length);
        //            return body + iv.Length;
        //        }
        //    }

        //    public override int decrypt(byte[] src, int cnt, byte[] dst)
        //    {
        //        using (var aes = key.aesInit(CipherMode.CBC, pad, iv))
        //        {
        //            var dec = aes.CreateDecryptor();
        //            int len = dec.TransformBlock(src, 0, cnt, dst, 0);
        //            var tail = dec.TransformFinalBlock(src, 0, 0);
        //            if (tail.Length > 0)
        //                tail.CopyTo(dst, len);
        //            iv = src.sub(cnt - 16, 16);
        //            return len + tail.Length;
        //        }
        //    }
        //}
    }
}
