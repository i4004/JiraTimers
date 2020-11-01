using JiraTimers.IssueTrackingSystem;
using JiraTimers.JiraIntegration;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class JiraRegistrations
	{
		public static IDIRegistrator RegisterJira(this IDIRegistrator registrator)
		{
			return registrator.Register<JiraClientStore>()
				.Register<IItsClientStore>(r => r.Resolve<JiraClientStore>(), LifetimeType.Singleton);
		}
	}
}