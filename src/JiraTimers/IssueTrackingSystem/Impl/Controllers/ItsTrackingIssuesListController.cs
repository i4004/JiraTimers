using System;
using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem.Impl.Controllers
{
	public class ItsTrackingIssuesListController : IItsTrackingIssuesListController
	{
		private readonly IItsTrackingIssuesList _list;
		private readonly IItsTrackingIssuesFactory _issuesFactory;
		private readonly IItsClientStore _clientStore;

		public ItsTrackingIssuesListController(IItsTrackingIssuesList list, IItsTrackingIssuesFactory issuesFactory, IItsClientStore clientStore)
		{
			_list = list;
			_issuesFactory = issuesFactory;
			_clientStore = clientStore;
		}

		public void CreateNewIssue() => _list.AddItem(_issuesFactory.Create());

		public async Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey)
		{
			if (_clientStore.Client == null)
				throw new InvalidOperationException("Client is null");

			var issue = await _clientStore.Client.GetIssueAsync(issueKey);

			if (issue != null)
				_list.UpdateItem(issueID, issue);

			return issue != null;
		}

		public void RemoveIssue(string issueID) => _list.RemoveItem(issueID);

		public void StartIssueTimer(string issueID) => _list.GetIssueByID(issueID).StartTimer();

		public void StopIssueTimer(string issueID) => _list.GetIssueByID(issueID).StopTimer();

		public void ResetIssueTimer(string issueID) => _list.GetIssueByID(issueID).ResetTimer();

		public async Task<bool> LogWork(string issueID, IWorkLog workLog)
		{
			if (_clientStore.Client == null)
				throw new InvalidOperationException("Client is null");

			var issue = _list.GetIssueByID(issueID);

			if (issue.Issue?.Key == null)
				throw new InvalidOperationException("Issue key is null");

			return await _clientStore.Client.LogWork(issue.Issue.Key, workLog);
		}
	}
}