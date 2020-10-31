using System;
using Microsoft.Extensions.Configuration;
using PCLCrypto;
using Simplify.Extensions;

namespace JiraTimers.Settings
{
	public class SecuredSettings : WritableAutoSaveSettings
	{
		private const string KeyFieldName = "CryptoKey";

		private readonly ISymmetricKeyAlgorithmProvider _provider;

		private readonly byte[] _keyMaterial;

		public SecuredSettings(IConfiguration configuration, ISymmetricKeyAlgorithmProvider provider) : base(configuration)
		{
			_provider = provider;
			_keyMaterial = LoadKey(configuration);
		}

		public override string JiraUserPassword
		{
			get
			{
				var password = base.JiraUserPassword;

				return password != null ? Decrypt(password) : null;
			}
			set => base.JiraUserPassword = Encrypt(value);
		}

		private static byte[] LoadKey(IConfiguration configuration)
		{
			var keyString = configuration[KeyFieldName];

			if (keyString != null)
				return keyString.ToBytesArray();

			var key = Guid.NewGuid().ToByteArray();
			configuration[KeyFieldName] = key.GetString();

			return key;
		}

		private string Encrypt(string str)
		{
			var key = _provider.CreateSymmetricKey(_keyMaterial);

			var cipherText = WinRTCrypto.CryptographicEngine.Encrypt(key, str.ToBytesArray());

			return cipherText.GetString();
		}

		private string Decrypt(string str)
		{
			var key = _provider.CreateSymmetricKey(_keyMaterial);

			var plainText = WinRTCrypto.CryptographicEngine.Decrypt(key, str.ToBytesArray());

			return plainText.GetString();
		}
	}
}