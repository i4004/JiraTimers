namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClientFactory
	{
		public IItsClient Create(string url, string userName, string userPassword);
	}
}