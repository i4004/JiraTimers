using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using PCLCrypto;
using Simplify.Extensions;

namespace JiraTimers.Settings
{
	public class SecuredSettings : JiraTimersSettings
	{
		private const string KeyFieldName = "CryptoKey";

		private readonly ISymmetricKeyAlgorithmProvider _provider;

		private readonly byte[] _keyMaterial;

		public SecuredSettings(IConfiguration configuration, ISymmetricKeyAlgorithmProvider provider) : base(configuration)
		{
			_provider = provider;
			_keyMaterial = LoadKey(configuration);
		}

		public override string? JiraUserPassword
		{
			get
			{
				var password = base.JiraUserPassword;

				return password != null ? Decrypt(DecodeBase64(password)) : null;
			}
			set => base.JiraUserPassword = value == null ? null : EncodeBase64(Encrypt(value));
		}

		private static byte[] LoadKey(IConfiguration configuration)
		{
			var keyString = configuration[KeyFieldName];

			if (keyString != null)
				return DecodeBase64(keyString).ToBytesArray();

			var key = Guid.NewGuid().ToByteArray();
			configuration[KeyFieldName] = EncodeBase64(key.GetString());

			return key;
		}

		private static string DecodeBase64(string str) => Encoding.UTF8.GetString(Convert.FromBase64String(str));

		private static string EncodeBase64(string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

		private string Encrypt(string str)
		{
			var key = _provider.CreateSymmetricKey(_keyMaterial);

			var cipherText = WinRTCrypto.CryptographicEngine.Encrypt(key, Encoding.UTF8.GetBytes(str));

			return cipherText.GetString();
		}

		private string Decrypt(string str)
		{
			var key = _provider.CreateSymmetricKey(_keyMaterial);

			var plainText = WinRTCrypto.CryptographicEngine.Decrypt(key, Encoding.UTF8.GetBytes(str));

			return plainText.GetString();
		}
	}
}