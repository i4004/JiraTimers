using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraItsClientFactory : IItsClientFactory
	{
		public IItsClient Create(string url, string userName, string userPassword)
		{
			return new JiraItsClient(Jira.CreateRestClient(url, userName, userPassword));
		}
	}
}