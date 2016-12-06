// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/12/2013 4:09:58 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.WinForm.Settings
{
    using CP.CoinSniffer.BitCoin;
    using CP.CoinSniffer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClientSettings : IMySettings
    {
        #region User Settings

        #region Main
        public bool LaunchOnLogin { get; set; }
        public bool StartOnLaunch { get; set; }
        public int Interval { get; set; }
        public int ThreadCount { get; set; }
        public BitCoinKeyType KeyType { get; set; }
        #endregion

        #region Display
        public bool OnlyShowExisting { get; set; }
        public int ListViewCapacityForNonExistAddresses { get; set; }
        #endregion

        #region Window
        public bool MinimizeToTray { get; set; }
        public bool MinimizeOnClose { get; set; }
        #endregion

        #region Notification
        public bool MailEnabled { get; set; }
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string MailUsername { get; set; }
        public string MailPasswordHash { get; set; }
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        #endregion

        #endregion

        #region Counter
        public long TotalScanned { get; set; }
        public long TotalFound { get; set; }
        public long TotalElapsedTicks { get; set; }
        #endregion

        #region MainForm
        public int MainFormWidth { get; set; }
        public int MainFormHeight { get; set; }
        #endregion

        public void Initialize()
        {
            this.Interval = 100;
            this.ThreadCount = 10;
            this.KeyType = BitCoinKeyType.Compressed;

            this.OnlyShowExisting = true;
            this.ListViewCapacityForNonExistAddresses = 10;

            this.MinimizeOnClose = false;

            this.MailEnabled = false;
            this.MailServer = "smtp.126.com";
            this.MailPort = 25;
            this.MailUsername = "coin_sniffer@126.com";
            this.MailPasswordHash = Utility.Encrypt("CoinSniffer");
            this.MailTo = "coin_sniffer@126.com";
            this.MailSubject = "Richer Man Now!";
            this.MailBody = "It's not a joke, but a dream!";
        }
    }
}
