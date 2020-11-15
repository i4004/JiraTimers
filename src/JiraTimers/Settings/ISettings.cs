using System.Collections.Generic;
using JiraTimers.IssueTrackingSystem;

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

		public bool SaveMainWindowPositionAndSize { get; }

		public int? MainWindowX { get; }
		public int? MainWindowY { get; }
		public int? MainWindowWidth { get; }
		public int? MainWindowHeight { get; }

		public IList<IItsTrackingIssue> Issues { get; }
	}
}