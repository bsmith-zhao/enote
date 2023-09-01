using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using util.ext;

namespace util.crypt
{
    public class CryptStream : Stream
    {
        public Stream fs;
        public PackCrypt[] algs;
        public int block = 64.kb();

        public Stream init()
        {
            return new BufferedStream(this, block);
        }

        int? ps;
        int packSize => (int)(ps ?? (ps = getPackSize()));
        int getPackSize()
        {
            int size = block;
            algs.each(c => size = c.inflate(size));
            return size;
        }

        byte[] sb;
        byte[] getSrcBuff() => 
            sb ?? (sb = new byte[packSize]);

        byte[] db;
        byte[] getDstBuff() => 
            db ?? (db = new byte[packSize]);

        public override int Read(byte[] buff, int off, int cnt)
        {
            var src = getSrcBuff();

            int len = fs.readFull(src, 0, packSize);
            if (len <= 0)
                return 0;

            var dst = getDstBuff();
            // decrypt
            for (int i = algs.Length - 1; i >= 0; i--)
            {
                len = algs[i].decrypt(src, len, dst);
                src.swap(ref src, ref dst);
            }

            Buffer.BlockCopy(src, 0, buff, off, len);
            return len;
        }

        public override void Write(byte[] buff, int off, int cnt)
        {
            var src = getSrcBuff();
            var dst = getDstBuff();

            int len = algs[0].encrypt(buff, cnt, src);
            for (int i = 1; i < algs.Length; i++)
            {
                len = algs[i].encrypt(src, len, dst);
                src.swap(ref src, ref dst);
            }

            fs.Write(src, 0, len);
        }

        public override void Flush()
        {
            fs.Flush();
        }

        public override bool CanRead => true;
        public override bool CanWrite => true;
        public override bool CanSeek => throw new NotImplementedException();
        public override long Length => throw new NotImplementedException();
        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
    }
}
