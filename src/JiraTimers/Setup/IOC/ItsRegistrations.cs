using JiraTimers.Configuration;
using JiraTimers.Integrations.JiraIntegration;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.IssueTrackingSystem.Impl;
using JiraTimers.IssueTrackingSystem.Impl.Controllers;
using JiraTimers.IssueTrackingSystem.Impl.Qml;
using Simplify.DI;

namespace JiraTimers.Setup.IOC
{
	public static class ItsRegistrations
	{
		public static IDIRegistrator RegisterIts(this IDIRegistrator registrator)
		{
			registrator.Register<JiraBasedItsIssuesFactory>(LifetimeType.Singleton)
				.Register<IItsTrackingIssuesFactory, ItsTrackingIssuesFactory>(LifetimeType.Singleton);

			registrator.Register<IItsClientFactory, JiraItsClientFactory>(LifetimeType.Singleton)
				.Register<ItsClientStore>(LifetimeType.Singleton)
				.Register<IItsClientStore>(r => r.Resolve<ItsClientStore>(), LifetimeType.Singleton);

			registrator.Register<IItsTrackingIssuesList, ItsTrackingIssuesList>(LifetimeType.Singleton);

			registrator.Register<IItsIssuesStore>(r => new FileBasedItsIssuesStore(JiraTimersPaths.GetIssuesSettingsFilePath()),
				LifetimeType.Singleton);

			registrator.Register<ItsTrackingIssuesListController>(LifetimeType.Singleton)
				.Register<IItsTrackingIssuesListController>(
					r => new StateHandlingController(r.Resolve<ItsTrackingIssuesListController>(), r.Resolve<IItsTrackingIssuesList>(),
						r.Resolve<IItsIssuesStore>()), LifetimeType.Singleton);

			return registrator;
		}
	}
}