using System;
using Simplify.DI;

namespace JiraTimers.DI
{
	public class DiScope : IDisposable
	{
		public DiScope()
		{
			Scope = DIContainer.Current.BeginLifetimeScope();
		}

		public ILifetimeScope Scope { get; }

		public void Dispose()
		{
			Scope.Dispose();
		}
	}
}