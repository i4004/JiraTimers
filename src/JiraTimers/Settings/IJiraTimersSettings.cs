namespace JiraTimers.Settings
{
	public interface IJiraTimersSettings
	{
		public string JiraBaseUrl { get; }
		public string JiraUserName { get; }
		public string JiraUserPassword { get; }
	}
}