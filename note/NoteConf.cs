using System.ComponentModel;
using util;
using util.crypt;
using util.crypt.conf;
using util.prop;
using static util.Number;

namespace enote
{
    public class NoteConf
    {
        KeyGenType[] kgs = new KeyGenType[]
        {
            KeyGenType.PBKDF2,
            KeyGenType.Argon2id,
        };
        [TypeConverter(typeof(ArrayFormat<KeyGenType>))]
        public KeyGenType[] KeyGens
        {
            get => kgs;
            set
            {
                if (value?.Length > 0)
                    kgs = value;
                else
                    kgs = new KeyGenType[] 
                    { KeyGenType.Argon2id };
            }
        }

        public KeyDeriveType KeyDerive { get; set; }
            = KeyDeriveType.HKDF;

        [TypeConverter(typeof(ExpandClass))]
        public PBKDF2Conf PBKDF2 { get; set; }
            = new PBKDF2Conf();

        [TypeConverter(typeof(ExpandClass))]
        public Argon2idConf Argon2id { get; set; }
            = new Argon2idConf();

        public SymmeCryptType SpecCrypt { get; set; } 
            = SymmeCryptType.XChaCha20Poly1305;

        SymmeCryptType[] encs = new SymmeCryptType[]
        {
            SymmeCryptType.CbcPkcs7,
            SymmeCryptType.XChaCha20Poly1305,
        };
        [TypeConverter(typeof(ArrayFormat<SymmeCryptType>))]
        public SymmeCryptType[] DataCrypts
        {
            get => encs;
            set
            {
                if (value?.Length > 0)
                    encs = value;
                else
                    encs = new SymmeCryptType[] 
                    { SymmeCryptType.XChaCha20Poly1305 };
            }
        }

        [RangeLimit("64K", "2M"), EditByWheel(16 * KB), ByteSize]
        public string BlockSize { get; set; } = "256K";
        public int blockSize() => (int)BlockSize.byteSize();

        public ZipType Compress { get; set; } = ZipType.GZip;

        public KeyGen newKeyGen(KeyGenType type)
        {
            switch (type)
            {
                case KeyGenType.PBKDF2:
                    return PBKDF2.create();
                case KeyGenType.Argon2id:
                    return Argon2id.create();
            }
            return null;
        }
    }
}
