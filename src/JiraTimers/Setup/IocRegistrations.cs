using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class IocRegistrations
	{
		public static IDIContainerProvider RegisterJiraTimers(this IDIContainerProvider container)
		{
			container.RegisterConfiguration();

			return container;
		}

	}
}