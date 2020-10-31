using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class CacheableSettings : SecuredSettings
	{
		private string _jiraBaseUrl;
		private string _jiraUserName;
		private string _jiraUserPassword;
		private bool? _minimizeToSystemTray;
		private bool? _minimizeOnClose;

		public CacheableSettings(IConfiguration configuration) : base(configuration)
		{
		}

		public override string JiraBaseUrl
		{
			get => _jiraBaseUrl ??= base.JiraBaseUrl;
			set => base.JiraBaseUrl = _jiraBaseUrl = value;
		}

		public override string JiraUserName
		{
			get => _jiraUserName ??= base.JiraUserName;
			set => base.JiraUserName = _jiraUserName = value;
		}

		public override string JiraUserPassword
		{
			get => _jiraUserPassword ??= base.JiraUserPassword;
			set => base.JiraUserPassword = _jiraUserPassword = value;
		}

		public override bool MinimizeToSystemTray
		{
			get => _minimizeToSystemTray ??= base.MinimizeToSystemTray;
			set
			{
				_minimizeToSystemTray = value;
				base.MinimizeToSystemTray = value;
			}
		}

		public override bool MinimizeOnClose
		{
			get => _minimizeOnClose ??= base.MinimizeOnClose;
			set
			{
				_minimizeOnClose = value;
				base.MinimizeOnClose = value;
			}
		}
	}
}