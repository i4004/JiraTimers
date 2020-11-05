using System;
using System.Threading.Tasks;
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

		public async Task<string> CheckConnectionAsync()
		{
			try
			{
				await _client.ServerInfo.GetServerInfoAsync();
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