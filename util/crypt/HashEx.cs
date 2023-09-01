using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace util.crypt
{
    public static class HashEx
    {
        public static bool verify(this HMAC mac, byte[] src, byte[] tag)
            => verify(mac, src, 0, src.Length, tag);

        public static bool verify(this HMAC mac, byte[] src, int off, int cnt, byte[] tag)
        {
            var vf = mac.ComputeHash(src, off, cnt);
            return vf.b64() == tag.b64();
        }

        public static int tagSize(this HMAC hmac)
            => (hmac?.HashSize ?? 0) / 8;

        public static byte[] saltPBKDF2(this byte[] pwd, byte[] salt, int turns, int size)
        {
            using (var hash = new Rfc2898DeriveBytes(pwd, salt, turns))
            {
                return hash.GetBytes(size);
            }
        }

        public static byte[] sha256(this byte[] data)
        {
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(data);
            }
        }
    }
}
