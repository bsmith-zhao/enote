using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class StreamEx
    {
        public static void write(this Stream fout, byte[] data)
        {
            fout.Write(data, 0, data.Length);
        }

        public static void readExact(this Stream fin, byte[] src, int off, int expect, Action<int> func)
        {
            var actual = fin.readFull(src, off, expect);
            if (actual != expect)
                func(actual);
        }

        public static byte[] readExact(this Stream fin, int expect, Action<int> func)
        {
            var data = fin.readFull(expect, out var actual);
            if (actual != expect)
                func(actual);
            return data;
        }

        public static byte[] readFull(this Stream fin, int expect, out int actual)
        {
            byte[] data = new byte[expect];
            actual = readFull(fin, data);
            return data;
        }

        public static int readFull(this Stream fin, byte[] data)
        {
            return readFull(fin, data, 0, data.Length);
        }

        public static int readFull(this Stream fin, byte[] data, int offset, int count)
        {
            int size = fin.Read(data, offset, count);
            while (size > 0 && size < count)
            {
                int len = fin.Read(data, offset + size, count - size);
                if (len <= 0)
                    break;
                size += len;
            }
            return size;
        }
    }
}
