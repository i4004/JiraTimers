namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsIssue
	{
		public string ID { get; }

		public string Key { get; }

		public string Summary { get; }
	}
}