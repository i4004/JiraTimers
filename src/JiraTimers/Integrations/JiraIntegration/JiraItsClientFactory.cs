using System.Threading.Tasks;
using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraItsClientFactory : IItsClientFactory
	{
		private readonly JiraBasedItsIssuesFactory _issuesFactory;

		public JiraItsClientFactory(JiraBasedItsIssuesFactory issuesFactory)
		{
			_issuesFactory = issuesFactory;
		}

		public Task<IItsClient> CreateAsync(string url, string userName, string userPassword)
		{
			return Task.FromResult((IItsClient)new JiraItsClient(Jira.CreateRestClient(url, userName, userPassword), _issuesFactory));
		}
	}
}