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

		public void CreateNewIssue()
		{
			_list.AddItem(_issuesFactory.Create());
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