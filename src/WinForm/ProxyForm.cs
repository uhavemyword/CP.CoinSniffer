using CP.CoinSniffer.Common;
using System;
using System.Net;
using System.Windows.Forms;

namespace CP.CoinSniffer.WinForm
{
    public partial class ProxyForm : Form
    {
        private ProxySetting _proxySetting;

        public ProxyForm()
        {
            InitializeComponent();
            this._proxySetting = MySettingsManager.GetSettings<ProxySetting>();
            this.EnabledCheckBox.Checked = _proxySetting.Enabled;
            this.AddressTextBox.Text = _proxySetting.Address;
            this.UsernameTextBox.Text = _proxySetting.Username;
            this.PasswordTextBox.Text = Utility.Decrypt(_proxySetting.PasswordHash);
        }

        private void DetectButton_Click(object sender, EventArgs e)
        {
            // Create a new request to the mentioned URL.
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");

            // Obtain the 'Proxy' of the  Default browser.
            IWebProxy proxy = myWebRequest.Proxy;

            if (proxy != null)
            {
                this.AddressTextBox.Text = proxy.GetProxy(myWebRequest.RequestUri).ToString();
            }
            else
            {
                MessageBox.Show("No proxy is required. The program can directly connect to the internet.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _proxySetting.Enabled = this.EnabledCheckBox.Checked;
            _proxySetting.Address = this.AddressTextBox.Text;
            _proxySetting.Username = this.UsernameTextBox.Text;
            _proxySetting.PasswordHash = Utility.Encrypt(this.PasswordTextBox.Text);
            MySettingsManager.SaveSingle(_proxySetting);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.EnabledCheckBox.Checked;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
            var t = request.CachePolicy;
            if (this.EnabledCheckBox.Checked)
            {
                var proxy = new WebProxy();
                proxy.Address = new Uri(this.AddressTextBox.Text);
                proxy.Credentials = new NetworkCredential(this.UsernameTextBox.Text, this.PasswordTextBox.Text);
                request.Proxy = proxy;
            }
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                MessageBox.Show("Connection is OK", "Pass", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                request.Abort();
                if (response != null)
                {
                    response.Close();
                }
            }
        }
    }
}