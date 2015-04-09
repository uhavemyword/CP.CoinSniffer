// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/8/2013 1:11:26 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.BitCoin
{
    using Org.BouncyCastle.Asn1.Sec;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Security;

    public class ECKeyPair
    {
        // See https://en.bitcoin.it/wiki/Secp256k1
        private static X9ECParameters _curve = SecNamedCurves.GetByName("secp256k1");

        private static ECDomainParameters _domain = new ECDomainParameters(_curve.Curve, _curve.G, _curve.N, _curve.H);
        private static SecureRandom _secureRandom = new SecureRandom();

        public ECKeyPair()
        {
            ECKeyPairGenerator generator = new ECKeyPairGenerator();
            ECKeyGenerationParameters keygenParams = new ECKeyGenerationParameters(_domain, _secureRandom);
            generator.Init(keygenParams);
            AsymmetricCipherKeyPair keypair = generator.GenerateKeyPair();
            ECPrivateKeyParameters privParams = (ECPrivateKeyParameters)keypair.Private;
            ECPublicKeyParameters pubParams = (ECPublicKeyParameters)keypair.Public;

            this.PrivateKey = privParams.D;
            this.PublicKey = pubParams.Q.GetEncoded();
        }

        public BigInteger PrivateKey { get; private set; }
        public byte[] PublicKey { get; private set; }
    }
}
