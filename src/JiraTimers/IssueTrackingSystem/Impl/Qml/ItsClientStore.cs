using System;
using System.Threading.Tasks;
using JiraTimers.Settings;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class ItsClientStore : IItsClientStore
	{
		private readonly ISettings _settings;
		private readonly IItsClientFactory _clientFactory;

		private bool _isConnected;

		public ItsClientStore(ISettings settings, IItsClientFactory clientFactory)
		{
			_settings = settings;
			_clientFactory = clientFactory;
		}

		[NotifySignal]
		public IItsClient? Client { get; private set; }

		[NotifySignal]
		public bool IsConnected
		{
			get => _isConnected;
			private set
			{
				if (_isConnected != value)
					this.ActivateSignal("isConnectedChanged", value);

				_isConnected = value;
			}
		}

		public bool ReadyToCreate()
		{
			return !string.IsNullOrEmpty(_settings.JiraBaseUrl) && !string.IsNullOrEmpty(_settings.JiraUserName) && !string.IsNullOrEmpty(_settings.JiraUserPassword);
		}

		public async Task<string?> TryCreateItsClientAsync()
		{
			if (_settings.JiraBaseUrl == null)
				throw new ArgumentNullException(nameof(_settings.JiraBaseUrl));

			if (_settings.JiraUserName == null)
				throw new ArgumentNullException(nameof(_settings.JiraUserName));

			if (_settings.JiraUserPassword == null)
				throw new ArgumentNullException(nameof(_settings.JiraUserPassword));

			var (client, result) = await CreateClientAsync(_settings.JiraBaseUrl, _settings.JiraUserName, _settings.JiraUserPassword);

			if (client == null)
				return result;

			Client = client;
			IsConnected = true;

			return result;
		}

		public async Task<string?> TestConnectionAsync(string url, string userName, string userPassword)
		{
			var (_, result) = await CreateClientAsync(url, userName, userPassword);

			return result;
		}

		private async Task<Tuple<IItsClient?, string?>> CreateClientAsync(string url, string userName, string userPassword)
		{
			var client = await _clientFactory.CreateAsync(url, userName, userPassword);
			var result = await client.CheckConnectionAsync();

			return new Tuple<IItsClient?, string?>(result == null ? client : null, result);
		}
	}
}