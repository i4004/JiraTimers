using JiraTimers.Configuration;
using JiraTimers.Integrations.JiraIntegration;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.IssueTrackingSystem.Impl;
using JiraTimers.IssueTrackingSystem.Impl.Qml;
using Simplify.DI;

namespace JiraTimers.Setup.IOC
{
	public static class ItsRegistrations
	{
		public static IDIRegistrator RegisterIts(this IDIRegistrator registrator)
		{
			return
				registrator.Register<JiraBasedItsIssuesFactory>(LifetimeType.Singleton)
					.Register<IItsClientFactory, JiraItsClientFactory>(LifetimeType.Singleton)
					.Register<QmlItsClientStore>(LifetimeType.Singleton)
					.Register<IItsClientStore>(r => r.Resolve<QmlItsClientStore>(), LifetimeType.Singleton)
					.Register<IItsTrackingIssuesList, ItsTrackingIssuesList>(LifetimeType.Singleton)
					.Register<IItsTrackingIssuesListController, QmlItsTrackingIssuesListController>(LifetimeType.Singleton)
					.Register<IItsIssuesStore>(r => new FileBasedItsIssuesStore(JiraTimersPaths.GetIssuesSettingsFilePath()), LifetimeType.Singleton);
		}
	}
}