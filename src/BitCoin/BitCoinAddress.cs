// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/8/2013 2:50:34 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using CP.CoinSniffer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    /// <summary>
    /// See https://en.bitcoin.it/wiki/Address
    /// </summary>
    public class BitCoinAddress
    {
        public BitCoinAddress(bool isCompressed = true)
        {
            var ecKeyPair = new ECKeyPair();
            this.PrivateKey = new BitCoinPrivateKey(ecKeyPair.PrivateKey, isCompressed);

            // TODO: Addresses can be created that require a combination of multiple private keys
        }

        public BitCoinAddress(string privateKey)
        {
            this.PrivateKey = new BitCoinPrivateKey(privateKey);
        }

        public BitCoinPrivateKey PrivateKey { get; private set; }

        public BitCoinPublicKey PublicKey
        {
            get
            {
                return this.PrivateKey.PublicKey;
            }
        }

        public decimal Balance { get; set; }

        public DateTime? FirstSeen { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Balance, PublicKey, PrivateKey, FirstSeen);
        }
    }
}
