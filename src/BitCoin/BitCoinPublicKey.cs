// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/8/2013 2:52:27 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using CP.CoinSniffer.Common;
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Utilities.Encoders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class BitCoinPublicKey
    {
        private byte[] _keyBytes;
        private string _value;
        private bool _isCompressed;

        public BitCoinPublicKey(byte[] keyBytes, bool compressed = true)
        {
            this._keyBytes = keyBytes;
            this._isCompressed = compressed;
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

        public byte[] GetBytes()
        {
            return this._keyBytes;
        }

        public string GetHexString()
        {
            return Hex.ToHexString(this._keyBytes);
        }

        /// <summary>
        /// See https://en.bitcoin.it/wiki/Technical_background_of_Bitcoin_addresses
        /// </summary>
        /// <returns>Wallet Import Format string</returns>
        public string GetWIFString(bool compressed)
        {
            try
            {
                byte[] keyBytes = ConvertBytes(this._keyBytes, compressed);

                var sha256 = new SHA256Managed();
                var ripemd160 = new RIPEMD160Managed();

                // 0 - Having a private ECDSA key 
                // 1 - Take the corresponding public key generated with it (65 bytes, 1 byte 0x04, 32 bytes corresponding to X coordinate, 32 bytes corresponding to Y coordinate) 
                // 2 - Perform SHA-256 hashing on the public key 
                var step2 = sha256.ComputeHash(keyBytes);

                // 3 - Perform RIPEMD-160 hashing on the result of SHA-256 
                var step3 = ripemd160.ComputeHash(step2);

                // 4 - Add version byte in front of RIPEMD-160 hash (0x00 for Main Network) 
                byte[] versionByte = new byte[1] { 0x00 };
                var step4 = versionByte.Concat(step3).ToArray();

                // 5 - Perform SHA-256 hash on the extended RIPEMD-160 result 
                var step5 = sha256.ComputeHash(step4);

                // 6 - Perform SHA-256 hash on the result of the previous SHA-256 hash 
                var step6 = sha256.ComputeHash(step5);

                // 7 - Take the first 4 bytes of the second SHA-256 hash. This is the address checksum 
                byte[] step7 = step6.Take(4).ToArray();

                // 8 - Add the 4 checksum bytes from point 7 at the end of extended RIPEMD-160 hash from point 4. This is the 25-byte binary Bitcoin Address. 
                var step8 = step4.Concat(step7).ToArray();
                if (step8.Length != 25)
                {
                    throw new FormatException("Invalid public key. The key is not in Wallet_import_format!");
                }

                // 9 - Convert the result from a byte string into a base58 string using Base58Check encoding. This is the most commonly used Bitcoin Address format 
                return Base58.ByteArrayToString(step8);
            }
            catch (Exception)
            {
                throw new FormatException("Invalid public key. The key is not in Wallet_import_format!");
            }
        }

        public override string ToString()
        {
            return this.Value;
        }

        private byte[] ConvertBytes(byte[] orginal, bool compressed)
        {
            var ps = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            var point = ps.Curve.DecodePoint(orginal);
            var point2 = ps.Curve.CreatePoint(point.X.ToBigInteger(), point.Y.ToBigInteger(), compressed);
            var result = point2.GetEncoded();
            return result;
        }
    }
}
