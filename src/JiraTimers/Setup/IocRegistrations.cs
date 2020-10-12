using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class IocRegistrations
	{
		public static IDIContainerProvider RegisterJiraTimers(this IDIContainerProvider container)
		{
			container.RegisterConfiguration()
				.RegisterJira()
				.Register<JiraTimersSettings>(LifetimeType.Singleton)
				.Register<IJiraTimersSettings>(r => r.Resolve<JiraTimersSettings>(), LifetimeType.Singleton);

			return container;
		}
	}
}