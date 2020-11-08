using JiraTimers.Integrations.JiraIntegration;
using JiraTimers.IssueTrackingSystem;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class ItsRegistrations
	{
		public static IDIRegistrator RegisterIts(this IDIRegistrator registrator)
		{
			return
				registrator.Register<IItsClientFactory, JiraItsClientFactory>()
					.Register<ItsClientStore>()
					.Register<IItsClientStore>(r => r.Resolve<ItsClientStore>(), LifetimeType.Singleton)
					.Register<IItsTrackingIssuesList, ItsTrackingIssuesList>(LifetimeType.Singleton);
		}
	}
}