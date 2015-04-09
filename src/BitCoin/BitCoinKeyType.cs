// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/16/2013 4:02:14 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Flags]
    public enum BitCoinKeyType
    {
        Unspecified = 0,
        Compressed = 1,
        Uncompresssed = 1 << 1
    }
}
