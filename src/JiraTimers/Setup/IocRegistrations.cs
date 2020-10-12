using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class IocRegistrations
	{
		public static IDIContainerProvider RegisterJiraTimers(this IDIContainerProvider container)
		{
			return container;
		}
	}
}