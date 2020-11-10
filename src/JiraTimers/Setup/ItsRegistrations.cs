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
				registrator.Register<JiraBasedItsIssuesFactory>(LifetimeType.Singleton)
					.Register<IItsClientFactory, JiraItsClientFactory>(LifetimeType.Singleton)
					.Register<ItsClientStore>(LifetimeType.Singleton)
					.Register<IItsClientStore>(r => r.Resolve<ItsClientStore>(), LifetimeType.Singleton)
					.Register<IItsTrackingIssuesList, ItsTrackingIssuesList>(LifetimeType.Singleton);
		}
	}
}