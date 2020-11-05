using System;
using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraItsClient : IItsClient
	{
		private readonly Jira _client;

		public JiraItsClient(Jira client)
		{
			_client = client;
		}

		public string CheckConnection()
		{
			try
			{
				_client.ServerInfo.GetServerInfoAsync().Wait();
			}
			catch (Exception e)
			{
				var message = e.Message.Contains("Unauthorized (401)") ? "Authentication error, check your login or password." : e.Message;

				Console.WriteLine(message);

				return message;
			}

			return null;
		}
	}
}