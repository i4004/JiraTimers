using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class JiraSettingsRegistrations
	{
		public static IDIRegistrator RegisterJiraTimersSettings(this IDIRegistrator registrator)
		{
			return registrator.Register<JiraTimersSettings>(LifetimeType.Singleton)
				.Register<IJiraTimersSettings>(r => r.Resolve<JiraTimersSettings>(), LifetimeType.Singleton);
		}
	}
}