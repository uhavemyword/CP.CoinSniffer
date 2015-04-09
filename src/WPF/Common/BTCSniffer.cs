
namespace CP.CoinSniffer.WPF.Common
{
    using CP.CoinSniffer.BitCoin;
    using CP.CoinSniffer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class BTCSniffer : BitCoinSniffer
    {
        public event EventHandler AfterStopped;

        public BTCSniffer(int interval, int threadCount)
            : base(interval, threadCount)
        { }

        public BTCSniffer()
            :this(300, 10)
        {
            
        }

        public new void Stop()
        {
            base.Stop();

            if (AfterStopped != null)
            {
                AfterStopped.Invoke(this, new EventArgs());
            }

        }
    }
}
