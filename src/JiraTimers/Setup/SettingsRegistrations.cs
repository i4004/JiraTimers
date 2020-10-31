using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class SettingsRegistrations
	{
		public static IDIRegistrator RegisterJiraTimersSettings(this IDIRegistrator registrator)
		{
			return registrator.Register<CacheableSettings>(LifetimeType.Singleton)
				.Register<ISettings>(r => r.Resolve<CacheableSettings>(), LifetimeType.Singleton);
		}
	}
}