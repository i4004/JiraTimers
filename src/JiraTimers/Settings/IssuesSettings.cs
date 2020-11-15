using System.Collections.Generic;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Settings
{
	public class IssuesSettings : IIssuesSettings
	{
		private readonly string _settingsFilePath;

		public IssuesSettings(string settingsFilePath)
		{
			_settingsFilePath = settingsFilePath;
		}

		public IList<IItsTrackingIssue> Load()
		{
			throw new System.NotImplementedException();
		}

		public void Save(IList<IItsTrackingIssue> items)
		{
			throw new System.NotImplementedException();
		}
	}
}