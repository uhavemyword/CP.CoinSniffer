namespace CP.CoinSniffer.BitCoin
{
    using Org.BouncyCastle.Math;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Base58
    {
        /// <summary>
        /// See https://en.bitcoin.it/wiki/Base58Check_encoding
        /// Code is from https://github.com/casascius/Bitcoin-Address-Utility/blob/master/Model/Base58.cs
        /// </summary>
        /// <returns>string</returns>
        public static string ByteArrayToString(byte[] bytes)
        {
            string code = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            BigInteger x = new BigInteger(1, bytes);
            BigInteger bi0 = new BigInteger("0");
            BigInteger bi58 = new BigInteger("58");
            string result = string.Empty;

            while (x.CompareTo(bi0) > 0)
            {
                int d = Convert.ToInt32(x.Mod(bi58).ToString());
                x = x.Divide(bi58);
                result = code.Substring(d, 1) + result;
            }

            // handle leading zeroes
            foreach (byte b in bytes)
            {
                if (b != 0)
                {
                    break;
                }
                result = "1" + result;
            }
            return result;
        }

        public static byte[] StringToByteArray(string base58)
        {
            string code = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            BigInteger bi0 = new BigInteger("0");

            foreach (char c in base58)
            {
                if (code.IndexOf(c) != -1)
                {
                    bi0 = bi0.Multiply(new BigInteger("58"));
                    bi0 = bi0.Add(new BigInteger(code.IndexOf(c).ToString()));
                }
                else
                {
                    return null;
                }
            }

            byte[] bb = bi0.ToByteArrayUnsigned();

            // interpret leading '1's as leading zero bytes
            foreach (char c in base58)
            {
                if (c != '1')
                {
                    break;
                }
                byte[] bbb = new byte[bb.Length + 1];
                Array.Copy(bb, 0, bbb, 1, bb.Length);
                bb = bbb;
            }

            return bb;
        }
    }
}
