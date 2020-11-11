using System;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.DI
{
	public class JiraTimersLifeTimeScope : IDisposable
	{
		private readonly ILifetimeScope _scope;

		public JiraTimersLifeTimeScope()
		{
			_scope = DIContainer.Current.BeginLifetimeScope();
		}

		public void Dispose()
		{
			_scope.Dispose();
		}

		public ISettings GetSettings()
		{
			return _scope.Resolver.Resolve<ISettings>();
		}

		public IItsClientStore GetItsClientStore()
		{
			return _scope.Resolver.Resolve<IItsClientStore>();
		}

		public IItsTrackingIssuesList GetItsTrackingIssuesList()
		{
			return _scope.Resolver.Resolve<IItsTrackingIssuesList>();
		}
	}
}