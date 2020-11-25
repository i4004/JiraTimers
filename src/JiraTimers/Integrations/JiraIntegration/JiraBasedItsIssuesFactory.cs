using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.IssueTrackingSystem.Impl.Qml;

namespace JiraTimers.Integrations.JiraIntegration
{
	public class JiraBasedItsIssuesFactory
	{
		public IItsIssue Create(Issue sourceIssue) =>
			new ItsIssue
			{
				Key = sourceIssue.Key.Value,
				Summary = sourceIssue.Summary,
				Assignee = sourceIssue.Assignee
			};
	}
}