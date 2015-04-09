// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/10/2013 1:23:55 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using CP.CoinSniffer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class BitCoinSniffer
    {
        private List<Thread> _threads = new List<Thread>();

        private Random _random = new Random();

        public BitCoinSniffer(int interval = 100, int threadCount = 10, BitCoinKeyType keyType = BitCoinKeyType.Compressed)
        {
            Interval = interval;
            ThreadCount = threadCount;
            KeyType = keyType;
        }

        /// <summary>
        /// Interval in milliseconds
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Thread count. Need to restart Sniffer to take effect.
        /// </summary>
        public int ThreadCount { get; set; }

        public BitCoinKeyType KeyType { get; set; }

        public bool Started { get; private set; }

        public static void RefreshData(BitCoinAddress address)
        {
            ICoinDataGetter coinDataGetter = new BitCoinDataGetter();

            address.FirstSeen = coinDataGetter.GetFirstSeen(address.PublicKey.Value);

            if (address.FirstSeen.HasValue)
            {
                address.Balance = coinDataGetter.GetBalance(address.PublicKey.Value);
            }
            else
            {
                address.Balance = 0;
            }
        }

        public delegate void SniffedEventHandler(BitCoinAddress address);

        public delegate void ErrorCaughtEventHandler(Exception ex);

        public event SniffedEventHandler Sniffed;

        public event ErrorCaughtEventHandler ErrorCaught;

        public void Start()
        {
            if (!Started)
            {
                Started = true;
                for (int i = 0; i < ThreadCount; i++)
                {
                    var t = new Thread(new ThreadStart(Run));
                    t.IsBackground = true;
                    _threads.Add(t);
                    t.Start();
                }
            }
        }

        public void Change(int interval, int threadCount, BitCoinKeyType keyType)
        {
            this.Stop();
            this.Interval = interval;
            this.ThreadCount = threadCount;
            this.KeyType = keyType;
            this.Start();
        }

        public void Stop()
        {
            if (Started)
            {
                this.Started = false;
                System.Threading.Thread.Sleep(100); // wait some time for starting thread
                this._threads.ForEach(t => t.Abort());
                this._threads.ForEach(t => t.Join());
                this._threads.Clear();
            }
        }

        private void OnSniffed(BitCoinAddress address)
        {
            var handler = this.Sniffed;
            if (handler != null)
            {
                handler(address);
            }
        }

        private void OnErrorCaught(Exception ex)
        {
            var handler = this.ErrorCaught;
            if (handler != null)
            {
                handler(ex);
            }
        }

        private void Run()
        {
            while (this.Started)
            {
                try
                {
                    bool keyCompressed;
                    if (this.KeyType == BitCoinKeyType.Unspecified)
                    {
                        keyCompressed = _random.Next(2) == 0;
                    }
                    else
                    {
                        keyCompressed = this.KeyType == BitCoinKeyType.Compressed;
                    }

                    var address = new BitCoinAddress(keyCompressed);
                    RefreshData(address);
                    OnSniffed(address);
                    System.Threading.Thread.Sleep(this.Interval);
                }
                catch (ThreadAbortException)
                {
                    // ThreadAbortException is a special exception that can be caught by application code, 
                    // but is rethrown at the end of the catch block unless ResetAbort is called. 
                    // ResetAbort cancels the request to abort, and prevents the ThreadAbortException from terminating the thread.
                    Thread.ResetAbort();
                }
                catch (Exception ex)
                {
                    OnErrorCaught(ex);
                    System.Threading.Thread.Sleep(this.Interval);
                }
            }
        }
    }
}
