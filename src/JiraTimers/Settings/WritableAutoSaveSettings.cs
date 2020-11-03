using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class WritableAutoSaveSettings : ISettings
	{
		public WritableAutoSaveSettings(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public virtual string JiraBaseUrl
		{
			get => Configuration[nameof(JiraBaseUrl)];
			set => Configuration[nameof(JiraBaseUrl)] = value;
		}

		public virtual string JiraUserName
		{
			get => Configuration[nameof(JiraUserName)];
			set => Configuration[nameof(JiraUserName)] = value;
		}

		public virtual string JiraUserPassword
		{
			get => Configuration[nameof(JiraUserPassword)];
			set => Configuration[nameof(JiraUserPassword)] = value;
		}

		public virtual bool MinimizeToSystemTray
		{
			get => Configuration.GetValue<bool>(nameof(MinimizeToSystemTray));
			set => Configuration[nameof(MinimizeToSystemTray)] = value.ToString();
		}

		public virtual bool MinimizeOnClose
		{
			get => Configuration.GetValue<bool>(nameof(MinimizeOnClose));
			set => Configuration[nameof(MinimizeOnClose)] = value.ToString();
		}

		public bool IsDarkTheme
		{
			get => Configuration.GetValue<bool?>(nameof(IsDarkTheme)) ?? true;
			set => Configuration[nameof(IsDarkTheme)] = value.ToString();
		}

		protected IConfiguration Configuration { get; }
	}
}