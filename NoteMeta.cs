namespace enote
{
    //public class NoteMeta
    //{
    //    public int ver = 1;
    //    public KeyGenEntry[] kgs;
    //    public KeyDeriveType kdf = KeyDeriveType.HKDF;
    //    public AeadCryptType crypt = AeadCryptType.ChaCha20Poly1305;
    //    public byte[] iv;
    //    public byte[] cipher;   // => SpecMeta
    //    public int pack = 64.kb();
    //    public ZipType zip = ZipType.GZip;
    //}

    //public class CipherMeta
    //{
    //    public byte[] mkey;
    //    public CryptEntry[] crypts;
    //}

    //public class CryptEntry
    //{
    //    public AeadCryptType type;
    //    public byte[] iv;
    //}

    //public class KeyGenEntry
    //{
    //    public KeyGenType type;
    //    public object args;

    //    public byte[] genKey(byte[] pwd, int size)
    //        => getKeyGen().genKey(pwd, size);

    //    KeyGen getKeyGen()
    //        => (args is KeyGen ? args : args = args.jcopy(getType()))
    //            as KeyGen;

    //    Type getType()
    //    {
    //        switch (type)
    //        {
    //            case KeyGenType.PBKDF2:
    //                return typeof(PBKDF2);
    //            case KeyGenType.Argon2id:
    //                return typeof(Argon2id);
    //        }
    //        return null;
    //    }
    //}
}
