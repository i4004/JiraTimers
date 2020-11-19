namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsIssue
	{
		public string? ID { get; }

		public string? Key { get; set; }

		public string? Summary { get; set; }
	}
}