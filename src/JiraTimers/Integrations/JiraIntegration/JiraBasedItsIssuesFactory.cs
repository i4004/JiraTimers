using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.IssueTrackingSystem.Impl.Qml;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraBasedItsIssuesFactory
	{
		public IItsIssue Create(Issue sourceIssue)
		{
			return new QmlItsIssue
			{
				Key = sourceIssue.Key.Value,
				Summary = sourceIssue.Summary
			};
		}
	}
}