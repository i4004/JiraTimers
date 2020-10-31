using PCLCrypto;
using Simplify.DI;

namespace JiraTimers.Settings
{
	public static class CryptoRegistrations
	{
		public static IDIRegistrator RegisterCryptography(this IDIRegistrator registrator)
		{
			return registrator.Register(r => WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7),
				LifetimeType.Singleton);
		}
	}
}