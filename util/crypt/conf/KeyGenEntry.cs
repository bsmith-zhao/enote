using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using util.crypt;
using util.crypt.sodium;

namespace util.crypt.conf
{
    public class KeyGenEntry
    {
        public KeyGenType type;
        public object args;

        public byte[] genKey(byte[] pwd, int size)
            => getKeyGen().genKey(pwd, size);

        KeyGen getKeyGen()
            => (args is KeyGen ? args
            : args = args.jcopy(getType()))
                as KeyGen;

        Type getType()
        {
            switch (type)
            {
                case KeyGenType.PBKDF2:
                    return typeof(PBKDF2);
                case KeyGenType.Argon2id:
                    return typeof(Argon2id);
            }
            return null;
        }
    }
}
