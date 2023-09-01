using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace util.crypt.sodium
{
    public class ChaCha20Poly1305 : SodiumAeadCrypt
    {
        public override int KeySize => 32;
        public override int NonceSize => 12;
        public override int TagSize => 16;

        protected override unsafe EncryptFunc encFunc
            => Api.crypto_aead_chacha20poly1305_ietf_encrypt;

        protected override unsafe DecryptFunc decFunc
            => Api.crypto_aead_chacha20poly1305_ietf_decrypt;
    }
}
