// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/15/2013 12:03:23 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.WinForm
{
    using CP.CoinSniffer.BitCoin;
    using CP.CoinSniffer.Common;
    using CP.CoinSniffer.WinForm.Settings;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;

    public static class ClientHelper
    {
        private static string _dataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "data.txt");

        public static string DataPath
        {
            get { return _dataPath; }
        }

        public static void SendMailForAddresses(List<BitCoinAddress> addresses)
        {
            if (addresses == null || addresses.Count == 0)
            {
                return;
            }
            var config = MySettingsManager.GetSettings<ClientSettings>();
            var mailContent = new StringBuilder();
            mailContent.Append(config.MailBody).Append(Environment.NewLine)
                                .Append("Find coin:").Append(Environment.NewLine)
                                .Append("(Balance,PublicKey,PrivateKey,FirstSeen)").Append(Environment.NewLine);
            addresses.ForEach(x => mailContent.Append(x.ToString()).Append(Environment.NewLine));
            Utility.SendEMail(config.MailServer, config.MailPort, config.MailUsername, Utility.Decrypt(config.MailPasswordHash), config.MailUsername, config.MailTo, config.MailSubject, mailContent.ToString());
        }

        public static List<BitCoinAddress> RestoreAddresses(bool refreshData = false)
        {
            var addresses = new List<BitCoinAddress>();

            string text;
            using (var file = new FileStream(DataPath, FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(file))
                {
                    text = sr.ReadToEnd();
                }
            }
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                string[] fields = line.Split(new char[] { ',' });
                if (fields.Count() < 4)
                {
                    continue;
                }

                string privateKey = fields[2].Trim();
                decimal balance;
                decimal.TryParse(fields[0], out balance);
                DateTime? firstSeen = null;
                DateTime temp;
                DateTime.TryParse(fields[3], out temp);
                if (temp != DateTime.MinValue)
                {
                    firstSeen = temp;
                }

                // TODO: use new thread to construct if too many lines
                var address = ConstructBitCoinAddress(privateKey, balance, firstSeen, refreshData);

                if (refreshData && !(address.Balance > 0 || address.FirstSeen.HasValue))
                {
                    continue;
                }

                addresses.Add(address);
            }
            if (File.Exists(DataPath))
            {
                File.Delete(DataPath);
            }
            return addresses;
        }

        public static void RememberAddresses(List<BitCoinAddress> addresses)
        {
            var previousAddresses = RestoreAddresses(false);
            var all = addresses.Union(previousAddresses).Distinct(new BitCoinAddressComparer()).ToList();
            var sb = new StringBuilder();
            all.ForEach(x => sb.Append(x.ToString()).Append(Environment.NewLine));
            using (var file = new FileStream(DataPath, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(file))
                {
                    sw.Flush();
                    sw.Write(sb.ToString());
                }
            }
        }

        public static BitCoinAddress ConstructBitCoinAddress(string privateKey, decimal balance, DateTime? firstSeen, bool refreshData)
        {
            BitCoinAddress address = null;
            try
            {
                address = new BitCoinAddress(privateKey);
                address.Balance = balance;
                address.FirstSeen = firstSeen;
            }
            catch (Exception)
            {
                // Invalid privatekey
                return null;
            }

            if (refreshData)
            {
                try
                {
                    BitCoinSniffer.RefreshData(address);
                }
                catch (Exception)
                {
                    // Do nothing
                }
            }

            return address;
        }
    }
}
