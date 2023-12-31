﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using util.crypt;
using util.crypt.sodium;
using util.prop;

namespace util.crypt.conf
{
    public class Argon2idConf
    {
        [RangeLimit(2, 1024), EditByWheel(1)]
        public int CPU { get; set; } = 32;
        [RangeLimit("32M", "512M"), EditByWheel("16M"), ByteSize]
        public string Memory { get; set; } = "64M";

        public override string ToString()
            => $"CPU:{CPU}, Memory:{Memory}";

        public KeyGen create()
            => new Argon2id
            {
                salt = Argon2id.SaltSize.aesRnd(),
                cpu = CPU,
                mem = (int)Memory.byteSize(),
            };
    }
}
