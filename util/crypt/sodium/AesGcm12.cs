using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace util.crypt.sodium
{
    public class AesGcm12 : SodiumAeadCrypt
    {
        static AesGcm12() => Api.checkGcm();

        public override int KeySize => 32;
        public override int NonceSize => 12;
        public override int TagSize => 16;

        protected override unsafe EncryptFunc encFunc
            => Api.crypto_aead_aes256gcm_encrypt;

        protected override unsafe DecryptFunc decFunc
            => Api.crypto_aead_aes256gcm_decrypt;
    }
}
