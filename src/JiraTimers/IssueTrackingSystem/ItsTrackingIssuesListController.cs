using System;
using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesListController : IItsTrackingIssuesListController
	{
		private readonly IItsTrackingIssuesList _list;
		private readonly IItsClientStore _clientStore;
		private readonly IItsIssuesStore _issuesStore;

		public ItsTrackingIssuesListController(IItsTrackingIssuesList list, IItsClientStore clientStore, IItsIssuesStore issuesStore)
		{
			_list = list;
			_clientStore = clientStore;
			_issuesStore = issuesStore;

			LoadList();
		}

		public void CreateNewIssue()
		{
			_list.AddItem(new ItsTrackingIssue
			{
				Issue = new ItsIssue
				{
					ID = Guid.NewGuid().ToString()
				}
			});
		}

		public async Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey)
		{
			var issue = await _clientStore.Client.GetIssueAsync(issueKey);

			if (_clientStore.Client.LastOperationStatus)
			{
				_list.UpdateItem(issueID, issue);

				SaveList();
			}

			return _clientStore.Client.LastOperationStatus;
		}

		public void RemoveIssue(string issueID)
		{
			_list.RemoveItem(issueID);

			SaveList();
		}

		private void LoadList()
		{
			_list.Items.Clear();

			var issues = _issuesStore.Load();

			foreach (var item in issues)
				_list.Items.Add(item);
		}

		private void SaveList()
		{
			_issuesStore.Save(_list.Items);
		}
	}
}