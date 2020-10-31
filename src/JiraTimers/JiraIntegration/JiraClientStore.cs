using Atlassian.Jira;

namespace JiraTimers.JiraIntegration
{
	public class JiraClientStore
	{
		public Jira Client { get; private set; }

		public void CreateJiraClient(string url, string userName, string password)
		{
			Client = Jira.CreateRestClient(url, userName, password);
		}
	}
}