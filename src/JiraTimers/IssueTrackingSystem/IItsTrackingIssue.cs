namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssue
	{
		public IItsIssue Issue { get; }

		public string Time { get; }
	}
}