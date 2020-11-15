using System;
using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesListController : IItsTrackingIssuesListController
	{
		private readonly IItsTrackingIssuesList _list;
		private readonly IItsClientStore _clientStore;

		public ItsTrackingIssuesListController(IItsTrackingIssuesList list, IItsClientStore clientStore)
		{
			_list = list;
			_clientStore = clientStore;
		}

		public void CreateNewIssue()
		{
			_list.AddItem(new ItsTrackingIssue(new ItsIssue
			{
				ID = Guid.NewGuid().ToString()
			}));
		}

		public async Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey)
		{
			var issue = await _clientStore.Client.GetIssueAsync(issueKey);

			if (_clientStore.Client.LastOperationStatus)
				_list.UpdateItem(issueID, issue);

			return _clientStore.Client.LastOperationStatus;
		}

		public void RemoveIssue(string issueID)
		{
			_list.RemoveItem(issueID);
		}
	}
}