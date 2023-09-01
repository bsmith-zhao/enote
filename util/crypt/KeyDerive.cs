using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.crypt
{
    public enum KeyDeriveType
    {
        HKDF
    }

    public abstract class KeyDerive
    {
        public abstract byte[] derive(byte[] mkey, byte[] ctx, int size);

        public static KeyDerive create(KeyDeriveType type)
        {
            switch (type)
            {
                case KeyDeriveType.HKDF:
                    return new HkdfDerive();
            }
            return null;
        }
    }

    public class HkdfDerive : KeyDerive
    {
        public override byte[] derive(byte[] mkey, byte[] ctx, int size)
            => mkey.hkdfDerive(null, ctx, size);
    }
}
