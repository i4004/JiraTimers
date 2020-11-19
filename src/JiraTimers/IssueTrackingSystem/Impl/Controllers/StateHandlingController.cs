using System;
using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem.Impl.Controllers
{
	public class StateHandlingController : IItsTrackingIssuesListController, IDisposable
	{
		private readonly IItsTrackingIssuesListController _baseController;
		private readonly IItsTrackingIssuesList _list;
		private readonly IItsIssuesStore _issuesStore;

		public StateHandlingController(IItsTrackingIssuesListController baseController, IItsTrackingIssuesList list, IItsIssuesStore issuesStore)
		{
			_baseController = baseController;
			_list = list;
			_issuesStore = issuesStore;

			LoadList();
		}

		public void CreateNewIssue()
		{
			_baseController.CreateNewIssue();
		}

		public async Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey)
		{
			var result = await _baseController.RefreshIssueInfoAsync(issueID, issueKey);

			if (result)
				SaveList();

			return result;
		}

		public void RemoveIssue(string issueID)
		{
			_baseController.RemoveIssue(issueID);

			SaveList();
		}

		public void StartIssueTimer(string issueID)
		{
			_baseController.StartIssueTimer(issueID);

			SaveList();
		}

		public void StopIssueTimer(string issueID)
		{
			_baseController.StopIssueTimer(issueID);

			SaveList();
		}

		public void ResetIssueTimer(string issueID)
		{
			_baseController.ResetIssueTimer(issueID);

			SaveList();
		}

		public void Dispose()
		{
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