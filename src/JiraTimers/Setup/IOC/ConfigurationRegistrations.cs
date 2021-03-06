using System;
using JiraTimers.Configuration;
using Microsoft.Extensions.Configuration;
using Simplify.DI;

namespace JiraTimers.Setup.IOC
{
	public static class ConfigurationRegistrations
	{
		public static IDIRegistrator RegisterConfiguration(this IDIRegistrator registrator, Action<IConfiguration>? config = null)
		{
			var configuration = JiraTimersConfigurationBuilder.Build();

			registrator.Register<IConfiguration>(p => configuration, LifetimeType.Singleton);

			config?.Invoke(configuration);

			return registrator;
		}
	}
}