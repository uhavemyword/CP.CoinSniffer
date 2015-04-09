using CP.CoinSniffer.BitCoin;
using CP.CoinSniffer.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CP.CoinSniffer.WinForm.Settings
{
    public partial class SettingsForm : Form
    {
        private ClientSettings _config = MySettingsManager.GetSettings<ClientSettings>();

        public SettingsForm()
        {
            InitializeComponent();
            FillKeyTypeComboBox();
        }

        private void FillKeyTypeComboBox()
        {
            var names = Enum.GetNames(typeof(BitCoinKeyType)).ToList();
            names.ForEach(x => this.KeyTypeComboBox.Items.Add(x));
            this.KeyTypeComboBox.SelectedIndex = names.IndexOf(_config.KeyType.ToString());
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.LaunchOnLoginCheckBox.Checked = _config.LaunchOnLogin;
            this.StartOnLaunchCheckBox.Checked = _config.StartOnLaunch;
            this.ThreadCountNumericUpDown.Value = _config.ThreadCount;
            this.IntervalNumericUpDown.Value = _config.Interval;

            this.OnlyShowExistingCheckBox.Checked = _config.OnlyShowExisting;
            this.OnlyShowExistingCheckBox_CheckedChanged(null, null);
            this.CapacityForNonExistNumericUpDown.Value = _config.ListViewCapacityForNonExistAddresses;

            this.MinimizeToTrayCheckBox.Checked = _config.MinimizeToTray;
            this.MinimizeOnCloseCheckBox.Checked = _config.MinimizeOnClose;

            this.MailEnabledCheckBox.Checked = _config.MailEnabled;
            this.MailEnabledCheckBox_CheckedChanged(null, null);
            this.MailEnabledCheckBox.Checked = _config.MailEnabled;
            this.MailServerTextBox.Text = _config.MailServer;
            this.MailPortTextBox.Text = _config.MailPort.ToString();
            this.MailUsernameTextBox.Text = _config.MailUsername;
            this.MailPasswordTextBox.Text = Utility.Decrypt(_config.MailPasswordHash);
            this.MailToTextBox.Text = _config.MailTo;
            this.MailSubjectTextBox.Text = _config.MailSubject;
            this.MailBodyTextBox.Text = _config.MailBody;
        }

        private void SaveSettings()
        {
            _config.LaunchOnLogin = this.LaunchOnLoginCheckBox.Checked;
            _config.StartOnLaunch = this.StartOnLaunchCheckBox.Checked;
            SetStartup(_config.LaunchOnLogin);
            _config.ThreadCount = (int)this.ThreadCountNumericUpDown.Value;
            _config.Interval = (int)this.IntervalNumericUpDown.Value;
            _config.KeyType = (BitCoinKeyType)Enum.Parse(typeof(BitCoinKeyType), this.KeyTypeComboBox.SelectedItem.ToString());

            _config.OnlyShowExisting = this.OnlyShowExistingCheckBox.Checked;
            _config.ListViewCapacityForNonExistAddresses = (int)this.CapacityForNonExistNumericUpDown.Value;

            _config.MinimizeToTray = this.MinimizeToTrayCheckBox.Checked;
            _config.MinimizeOnClose = this.MinimizeOnCloseCheckBox.Checked;

            if (_config.MailEnabled)
            {
                if (!CheckMailInputsAndDisplayError())
                {
                    return;
                }
                _config.MailServer = this.MailServerTextBox.Text;
                _config.MailPort = int.Parse(this.MailPortTextBox.Text);
                _config.MailUsername = this.MailUsernameTextBox.Text;
                _config.MailPasswordHash = Utility.Encrypt(this.MailPasswordTextBox.Text);
                _config.MailTo = this.MailToTextBox.Text;
                _config.MailSubject = this.MailSubjectTextBox.Text;
                _config.MailBody = this.MailBodyTextBox.Text;
            }

            MySettingsManager.SaveSingle(_config);
        }

        private void SetStartup(bool b)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            if (b)
            {
                rk.SetValue(appName, Application.ExecutablePath.ToString());
            }
            else
            {
                rk.DeleteValue(appName, false);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void MailEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.MailGroupBox.Enabled = this.MailEnabledCheckBox.Checked;
            _config.MailEnabled = this.MailEnabledCheckBox.Checked;
        }

        /// <summary>
        /// Check mail inputs
        /// </summary>
        /// <returns>null if no error, otherwise the error string</returns>
        private string CheckMailInputs()
        {
            if (string.IsNullOrEmpty(this.MailServerTextBox.Text))
            {
                return "Server is required!";
            }

            int port;
            if (!int.TryParse(this.MailPortTextBox.Text, out port))
            {
                return "Port should be an interger!";
            }

            if (!CheckMailAddress(this.MailToTextBox.Text))
            {
                return "To should be a valid e-mail address!";
            }

            if (!CheckMailAddress(this.MailUsernameTextBox.Text))
            {
                return "Username should be a valid e-mail address!";
            }

            return null;
        }

        private bool CheckMailInputsAndDisplayError()
        {
            var s = CheckMailInputs();
            if (s != null)
            {
                MessageBox.Show(s, "Mail Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool CheckMailAddress(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            var regex = new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(s);
        }

        private void MailTestButton_Click(object sender, EventArgs e)
        {
            if (!CheckMailInputsAndDisplayError())
            {
                return;
            }
            var s = Utility.SendEMail(this.MailServerTextBox.Text,
                                                      int.Parse(this.MailPortTextBox.Text),
                                                      this.MailUsernameTextBox.Text,
                                                      this.MailPasswordTextBox.Text,
                                                      this.MailUsernameTextBox.Text,
                                                      this.MailToTextBox.Text,
                                                      this.MailSubjectTextBox.Text,
                                                      this.MailBodyTextBox.Text);
            if (s != null)
            {
                MessageBox.Show(s, "Mail test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("OK", "Mail test passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnlyShowExistingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CapacityForNonExistNumericUpDown.Enabled = !this.OnlyShowExistingCheckBox.Checked;
        }
    }
}
