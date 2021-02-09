using PCLCrypto;

namespace JiraTimers.Security
{
	public class EncryptionServiceFactory
	{
		private readonly ISymmetricKeyAlgorithmProvider _provider;
		private readonly ICryptographicBuffer _cryptographicBuffer;

		public EncryptionServiceFactory(ISymmetricKeyAlgorithmProvider provider, ICryptographicBuffer cryptographicBuffer)
		{
			_provider = provider;
			_cryptographicBuffer = cryptographicBuffer;
		}

		public EncryptionService Create(byte[] key)
		{
			return new EncryptionService(_provider, _cryptographicBuffer, key);
		}
	}
}