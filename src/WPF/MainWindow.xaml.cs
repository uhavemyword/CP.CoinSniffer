using CP.CoinSniffer.Common;
using CP.CoinSniffer.WPF.Common;
using CP.CoinSniffer.WPF.Model;
using CP.CoinSniffer.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CP.CoinSniffer.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        private BTCSniffer sniffer;
        private object lockObject = new object();
        private const string settingFile = "Config.xml";
        private Stopwatch stopWatch;
        private DispatcherTimer timer;

        public MainWindow()
        {

            InitializeComponent();
            if (File.Exists(settingFile))
            {
                viewModel = XmlHelper.Deserialize<MainWindowViewModel>(settingFile);
            }
            else
            {
                viewModel = new MainWindowViewModel();
            }

            this.DataContext = viewModel;
            this.dataGrid.ItemsSource = viewModel.AvailableCoinAddress;

            sniffer = new BTCSniffer();
            sniffer.Sniffed += sniffer_OnSniffed;
            sniffer.AfterStopped += sniffer_AfterStopped;
            sniffer.ErrorCaught += sniffer_ErrorCaught;
            this.Closing += MainWindow_Closing;

            this.startBtn.IsEnabled = true;
            this.stopBtn.IsEnabled = false;

            stopWatch = new Stopwatch();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            System.Net.ServicePointManager.DefaultConnectionLimit = 65000;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var ts = stopWatch.Elapsed;
            viewModel.ElapsedTime = new TimeSpan(ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }

        void sniffer_ErrorCaught(Exception ex)
        {
            lock (lockObject)
            {
                viewModel.ErrorsCount++;
            }
        }

        void sniffer_AfterStopped(object sender, EventArgs e)
        {
            viewModel.State = "Sniffer Stopped!";
            stopWatch.Stop();
            timer.Stop();

            Dispatcher.Invoke(() =>
            {
                this.startBtn.IsEnabled = true;
            });
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XmlHelper.Serialize<MainWindowViewModel>(settingFile, viewModel);
            Environment.Exit(0);
        }

        void sniffer_OnSniffed(BitCoin.BitCoinAddress address)
        {
            lock (lockObject)
            {
                viewModel.CheckedCount++;
            }

            viewModel.State = String.Format("Checking PK: {0}", address.PrivateKey.Value);

            if (!address.FirstSeen.HasValue)
            {
                return;
            }

            CoinAddress ca = new CoinAddress()
            {
                PrivateKey = address.PrivateKey.Value,
                PublicKey = address.PublicKey.Value,
                Balance = address.Balance,
                FirstSeen = address.FirstSeen.HasValue ? address.FirstSeen.Value.ToString("yy-mm-dd hh:MM:ss") : "Never Seen"
            };

            lock (lockObject)
            {
                Dispatcher.Invoke(() =>
                {
                    viewModel.AvailableCoinAddress.Add(ca);
                    viewModel.FoundCount++;
                });
            }
        }

        private void Start()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                viewModel.State = "Preparing Sinffer...";

                Task.Factory.StartNew(() =>
                {
                    sniffer.ThreadCount = viewModel.ThreadCount;
                    sniffer.Interval = viewModel.Interval;
                    sniffer.Start();
                    stopWatch.Start();
                    timer.Start();
                });

                this.startBtn.IsEnabled = false;
                this.stopBtn.IsEnabled = true;
            }));
        }

        private void Stop()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    sniffer.Stop();

                });

                this.stopBtn.IsEnabled = false;
            }));
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as FrameworkElement).Tag.ToString();
            switch (tag.ToLower())
            {
                case "copy":
                    Copy();
                    break;
                case "addressinfo":
                    foreach (CoinAddress item in this.dataGrid.SelectedItems)
                    {
                        Process.Start(string.Format("https://blockchain.info/address/{0}", item.PublicKey));
                    }
                    break;
                case "balance":
                    foreach (CoinAddress item in this.dataGrid.SelectedItems)
                    {
                        Process.Start(string.Format("http://blockexplorer.com/q/addressbalance/{0}", item.PublicKey));
                    }
                    break;
                case "firstseen":
                    foreach (CoinAddress item in this.dataGrid.SelectedItems)
                    {
                        Process.Start(string.Format("http://blockexplorer.com/q/addressfirstseen/{0}", item.PublicKey));
                    }
                    break;
            }
        }

        private void Copy()
        {
            if (this.dataGrid.SelectedItems.Count > 0)
            {
                StringBuilder data = new StringBuilder();
                foreach (var coinAddress in this.dataGrid.SelectedItems)
                {
                    data.AppendLine(coinAddress.ToString());
                }
                System.Windows.Forms.Clipboard.SetText(data.ToString());
            }
        }
    }
}
