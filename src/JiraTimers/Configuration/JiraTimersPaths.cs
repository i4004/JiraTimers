using System;

namespace JiraTimers.Configuration
{
	public static class JiraTimersPaths
	{
		public const string AppSettingsFileName = "Settings.json";

		private const string AppSettingsDirectoryName = nameof(JiraTimers);

		private const string IssuesSettingsFileName = "Issues.json";

		public static string GetAppSettingsDirectoryPath()
		{
			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
			return System.IO.Path.Combine(appDataPath, AppSettingsDirectoryName);
		}

		public static string GetIssuesSettingsFilePath()
		{
			return System.IO.Path.Combine(GetAppSettingsDirectoryPath(), IssuesSettingsFileName);
		}
	}
}