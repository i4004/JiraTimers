using System;
using System.Threading.Tasks;
using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraItsClient : IItsClient
	{
		private readonly Jira _client;
		private readonly JiraBasedItsIssuesFactory _issuesFactory;

		public JiraItsClient(Jira client, JiraBasedItsIssuesFactory issuesFactory)
		{
			_client = client;
			_issuesFactory = issuesFactory;
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

		public async Task<IItsIssue> GetIssue(string issueKey)
		{
			_client.Issues.MaxIssuesPerRequest = 10;
			var result = await _client.Issues.GetIssueAsync(issueKey);

			return result == null ? null : _issuesFactory.Create(result);
		}
	}
}