using System;
using System.Threading.Tasks;
using Atlassian.Jira;
using Atlassian.Jira.Remote;
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

			_client.Issues.MaxIssuesPerRequest = 10;
		}

		public bool LastOperationStatus { get; private set; }

		public string? LastOperationResult { get; private set; }

		public async Task<string?> CheckConnectionAsync()
		{
			try
			{
				await _client.ServerInfo.GetServerInfoAsync();
			}
			catch (Exception e) when (e.Message.Contains("Unauthorized (401)"))
			{
				return "Authentication error, check your login or password.";
			}
			catch (Exception e)
			{
				return e.Message;
			}

			return null;
		}

		public async Task<IItsIssue?> GetIssueAsync(string issueKey)
		{
			LastOperationResult = null;
			LastOperationStatus = false;

			try
			{
				var result = await _client.Issues.GetIssueAsync(issueKey);

				LastOperationStatus = true;

				return _issuesFactory.Create(result);
			}
			catch (ResourceNotFoundException e) when (e.Message.Contains("Issue Does Not Exist"))
			{
				LastOperationResult = "Issue does not exist.";
			}
			catch (Exception e)
			{
				LastOperationResult = e.Message;
			}

			return null;
		}

		public Task LogWork(string issueKey)
		{
			throw new NotImplementedException();
		}
	}
}