﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util.crypt;
using util.prop;

namespace util.crypt.conf
{
    public class PBKDF2Conf
    {
        public int SaltSize = 32;
        [RangeLimit(20000, 100000), EditByWheel(5000)]
        public int Turns { get; set; } = 30000;

        public override string ToString()
            => $"Turns:{Turns}";

        public KeyGen create()
            => new PBKDF2
            {
                salt = SaltSize.aesRnd(),
                turns = new Random().Next((int)(Turns * 0.9), (int)(Turns * 1.1)),
            };
    }
}
