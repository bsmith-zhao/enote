using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using util.ext;

namespace util.crypt
{
    public class PackCrypt
    {
        SymmeCrypt alg;
        public PackCrypt(SymmeCrypt alg)
            => this.alg = alg;

        public int IvSize => alg.IvSize;
        public int KeySize => alg.KeySize;
        public byte[] Key
        {
            get => alg.Key;
            set => alg.Key = value;
        }

        public long Index = 0;
        byte[] iv;
        public byte[] IV
        {
            set
            {
                iv = value;
                NextIv = new byte[iv.Length];
                iv.CopyTo(NextIv, 0);
                NextIdx = Index;
            }
        }

        public byte[] NextIv;
        public long NextIdx;

        public int inflate(int dataSize)
            => alg.inflate(dataSize);

        public int decrypt(
            byte[] src, int srcLen,
            byte[] dst)
        {
            if (!alg.decrypt(src, 0, srcLen,
                ref NextIv, (NextIdx++).bytes(), 
                dst, 0, out var dstLen))
                throw new Exception("decrypt verify fail!!");
            return dstLen;
        }

        public int encrypt(
            byte[] src, int srcLen,
            byte[] dst)
            => alg.encrypt(src, 0, srcLen,
                ref NextIv, (NextIdx++).bytes(), 
                dst, 0);

        public byte[] encrypt(byte[] src)
        {
            byte[] dst = new byte[alg.inflate(src.Length)];
            encrypt(src, src.Length, dst);
            return dst;
        }

        public byte[] decrypt(byte[] src, out int len)
        {
            byte[] dst = new byte[src.Length];
            len = decrypt(src, src.Length, dst);
            return dst;
        }
    }
}
