using CP.CoinSniffer.BitCoin;
using CP.CoinSniffer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CP.CoinSniffer.WinForm
{
    public partial class TestForm : Form
    {
        private BitCoinAddress _address;
        private Random _random = new Random();

        public TestForm()
        {
            InitializeComponent();
        }

        public TestForm(BitCoinAddress address)
            : this()
        {
            this.InsertButton.Enabled = false;
            this.CheckButton.Text = "Refresh";
            this.Address = address;
        }

        public BitCoinAddress Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                if (_address == null)
                {
                    this.CompressedPrivateKeyTextBox.Text = string.Empty;
                    this.UncompressedPrivateKeyTextBox.Text = string.Empty;
                    this.CompressedPublicKeyTextBox.Text = string.Empty;
                    this.UncompressedPublicKeyTextBox.Text = string.Empty;
                    this.BalanceTextBox.Text = string.Empty;
                    this.FirstSeenTextBox.Text = string.Empty;
                }
                else
                {
                    this.PrivateKeyTextBox.Text = string.Empty;
                    this.CompressedPrivateKeyTextBox.Text = _address.PrivateKey.GetWIFString(true);
                    this.UncompressedPrivateKeyTextBox.Text = _address.PrivateKey.GetWIFString(false);
                    this.CompressedPublicKeyTextBox.Text = _address.PublicKey.GetWIFString(true);
                    this.UncompressedPublicKeyTextBox.Text = _address.PublicKey.GetWIFString(false);
                    this.BalanceTextBox.Text = _address.Balance.ToString();
                    this.FirstSeenTextBox.Text = _address.FirstSeen.HasValue ? _address.FirstSeen.ToString() : "Never Seen";
                }
            }
        }

        public delegate void InsertButtonClickedEventHandler(BitCoinAddress address);

        public event InsertButtonClickedEventHandler InsertButtonClicked;

        private void OnInsertButtonClicked(BitCoinAddress address)
        {
            var handler = this.InsertButtonClicked;
            if (handler != null)
            {
                handler(address);
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            string privateKey = this.PrivateKeyTextBox.Text.Trim();
            if (string.IsNullOrEmpty(privateKey))
            {
                return;
            }

            BitCoinAddress address = null;
            try
            {
                address = new BitCoinAddress(privateKey);
                BitCoinSniffer.RefreshData(address);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Address = address;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (this.Address != null)
            {
                OnInsertButtonClicked(Address);
            }
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            var address = new BitCoinAddress(this._random.Next(2) == 0);
            try
            {
                BitCoinSniffer.RefreshData(address);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Address = address;
        }
    }
}
