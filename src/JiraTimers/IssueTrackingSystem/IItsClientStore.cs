namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClientStore
	{
		public string TestConnection(string url, string userName, string password);
	}
}