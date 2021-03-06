﻿using System;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.Settings;
using Simplify.DI;

namespace JiraTimers.DI
{
	public class JiraTimersLifeTimeScope : IDisposable
	{
		private readonly ILifetimeScope _scope;

		public JiraTimersLifeTimeScope() => _scope = DIContainer.Current.BeginLifetimeScope();

		public void Dispose() => _scope.Dispose();

		public ISettings GetSettings() => _scope.Resolver.Resolve<ISettings>();

		public IItsClientStore GetItsClientStore() => _scope.Resolver.Resolve<IItsClientStore>();

		public IItsTrackingIssuesList GetItsTrackingIssuesList() => _scope.Resolver.Resolve<IItsTrackingIssuesList>();

		public IItsTrackingIssuesListController GetItsTrackingIssuesListController() => _scope.Resolver.Resolve<IItsTrackingIssuesListController>();
	}
}