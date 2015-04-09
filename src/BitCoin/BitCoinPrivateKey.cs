// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/8/2013 2:52:40 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using CP.CoinSniffer.Common;
    using Org.BouncyCastle.Asn1.Sec;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Math.EC;
    using Org.BouncyCastle.Utilities.Encoders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// See https://en.bitcoin.it/wiki/Private_key
    /// uncompressed: 0x80 + [32-byte secret] + [4 bytes of Hash() of previous 33 bytes], base58 encoded
    /// compressed: 0x80 + [32-byte secret] + 0x01 + [4 bytes of Hash() previous 34 bytes], base58 encoded
    /// </summary>
    public class BitCoinPrivateKey
    {
        private byte[] _keyBytes;
        private string _value;
        private BitCoinPublicKey _publicKey;
        private bool _isCompressed;

        public BitCoinPrivateKey(BigInteger bi, bool compressed = true)
        {
            var parameters = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            if (bi.CompareTo(parameters.N) >= 0 || bi.SignValue <= 0)
            {
                throw new FormatException("Invalid private key. BigInteger is out of range!");
            }
            this._keyBytes = Utility.Force32Bytes(bi.ToByteArrayUnsigned());
            this._isCompressed = compressed;
        }

        /// <summary>
        /// See https://en.bitcoin.it/wiki/Wallet_import_format
        /// </summary>
        public BitCoinPrivateKey(string wifString)
        {
            try
            {
                // (1) WIF to private key
                // 1 - Take a Wallet Import Format string 
                // 2 - Convert it to a byte string using Base58Check encoding
                byte[] step12 = Base58.StringToByteArray(wifString);

                // 3 - Drop the last 4 checksum bytes from the byte string 
                byte[] step13 = step12.Take(step12.Length - 4).ToArray();

                // 4 - Drop the first byte (it should be 0x80). This is the private key 
                byte[] step14 = step13.Skip(1).ToArray();

                if (step14.Length == 33 && step14[32] == 0x01)
                {
                    this._isCompressed = true;
                    step14 = step14.Take(32).ToArray();
                }

                // (2) WIF checksum checking
                // 1 - Take the Wallet Import Format string 
                // 2 - Convert it to a byte string using Base58Check encoding
                // 3 - Drop the last 4 checksum bytes from the byte string 
                // 3 - Perform SHA-256 hash on the shortened string 
                var sha256 = new SHA256Managed();
                var step23 = sha256.ComputeHash(step13);

                // 4 - Perform SHA-256 hash on result of SHA-256 hash 
                var step24 = sha256.ComputeHash(step23);

                // 5 - Take the first 4 bytes of the second SHA-256 hash, this is the checksum 
                byte[] checkSum = step24.Take(4).ToArray();

                // 6 - Make sure it is the same, as the last 4 bytes from point 2 
                byte[] checkSumOriginal = step12.Skip(step12.Length - 4).ToArray();

                if (!checkSumOriginal.SequenceEqual(checkSum))
                {
                    throw new FormatException("Invalid private key. The key is not in Wallet_import_format!");
                }
                this._keyBytes = step14;
            }
            catch (Exception)
            {
                throw new FormatException("Invalid private key. The key is not in Wallet_import_format!");
            }
        }

        public bool IsCompressed
        {
            get { return _isCompressed; }
            private set { _isCompressed = value; }
        }

        public string Value
        {
            get
            {
                if (_value == null)
                {
                    _value = GetWIFString(this._isCompressed);
                }
                return _value;
            }
        }

        public BitCoinPublicKey PublicKey
        {
            get
            {
                if (_publicKey == null)
                {
                    _publicKey = new BitCoinPublicKey(ComputePublicKey(), this._isCompressed);
                }
                return _publicKey;
            }
        }

        public byte[] GetBytes()
        {
            return this._keyBytes;
        }

        public string GetHexString()
        {
            return Hex.ToHexString(this._keyBytes);
        }

        /// <summary>
        /// See https://en.bitcoin.it/wiki/Wallet_import_format
        /// </summary>
        /// <returns>Wallet Import Format string</returns>
        public string GetWIFString(bool compressed)
        {
            var sha256 = new SHA256Managed();

            // 1 - Take a private key
            // 2 - Add a 0x80 byte in front of it for mainnet addresses or 0xef for testnet addresses
            byte[] step2 = new byte[1] { 0x80 }.Concat(_keyBytes).ToArray();
            if (compressed)
            {
                step2 = step2.Concat(new byte[1] { 0x01 }).ToArray();
            }

            // 3 - Perform SHA-256 hash on the extended key
            var step3 = sha256.ComputeHash(step2);

            // 4 - Perform SHA-256 hash on result of SHA-256 hash
            var step4 = sha256.ComputeHash(step3);

            // 5 - Take the first 4 bytes of the second SHA-256 hash, this is the checksum
            byte[] step5 = step4.Take(4).ToArray();

            // 6 - Add the 4 checksum bytes from point 5 at the end of the extended key from point 2
            byte[] step6 = step2.Concat(step5).ToArray();

            // 7 - Convert the result from a byte string into a base58 string using Base58Check encoding. This is the Wallet Import Format
            return Base58.ByteArrayToString(step6);
        }

        public override string ToString()
        {
            return this.Value;
        }

        private byte[] ComputePublicKey()
        {
            X9ECParameters parameters = SecNamedCurves.GetByName("secp256k1");
            ECPoint pointG = parameters.G;

            BigInteger bi = new BigInteger(1, _keyBytes);
            ECPoint pointQ = pointG.Multiply(bi);

            byte[] publicKey = new byte[65];
            byte[] y = pointQ.Y.ToBigInteger().ToByteArray();
            Array.Copy(y, 0, publicKey, 64 - y.Length + 1, y.Length);
            byte[] x = pointQ.X.ToBigInteger().ToByteArray();
            Array.Copy(x, 0, publicKey, 32 - x.Length + 1, x.Length);
            publicKey[0] = 4;
            return publicKey;
        }
    }
}
