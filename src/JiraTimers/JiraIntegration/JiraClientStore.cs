using System;
using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.Settings;

namespace JiraTimers.JiraIntegration
{
	public class JiraClientStore : IItsClientStore
	{
		private readonly ISettings _settings;

		public JiraClientStore(ISettings settings)
		{
			_settings = settings;
		}

		public Jira Client { get; private set; }

		public bool IsConnected => Client != null;

		public string CreateJiraClient()
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

		private static Tuple<Jira, string> CreateClient(string url, string userName, string userPassword)
		{
			try
			{
				var client = Jira.CreateRestClient(url, userName, userPassword);
				client.ServerInfo.GetServerInfoAsync().Wait();

				return new Tuple<Jira, string>(client, null);
			}
			catch (Exception e)
			{
				var message = e.Message.Contains("Unauthorized (401)") ? "Authentication error, check your login or password." : e.Message;

				Console.WriteLine(message);

				return new Tuple<Jira, string>(null, message);
			}
		}
	}
}