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
        private List<Task> _tasks;
        private CancellationTokenSource _tokenSource;

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

            //if (address.FirstSeen.HasValue)
            //{
            address.Balance = coinDataGetter.GetBalance(address.PublicKey.Value);
            //}
            //else
            //{
            //    address.Balance = 0;
            //}
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
                _tasks = new List<Task>();
                _tokenSource = new CancellationTokenSource();
                for (int i = 0; i < ThreadCount; i++)
                {
                    var task = new Task(() => Run(_tokenSource.Token), _tokenSource.Token, TaskCreationOptions.LongRunning);
                    _tasks.Add(task);
                    task.Start();
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
                try
                {
                    _tokenSource.Cancel();
                    Task.WaitAll(_tasks.ToArray(), 1000, _tokenSource.Token);
                    _tasks.Clear();
                }
                catch (OperationCanceledException)
                {
                    // do nothing, this is expected if a task is canceled in running state.
                }
                catch (AggregateException ex)
                {
                    ex.Handle(x => x is OperationCanceledException);
                }
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

        private void Run(CancellationToken token)
        {
            while (this.Started)
            {
                token.ThrowIfCancellationRequested();
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
                    Sleep();
                }
                catch (Exception ex)
                {
                    OnErrorCaught(ex);
                    Sleep();
                }
            }
        }

        private void Sleep()
        {
            int timeSlice = 200;
            if (this.Interval < timeSlice)
            {
                System.Threading.Thread.Sleep(this.Interval);
            }
            else
            {
                for (int i = 0; i < this.Interval / timeSlice; i++)
                {
                    if (this.Started)
                    {
                        Thread.Sleep(timeSlice);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
