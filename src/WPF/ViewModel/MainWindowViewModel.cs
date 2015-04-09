using CP.CoinSniffer.Common;
using CP.CoinSniffer.WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CP.CoinSniffer.WPF.ViewModel
{
    [XmlRoot("Settings")]
    public class MainWindowViewModel : NotificationObject
    {
        [XmlArray]
        public ObservableCollection<CoinAddress> AvailableCoinAddress { get; set; }

        private int threadCount;

        [XmlElement]
        public int ThreadCount
        {
            get
            {
                return threadCount;
            }
            set
            {
                threadCount = value;
                RaisePropertyChanged("ThreadCount");
            }
        }

        private int interval;

        [XmlElement]
        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                RaisePropertyChanged("Interval");
            }
        }

        private int checkedCount;

        [XmlIgnore]
        public int CheckedCount
        {
            get { return checkedCount; }
            set
            {
                checkedCount = value;
                RaisePropertyChanged("CheckedCount");
            }
        }

        private int foundCount;

        [XmlIgnore]
        public int FoundCount
        {
            get { return foundCount; }
            set
            {
                foundCount = value;
                RaisePropertyChanged("FoundCount");
            }
        }

        private int errorsCount;

        [XmlIgnore]
        public int ErrorsCount
        {
            get
            {
                return errorsCount;
            }
            set
            {
                errorsCount = value;
                RaisePropertyChanged("ErrorsCount");
            }
        }


        private TimeSpan elapsedTime;

        public TimeSpan ElapsedTime
        {
            get
            {
                return elapsedTime;
            }
            set
            {
                elapsedTime = value;
                RaisePropertyChanged("ElapsedTime");
            }
        }


        private string state;

        [XmlIgnore]
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                RaisePropertyChanged("State");
            }
        }

        private int cpuUsage;

        [XmlIgnore]
        public int CPUUsage
        {
            get
            {
                return cpuUsage;
            }
            set
            {
                cpuUsage = value;
                RaisePropertyChanged("CPUUsage");
            }
        }

        private PerformanceMonitor monitor;

        public MainWindowViewModel()
        {
            AvailableCoinAddress = new ObservableCollection<CoinAddress>();
            CheckedCount = 0;
            FoundCount = 0;
            State = string.Empty;
            ThreadCount = 10;
            Interval = 300;
            CPUUsage = 0;
            ErrorsCount = 0;
            monitor = new PerformanceMonitor(Process.GetCurrentProcess().Id);
            monitor.CpuUsageChanged += (percentage) => { CPUUsage = percentage; };
            monitor.Monitor();
        }
    }
}
