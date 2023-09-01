using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using util.ext;

namespace util.crypt
{
    public static class WinProtect
    {
        public static byte[] winTryDec(this byte[] cipher, byte[] entropy = null)
        {
            try
            {
                if (null != cipher)
                    return cipher.winDec(entropy);
            }
            catch { }
            return null;
        }

        public static byte[] winEnc(this byte[] data, byte[] entropy = null)
        {
            return ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser);
        }

        public static byte[] winDec(this byte[] cipher, byte[] entropy = null)
        {
            return ProtectedData.Unprotect(cipher, entropy, DataProtectionScope.CurrentUser);
        }
    }
}
