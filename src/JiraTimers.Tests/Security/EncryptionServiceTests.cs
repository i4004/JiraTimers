using JiraTimers.Security;
using NUnit.Framework;
using PCLCrypto;
using SymmetricAlgorithm = PCLCrypto.SymmetricAlgorithm;

namespace JiraTimers.Tests.Security
{
	[TestFixture]
	public class EncryptionServiceTests
	{
		private EncryptionService _service;

		[SetUp]
		public void Initialize()
		{
			_service = new EncryptionService(WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7),
			WinRTCrypto.CryptographicBuffer, WinRTCrypto.CryptographicBuffer.GenerateRandom(32));
		}

		[Test]
		public void EncryptDecrypt_Value_SameValue()
		{
			// Arrange
			const string value = "!Q@Wbp;uo7890glsd";

			// Act
			var result = _service.Decrypt(_service.Encrypt(value));

			// Assert
			Assert.AreEqual(value, result);
		}
	}
}