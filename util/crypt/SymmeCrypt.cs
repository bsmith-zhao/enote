using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util.crypt;
using util.ext;

namespace util.crypt
{
    public enum SymmeCryptType
    {
        CbcPkcs7,
        AesGcm12,
        ChaCha20Poly1305,
        XChaCha20Poly1305
    }

    public abstract class SymmeCrypt
    {
        public abstract int KeySize { get; }
        public abstract int IvSize { get; }
        public abstract byte[] Key { get; set; }

        public static SymmeCrypt create(SymmeCryptType type)
        {
            switch (type)
            {
                case SymmeCryptType.CbcPkcs7:
                    return new CbcPkcs7();
                case SymmeCryptType.AesGcm12:
                    return create(AeadCryptType.AesGcm12);
                case SymmeCryptType.ChaCha20Poly1305:
                    return create(AeadCryptType.ChaCha20Poly1305);
                case SymmeCryptType.XChaCha20Poly1305:
                    return create(AeadCryptType.XChaCha20Poly1305);
            }
            return null;
        }

        static AeadSymmeCrypt create(AeadCryptType type)
            => new AeadSymmeCrypt { ae = AeadCrypt.create(type) };

        public abstract int inflate(int dataSize);

        public abstract int encrypt(
            byte[] src, int srcOff, int srcLen,
            ref byte[] iv, byte[] ad,
            byte[] dst, int dstOff);

        public abstract bool decrypt(
            byte[] src, int srcOff, int srcLen,
            ref byte[] iv, byte[] ad,
            byte[] dst, int dstOff, out int dstLen);
    }
}
