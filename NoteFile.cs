using System;
using System.IO;
using System.IO.Compression;
using util;
using util.crypt;
using util.crypt.conf;
using util.ext;

namespace enote
{
    public class NoteFile
    {
        public const string Mark = "$enote%";
        public const int Version = 1;

        public NoteConf conf;
        public int block => meta.block;

        Meta meta;
        public class Meta
        {
            public int ver = NoteFile.Version + 1;
            public KeyGenEntry[] kgs;
            public KeyDeriveType kdf = KeyDeriveType.HKDF;
            public int block = 64.kb();
            public ZipType zip = ZipType.GZip;
            public CryptEntry crypt;
            public byte[] cipher;
        }

        byte[] pw;
        public byte[] pwd
        {
            get => pw;
            set
            {
                pw = value;
                pk = null;
            }
        }

        byte[] pk;
        byte[] pkey => pk ?? (pk = genPKey(pw));
        byte[] genPKey(byte[] p)
        {
            meta.kgs.each(kg => p = kg.genKey(p, meta.crypt.keySize()));
            return p;
        }

        KeyDerive kdf;
        byte[] getKey(string info, int size)
        => (kdf ?? (kdf = KeyDerive.create(meta.kdf)))
            .derive(pkey, info.utf8(), size);

        byte[] specKey() => getKey("spec-key", meta.crypt.keySize());
        byte[] dataKey(int idx)
            => getKey($"data-keys[{idx}]", dataEncs[idx].keySize());

        PackCrypt specCrypt() => meta.crypt.getCrypt(specKey());

        PackCrypt[] dataCrypts()
            => dataEncs.conv((i, ce)
                => ce.getCrypt(dataKey(i)));

        public NoteFile open(Stream fin)
        {
            byte[] mark = new byte[Mark.Length];
            if (fin.readFull(mark) != mark.Length
                || mark.utf8() != Mark)
                throw new Exception("invalid file type!");

            var rd = new StreamReader(fin);
            var json = rd.ReadLine();
            meta = json.obj<Meta>();

            if (meta.ver > Version)
                throw new Exception($"not support version [{meta.ver}]");

            fin.Position = Mark.Length + json.Length + 2;

            return this;
        }

        public void verify(byte[] pwd)
        {
            this.pwd = pwd;
            dataEncs = specCrypt().decrypt(meta.cipher, out var len)
                .utf8(0, len).obj<CryptEntry[]>();
        }

        public Stream read(Stream fin)
        {
            var rs = new CryptStream
            {
                block = meta.block,
                fs = fin,
                algs = dataCrypts(),
            }.init();
            return ZipEntry.unzip(rs, meta.zip);
        }

        CryptEntry[] dataEncs;
        public Stream create(Stream fout)
        {
            meta = new Meta
            {
                ver = Version,
                kgs = conf.KeyGens.conv(tp => new KeyGenEntry
                {
                    type = tp,
                    args = conf.newKeyGen(tp)
                }),
                kdf = conf.KeyDerive,
                crypt = new CryptEntry { type = conf.SpecCrypt }
                        .create(),
                block = conf.blockSize(),
                zip = conf.Compress,
            };
            dataEncs = conf.DataCrypts.conv(tp =>
                    new CryptEntry { type = tp }.create());
            meta.cipher = specCrypt().encrypt(dataEncs.json().utf8());

            fout.write(Mark.utf8());
            fout.write($"{meta.json()}\r\n".utf8());

            var ws = new CryptStream
            {
                block = meta.block,
                fs = fout,
                algs = dataCrypts(),
            }.init();
            return ZipEntry.zip(ws, meta.zip);
        }
    }

    public class CryptEntry
    {
        public SymmeCryptType type;
        public byte[] iv;

        public int keySize() => crypt.KeySize;

        public CryptEntry create()
        {
            iv = crypt.IvSize.aesRnd();
            return this;
        }

        public PackCrypt getCrypt(byte[] key)
        {
            crypt.Key = key;
            crypt.IV = iv;
            return crypt;
        }

        PackCrypt pc;
        PackCrypt crypt => pc ?? 
            (pc = new PackCrypt(SymmeCrypt.create(type)));
    }

    public enum ZipType
    {
        None, GZip
    }

    public class ZipEntry
    {
        public static Stream unzip(Stream fin, ZipType type)
        {
            if (type == ZipType.None)
                return fin;
            return new GZipStream(fin, CompressionMode.Decompress);
        }

        public static Stream zip(Stream fout, ZipType type)
        {
            if (type == ZipType.None)
                return fout;
            return new GZipStream(fout, CompressionLevel.Fastest);
        }
    }
}
