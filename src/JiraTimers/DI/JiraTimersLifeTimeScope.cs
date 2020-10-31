using System;
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
	}
}