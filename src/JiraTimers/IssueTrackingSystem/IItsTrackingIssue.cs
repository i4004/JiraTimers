namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssue
	{
		public string Name { get; }
		public string Time { get; }
		public string Description { get; }
	}
}