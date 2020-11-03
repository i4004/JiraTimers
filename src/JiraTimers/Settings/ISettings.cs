namespace JiraTimers.Settings
{
	public interface ISettings
	{
		public string JiraBaseUrl { get; }
		public string JiraUserName { get; }
		public string JiraUserPassword { get; }

		public bool MinimizeToSystemTray { get; }
		public bool MinimizeOnClose { get; }

		public bool IsDarkTheme { get; }
	}
}