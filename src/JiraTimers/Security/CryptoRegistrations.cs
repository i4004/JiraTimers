using PCLCrypto;
using Simplify.DI;

namespace JiraTimers.Security
{
	public static class CryptoRegistrations
	{
		public static IDIRegistrator RegisterCryptography(this IDIRegistrator registrator) =>
			registrator.Register(r => WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7), LifetimeType.Singleton)
				.Register<EncryptionServiceFactory>(LifetimeType.Singleton)
				.Register(r => WinRTCrypto.CryptographicBuffer, LifetimeType.Singleton);
	}
}