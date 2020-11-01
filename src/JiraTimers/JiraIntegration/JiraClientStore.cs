using System;
using Atlassian.Jira;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.JiraIntegration
{
	public class JiraClientStore : IItsClientStore
	{
		public Jira Client { get; private set; }

		public void CreateJiraClient(string url, string userName, string password)
		{
			Client = Jira.CreateRestClient(url, userName, password);
		}

		public string TestConnection(string url, string userName, string password)
		{
			try
			{
				var client = Jira.CreateRestClient(url, userName, password);
				client.ServerInfo.GetServerInfoAsync().Wait();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}

			return null;
		}
	}
}