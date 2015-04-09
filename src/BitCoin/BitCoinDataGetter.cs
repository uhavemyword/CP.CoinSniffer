// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/9/2013 11:24:03 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using CP.CoinSniffer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    public class BitCoinDataGetter : ICoinDataGetter
    {
        public decimal GetBalance(string address)
        {
            var webClient = new WebClient();
            var queryUrl = string.Format("http://blockexplorer.com/q/addressbalance/{0}", address);
            var s = webClient.DownloadString(queryUrl);
            decimal result;
            try
            {
                result = decimal.Parse(s);
            }
            catch (Exception)
            {
                throw new FormatException(string.Format("Invalid address {0}!", address));
            }
            return result;
        }

        /// <summary>
        /// Shows received BTC minus sent BTC for an address.
        /// </summary>
        /// <returns>DateTime of first seen</returns>
        public DateTime? GetFirstSeen(string address)
        {
            var webClient = new WebClient();
            var queryUrl = string.Format("http://blockexplorer.com/q/addressfirstseen/{0}", address);
            var s = webClient.DownloadString(queryUrl);
            if (s.Contains("invalid"))
            {
                throw new FormatException(string.Format("Invalid address {0}!", address));
            }
            DateTime? result = null;
            DateTime temp;
            DateTime.TryParse(s, out temp);
            if (temp != DateTime.MinValue)
            {
                result = temp;
            }
            return result;
        }
    }
}
