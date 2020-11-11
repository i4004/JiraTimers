using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraBasedItsIssuesFactory
	{
		public IItsIssue Create(Issue sourceIssue)
		{
			return new ItsIssue
			{
				Key = sourceIssue.Key.Value,
				Summary = sourceIssue.Summary
			};
		}
	}
}