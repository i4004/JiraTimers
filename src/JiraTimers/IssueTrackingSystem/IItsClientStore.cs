namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClientStore
	{
		public bool IsConnected { get; }

		public bool ReadyToConnect();

		public string TryCreateItsClient();

		public string TestConnection(string url, string userName, string userPassword);
	}
}