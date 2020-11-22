using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.Setup.IOC
{
	public static class SettingsRegistrations
	{
		public static IDIRegistrator RegisterJiraTimersSettings(this IDIRegistrator registrator) =>
			registrator.Register<CacheableSettings>(LifetimeType.Singleton)
				.Register<ISettings>(r => r.Resolve<CacheableSettings>(), LifetimeType.Singleton);
	}
}