using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.Setup.IOC
{
	public static class IocRegistrations
	{
		public static IDIContainerProvider RegisterJiraTimers(this IDIContainerProvider container, string[] args)
		{
			container.RegisterConfiguration()
				.RegisterIts()
				.RegisterQt(args)
				.RegisterCryptography()
				.RegisterJiraTimersSettings();

			return container;
		}
	}
}