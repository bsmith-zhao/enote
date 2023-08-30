using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using util.ext;

namespace enote
{
    public class WriteVerify : Stream
    {
        public string error;
        public Stream data;

        byte[] buff;
        byte[] getBuff(int size)
            => buff?.Length >= size ? buff : buff = new byte[size];

        public bool NoError => error == null;

        public override void Write(byte[] src, int off, int cnt)
        {
            if (NoError)
            {
                var dst = getBuff(cnt);
                data.readExact(dst, 0, cnt, actual =>
                {
                    error = "data is short!!";
                });
                if (NoError && !src.isSame(dst, cnt))
                {
                    error = "data not same!!";
                }
            }
        }

        public override void Flush()
        {
            if (NoError && data.Position != data.Length)
                error = "data is long!!";
        }

        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => true;

        public override long Length => throw new NotImplementedException();
        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
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
