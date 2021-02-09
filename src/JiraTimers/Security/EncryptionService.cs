using System;
using System.Text;
using PCLCrypto;

namespace JiraTimers.Security
{
	public class EncryptionService
	{
		private readonly ICryptographicBuffer _cryptographicBuffer;
		private readonly ICryptographicKey _key;

		public EncryptionService(ISymmetricKeyAlgorithmProvider provider, ICryptographicBuffer cryptographicBuffer, byte[] key)
		{
			if (provider == null)
				throw new ArgumentNullException(nameof(provider));

			if (key == null)
				throw new ArgumentNullException(nameof(key));

			_cryptographicBuffer = cryptographicBuffer;

			_key = provider.CreateSymmetricKey(key);
		}

		public string Encrypt(string str) => Encrypt(_cryptographicBuffer.ConvertStringToBinary(str, Encoding.Unicode));

		public string Decrypt(string str) => Decrypt(_cryptographicBuffer.ConvertStringToBinary(str, Encoding.Unicode));

		private string Encrypt(byte[] data) => _cryptographicBuffer.ConvertBinaryToString(Encoding.Unicode,
					WinRTCrypto.CryptographicEngine.Encrypt(_key, data));

		private string Decrypt(byte[] data) =>
			_cryptographicBuffer.ConvertBinaryToString(Encoding.Unicode, WinRTCrypto.CryptographicEngine.Decrypt(_key, data));
	}
}