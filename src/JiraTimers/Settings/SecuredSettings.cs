using System;
using System.Text;
using JiraTimers.Security;
using Microsoft.Extensions.Configuration;
using PCLCrypto;

namespace JiraTimers.Settings
{
	public class SecuredSettings : JiraTimersSettings
	{
		private const string KeyFieldName = "CryptoKey";
		private readonly ICryptographicBuffer _cryptographicBuffer;
		private readonly EncryptionService _encryptionService;

		public SecuredSettings(EncryptionServiceFactory encryptionServiceFactory, ICryptographicBuffer cryptographicBuffer, IConfiguration configuration) : base(configuration)
		{
			_cryptographicBuffer = cryptographicBuffer;
			_encryptionService = encryptionServiceFactory.Create(LoadKey(configuration));
		}

		public override string? JiraUserPassword
		{
			get
			{
				var password = base.JiraUserPassword;

				return password != null ? FromEncryptedAndEncodedString(password) : null;
			}
			set => base.JiraUserPassword = value == null ? null : ToEncryptedAndEncodedString(value);
		}

		private static byte[] GenerateKey()
		{
			return WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
		}

		private static string DecodeBase64(string str) => Encoding.Unicode.GetString(Convert.FromBase64String(str));

		private static string EncodeBase64(string str) => Convert.ToBase64String(Encoding.Unicode.GetBytes(str));

		private byte[] ToBytesDecoded(string str) => _cryptographicBuffer.DecodeFromBase64String(str);

		private byte[] LoadKey(IConfiguration configuration)
		{
			var keyString = configuration[KeyFieldName];

			if (keyString != null)
				return ToBytesDecoded(keyString);

			var key = GenerateKey();
			configuration[KeyFieldName] = ToStringEncoded(key);

			return key;
		}

		private string ToStringEncoded(byte[] bytes) => _cryptographicBuffer.EncodeToBase64String(bytes);

		private string ToEncryptedAndEncodedString(string str) => EncodeBase64(_encryptionService.Encrypt(str));

		private string FromEncryptedAndEncodedString(string str) => _encryptionService.Decrypt(DecodeBase64(str));
	}
}