using CP.CoinSniffer.Common;

namespace CP.CoinSniffer.WPF.Model
{
    public class CoinAddress : NotificationObject
    {
        private string publicKey;

        public string PublicKey
        {
            get
            {
                return publicKey;
            }
            set
            {
                publicKey = value;
                RaisePropertyChanged("PublicKey");
            }
        }

        private string privateKey;

        public string PrivateKey
        {
            get
            {
                return privateKey;
            }
            set
            {
                privateKey = value;
                RaisePropertyChanged("PrivateKey");
            }
        }

        private string firstSeen;

        public string FirstSeen
        {
            get
            {
                return firstSeen;
            }
            set
            {
                firstSeen = value;
                RaisePropertyChanged("FirstSeen");
            }
        }

        private decimal balance;

        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                RaisePropertyChanged("Balance");
            }
        }

        public CoinAddress()
        { }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", PublicKey, PrivateKey, Balance, FirstSeen);
        }
    }
}
