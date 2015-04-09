// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/9/2013 11:20:33 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ICoinDataGetter
    {
        /// <summary>
        /// Shows balance for an address.
        /// </summary>
        /// <param name="address">coin address</param>
        /// <returns>balance</returns>
        decimal GetBalance(string address);

        /// <summary>
        /// Gets the time at which an address was first seen on the network.
        /// </summary>
        /// <param name="address">coin address</param>
        /// <returns>null if never seen, else the datetime first seen</returns>
        DateTime? GetFirstSeen(string address);
    }
}
