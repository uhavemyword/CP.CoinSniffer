// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/9/2013 2:57:11 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.WinForm
{
    using CP.CoinSniffer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProxySetting : ISettings
    {
        public bool Enabled { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public void Initialize()
        {
            this.Enabled = false;
            this.Address = string.Empty;
            this.Username = string.Empty;
            this.PasswordHash = string.Empty;
        }
    }
}
