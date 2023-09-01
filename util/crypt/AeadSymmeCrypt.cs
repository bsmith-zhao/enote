using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using util.crypt;

namespace util.crypt
{
    public class AeadSymmeCrypt : SymmeCrypt
    {
        public AeadCrypt ae;

        public override int KeySize => ae.KeySize;
        public override int IvSize => ae.NonceSize;

        public override byte[] Key
        {
            get => ae.Key;
            set => ae.Key = value;
        }

        public override int encrypt(
            byte[] src, int srcOff, int srcLen,
            ref byte[] iv, byte[] ad,
            byte[] dst, int dstOff)
        {
            ae.encrypt(src, srcOff, srcLen, 
                iv,
                dst, dstOff, 
                ad);
            forward(iv);
            return srcLen + ae.TagSize;
        }

        public override bool decrypt(
            byte[] src, int srcOff, int srcLen,
            ref byte[] iv, byte[] ad,
            byte[] dst, int dstOff, out int dstLen)
        {
            dstLen = srcLen - ae.TagSize;
            if (!ae.decrypt(src, srcOff, srcLen,
                iv, 
                dst, dstOff,
                ad))
                return false;
            forward(iv);
            return true;
        }

        void forward(byte[] iv)
        {
            (iv.i64(iv.Length - 8)+1).bytes()
                .CopyTo(iv, iv.Length - 8);
        }

        public override int inflate(int dataSize)
            => dataSize + ae.TagSize;
    }
}
