using System;
using JiraTimers.Settings;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsClientStore : IItsClientStore
	{
		private readonly ISettings _settings;
		private readonly IItsClientFactory _clientFactory;

		private IItsClient _client;
		private bool _isConnected;

		public ItsClientStore(ISettings settings, IItsClientFactory clientFactory)
		{
			_settings = settings;
			_clientFactory = clientFactory;
		}

		public IItsClient Client
		{
			get => _client;
			private set
			{
				_client = value;

				IsConnected = _client != null;
			}
		}

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

		public bool ReadyToConnect()
		{
			return _settings.JiraBaseUrl != null && _settings.JiraUserName != null && _settings.JiraUserPassword != null;
		}

		public string TryCreateItsClient()
		{
			var (client, result) = CreateClient(_settings.JiraBaseUrl, _settings.JiraUserName, _settings.JiraUserPassword);

			if (client != null)
				Client = client;

			return result;
		}

		public string TestConnection(string url, string userName, string userPassword)
		{
			var (_, result) = CreateClient(url, userName, userPassword);

			return result;
		}

		private Tuple<IItsClient, string> CreateClient(string url, string userName, string userPassword)
		{
			var client = _clientFactory.Create(url, userName, userPassword);
			var result = client.CheckConnection();

			return new Tuple<IItsClient, string>(result != null ? client : null, result);
		}
	}
}