using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class JiraTimersSettings : ISettings
	{
		public JiraTimersSettings(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public virtual string? JiraBaseUrl
		{
			get => Configuration[nameof(JiraBaseUrl)];
			set => Configuration[nameof(JiraBaseUrl)] = value;
		}

		public virtual string? JiraUserName
		{
			get => Configuration[nameof(JiraUserName)];
			set => Configuration[nameof(JiraUserName)] = value;
		}

		public virtual string? JiraUserPassword
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

		public bool SaveMainWindowPositionAndSize
		{
			get => Configuration.GetValue<bool?>(nameof(SaveMainWindowPositionAndSize)) ?? true;
			set => Configuration[nameof(SaveMainWindowPositionAndSize)] = value.ToString();
		}

		public int? MainWindowX
		{
			get => Configuration.GetValue<int?>(nameof(MainWindowX));
			set => Configuration[nameof(MainWindowX)] = value.ToString();
		}

		public int? MainWindowY
		{
			get => Configuration.GetValue<int?>(nameof(MainWindowY));
			set => Configuration[nameof(MainWindowY)] = value.ToString();
		}

		public int? MainWindowWidth
		{
			get => Configuration.GetValue<int?>(nameof(MainWindowWidth));
			set => Configuration[nameof(MainWindowWidth)] = value.ToString();
		}

		public int? MainWindowHeight
		{
			get => Configuration.GetValue<int?>(nameof(MainWindowHeight));
			set => Configuration[nameof(MainWindowHeight)] = value.ToString();
		}

		protected IConfiguration Configuration { get; }
	}
}