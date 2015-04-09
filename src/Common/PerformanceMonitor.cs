// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/11/2013 8:37:33 PM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class PerformanceMonitor
    {
        private int _processId;
        private int? _cpuUsage;
        private Thread _thread;

        public PerformanceMonitor(int processId)
        {
            this._processId = processId;
        }

        public int ProcessId
        {
            get { return _processId; }
            private set { _processId = value; }
        }

        public int CpuUsage
        {
            get
            {
                return _cpuUsage ?? 0;
            }
            private set
            {
                if (value != _cpuUsage)
                {
                    _cpuUsage = value;
                    OnCpuUsageChanged(value);
                }
            }
        }

        public delegate void CpuUsageChangedEventHandler(int percentage);

        public event CpuUsageChangedEventHandler CpuUsageChanged;

        public void Monitor(int interval = 1000)
        {
            _thread = new Thread(() => Calculate(interval));
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void Stop()
        {
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }
        }

        private void Calculate(int interval)
        {
            var instanceName = GetProcessInstanceName(this._processId);
            if (string.IsNullOrEmpty(instanceName))
            {
                return;
            }
            using (var counter = new PerformanceCounter("Process", "% Processor Time", instanceName))
            {
                while (true)
                {
                    try
                    {
                        this.CpuUsage = (int)(counter.NextValue() / Environment.ProcessorCount);
                        System.Threading.Thread.Sleep(interval);
                    }
                    catch (InvalidOperationException)
                    {
                        // If we get here, probably the instance name changed, 
                        // e.g. "CoinSniffer#1" will change to "ConSniffer" after stop "ConSniffer" intance.
                        var newName = GetProcessInstanceName(this._processId);
                        if (string.IsNullOrEmpty(newName))
                        {
                            throw new Exception("Process instance name doesn't exist!");
                        }
                        else
                        {
                            counter.InstanceName = newName;
                        }
                    }
                }
            }
        }

        private string GetProcessInstanceName(int processId)
        {
            try
            {
                var performanceCounterCategory = new PerformanceCounterCategory("Process");
                string[] instances = performanceCounterCategory.GetInstanceNames();
                foreach (string instance in instances)
                {
                    using (var counter = new PerformanceCounter("Process", "ID Process", instance, true))
                    {
                        int id = (int)counter.RawValue;
                        if (id == processId)
                        {
                            return instance;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        private void OnCpuUsageChanged(int percentage)
        {
            var handler = this.CpuUsageChanged;
            if (handler != null)
            {
                handler(percentage);
            }
        }
    }
}
