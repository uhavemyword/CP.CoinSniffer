// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/16/2013 4:51:14 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BitCoinAddressComparer : IEqualityComparer<BitCoinAddress>
    {
        public bool Equals(BitCoinAddress x, BitCoinAddress y)
        {
            return string.Equals(x.PublicKey.Value, y.PublicKey.Value, StringComparison.Ordinal);
        }

        public int GetHashCode(BitCoinAddress obj)
        {
            return obj.PublicKey.Value.GetHashCode();
        }
    }
}
