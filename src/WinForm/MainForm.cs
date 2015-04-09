using CP.CoinSniffer.BitCoin;
using CP.CoinSniffer.Common;
using CP.CoinSniffer.WinForm.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CP.CoinSniffer.WinForm
{
    public partial class MainForm : Form
    {
        private BitCoinSniffer _sniffer;
        private PerformanceMonitor _monitor;
        private ClientSettings _config;
        private Stopwatch _stopWatch = new Stopwatch();
        private int _errorCount;
        private bool _blinkFlag;
        private object _counterSync = new object();
        private object _syncObject = new object();

        public MainForm()
        {
            InitializeComponent();
            this._config = MySettingsManager.GetSettings<ClientSettings>();

            this.Height = _config.MainFormHeight < this.MinimumSize.Height ? this.MinimumSize.Height : _config.MainFormHeight;
            this.Width = _config.MainFormWidth < this.MinimumSize.Width ? this.MinimumSize.Width : _config.MainFormWidth;
            this.TotalFoundLabel.Text = Program.TotalFound.ToString();
            this.TotalScannedLabel.Text = Program.TotalScanned.ToString();

            this.MessageStatusLabel.Text = string.Empty;
            this.PerformanceStatusLabel.Text = string.Empty;
            this.ErrorStatusLabel.Text = string.Empty;
            this.ErrorTextBox.Dock = DockStyle.Fill;
            this.ErrorTextBox.Visible = false;

            var stored = ClientHelper.RestoreAddresses();
            stored.ForEach(x => InsertToListView(x));

            this._sniffer = new BitCoinSniffer();
            this._sniffer.Sniffed += Sniffer_Sniffed;
            this._sniffer.ErrorCaught += Sniffer_ErrorCaught;

            var process = Process.GetCurrentProcess();
            this._monitor = new PerformanceMonitor(process.Id);
            this._monitor.CpuUsageChanged += Monitor_CpuUsageChanged;
            this._monitor.Monitor();

            NotifyUIOnStatusChange(started: false);
            StopwatchTimer_Tick(null, null);

            if (_config.StartOnLaunch)
            {
                Start();
            }
        }

        private void Sniffer_ErrorCaught(Exception ex)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.MessageStatusLabel.Text = ex.Message;
                _errorCount++;
                this.ErrorStatusLabel.Text = string.Format("Error: {0}", _errorCount);
                string old = this.ErrorTextBox.Text.Substring(0, Math.Min(this.ErrorTextBox.Text.Length, 1000));
                this.ErrorTextBox.Text = string.Format("{0} [{1}] - {2} ({3}) {4}", DateTime.Now, System.Threading.Thread.CurrentThread.ManagedThreadId, ex.Message, ex.StackTrace, Environment.NewLine) + old;
            }));
        }

        private void Monitor_CpuUsageChanged(int percentage)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.PerformanceStatusLabel.Text = string.Format("CPU {0}%", percentage.ToString().PadLeft(2, ' '));
            }));
        }

        private void Sniffer_Sniffed(BitCoinAddress address)
        {
            if (address == null)
            {
                return;
            }

            lock (_counterSync)
            {
                if (address.Balance > 0)
                {
                    Program.CurrentFound++;
                    Program.TotalFound++;
                    if (_config.MailEnabled)
                    {
                        ClientHelper.SendMailForAddresses(new List<BitCoinAddress> { address });
                    }
                }
                Program.CurrentScanned++;
                Program.TotalScanned++;
            }

            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (address.Balance > 0)
                {
                    this.BlinkTimer.Enabled = true;
                    ////this.NotifyIcon.ShowBalloonTip(9000, "Look Here", string.Format("Found {0} coins !", address.Balance), ToolTipIcon.Info);
                }

                if (_config.OnlyShowExisting)
                {
                    if (address.FirstSeen.HasValue || address.Balance > 0)
                    {
                        InsertToListView(address);
                    }
                }
                else if (_config.ListViewCapacityForNonExistAddresses >= 0)
                {
                    // Remove item if exceed the capacity from settings, while keep the ever seen items.
                    int count = this.listView1.Items.Count;
                    int everSeen = 0;
                    for (int i = 0; i < count; i++)
                    {
                        var item = listView1.Items[i].Tag as BitCoinAddress;
                        if (item.FirstSeen.HasValue || item.Balance > 0)
                        {
                            everSeen++;
                            continue;
                        }
                        break;
                    }
                    while (count > 0 && count > everSeen + _config.ListViewCapacityForNonExistAddresses - 1)
                    {
                        listView1.Items.RemoveAt(--count);
                    }

                    if (_config.ListViewCapacityForNonExistAddresses != 0)
                    {
                        InsertToListView(address);
                    }
                }

                // BeginInvoke is excuted async, so check sniffer state to not affect NotifyUiOnStatusChange method
                if (_sniffer.Started)
                {
                    this.MessageStatusLabel.Text = "Checking   " + address.PublicKey.Value;
                }
                this.CurrentFoundLabel.Text = Program.CurrentFound.ToString();
                this.CurrentScannedLabel.Text = Program.CurrentScanned.ToString();
                this.TotalFoundLabel.Text = Program.TotalFound.ToString();
                this.TotalScannedLabel.Text = Program.TotalScanned.ToString();
            }));
        }

        private void InsertToListView(BitCoinAddress address)
        {
            // This method is called in UI thread, so comment out the lock
            //lock (this._syncObject)

            var item = new ListViewItem();
            item.Tag = address;
            item.Text = address.PublicKey.Value;
            item.SubItems.Add(address.FirstSeen.HasValue ? address.FirstSeen.Value.ToString() : "Never Seen");
            item.SubItems.Add(address.Balance.ToString());
            item.SubItems.Add(address.PrivateKey.Value);
            item.SubItems.Add(DateTime.Now.ToString());

            if (address.Balance > 0)
            {
                item.BackColor = Color.Gold;
            }
            else if (address.FirstSeen.HasValue)
            {
                item.BackColor = Color.Silver;
            }

            // find the right place for inserting
            int index = 0;
            int count = listView1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                var toInsert = address;
                var toCompare = listView1.Items[i].Tag as BitCoinAddress;
                if (toInsert.Balance < toCompare.Balance)
                {
                    index++;
                    continue;
                }
                if (toInsert.Balance == 0 && toCompare.FirstSeen.HasValue)
                {
                    index++;
                    continue;
                }
                break;
            }

            listView1.Items.Insert(index, item);
            listView1.MultiSelect = false;
            item.Selected = true;
            listView1.MultiSelect = true;
        }

        private void Start()
        {
            this._stopWatch.Start();
            this._sniffer.Change(_config.Interval, _config.ThreadCount, _config.KeyType);
            NotifyUIOnStatusChange(true);
        }

        private void Stop()
        {
            this._sniffer.Stop();
            this._stopWatch.Stop();
            NotifyUIOnStatusChange(false);
        }

        private void NotifyUIOnStatusChange(bool started)
        {
            this.StartToolStripMenuItem.Enabled = !started;
            this.StopToolStripMenuItem.Enabled = started;
            this.TestToolStripMenuItem.Enabled = !started;
            this.ProgressBar.Style = started ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
            this.MessageStatusLabel.Text = started ? "Started" : "Stopped";
        }

        #region MainForm Menu

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TestForm();
            form.InsertButtonClicked += InsertToListView;
            form.ShowDialog();
            form.InsertButtonClicked -= InsertToListView;
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region ListView menu

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var loc = this.listView1.HitTest(e.Location);
                if (loc.Item != null)
                {
                    this.ListViewContextMenuStrip.Show(this.listView1, e.Location);
                }
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var loc = this.listView1.HitTest(e.Location);
                if (loc.Item != null)
                {
                    var address = loc.Item.Tag as BitCoinAddress;
                    var form = new TestForm(address);
                    form.ShowDialog();
                }
            }
        }

        private void CopyRowMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                foreach (System.Windows.Forms.ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    sb.Append(subItem.Text).Append("    ");
                }
                sb.Append(Environment.NewLine);
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                Clipboard.SetText(sb.ToString());
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                this.listView1.Items.Remove(item);
            }
        }

        private void AddressMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 10)
            {
                var dialogResult = MessageBox.Show("You have selected more than 10 rows, are you sure you want to open all of them on internet?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }

            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                var address = item.Text;
                var menu = sender as ToolStripMenuItem;
                if (menu == null)
                {
                    return;
                }
                if (menu.Name == this.AddressInfoMenuItem.Name)
                {
                    Process.Start(string.Format("https://blockchain.info/address/{0}", address));
                }
                else if (menu.Name == this.BalanceMenuItem.Name)
                {
                    Process.Start(string.Format("http://blockexplorer.com/q/addressbalance/{0}", address));
                }
                else if (menu.Name == this.FirstSeenMenuItem.Name)
                {
                    Process.Start(string.Format("http://blockexplorer.com/q/addressfirstseen/{0}", address));
                }
            }
        }

        private void ClearAllMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (_config.MinimizeOnClose)
                {
                    e.Cancel = true;
                    this.Hide();
                    return;
                }
            }

            if (this.WindowState != FormWindowState.Maximized)
            {
                _config.MainFormHeight = this.Height;
                _config.MainFormWidth = this.Width;
            }

            var everSeen = new List<BitCoinAddress>();
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                var address = this.listView1.Items[i].Tag as BitCoinAddress;
                if (address.FirstSeen.HasValue || address.Balance > 0)
                {
                    everSeen.Add(address);
                }
                else
                {
                    break;
                }
            }
            ClientHelper.RememberAddresses(everSeen);
            Program.Application_ApplicationExit(this, null);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = !_config.MinimizeToTray;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.BlinkTimer.Enabled = false;
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    return;
                }

                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.Activate();
                }
            }
        }

        private void StopwatchTimer_Tick(object sender, EventArgs e)
        {
            var ticks = this._stopWatch.Elapsed.Ticks;
            Program.CurrentElapsedTicks = ticks;
            var currentTimeSpan = new TimeSpan(Program.CurrentElapsedTicks);
            this.CurrentElapsedDayLabel.Text = currentTimeSpan.Days.ToString();
            this.CurrentElapsedTimeLabel.Text = string.Format(@"{0:hh\:mm\:ss}", currentTimeSpan);

            var totalTimeSpan = new TimeSpan(Program.CurrentElapsedTicks + Program.TotalElapsedTicks);
            this.TotalElapsedDayLabel.Text = totalTimeSpan.Days.ToString();
            this.TotalElapsedTimeLabel.Text = string.Format(@"{0:hh\:mm\:ss}", totalTimeSpan);
        }

        private void ErrorStatusLabel_Click(object sender, EventArgs e)
        {
            if (this.ErrorTextBox.Visible)
            {
                this.ErrorTextBox.Visible = false;
                this.ErrorStatusLabel.Text = string.Empty;
                this._errorCount = 0;
            }
            else
            {
                this.ErrorTextBox.Visible = true;
            }
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            if (_blinkFlag)
            {
                this.NotifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("Blank.Icon");
            }
            else
            {
                this.NotifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("NotifyIcon.Icon");
            }
            _blinkFlag = !_blinkFlag;
        }
    }
}