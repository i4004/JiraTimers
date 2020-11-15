using JiraTimers.Configuration.Writable;
using Microsoft.Extensions.Configuration;

namespace JiraTimers.Configuration
{
	public static class JiraTimersConfigurationBuilder
	{

		public static IConfigurationRoot Build()
		{
			var configurationBuilder = new ConfigurationBuilder();

			return configurationBuilder
				.Add(new WritableJsonConfigurationSource(JiraTimersPaths.GetAppSettingsDirectoryPath(), JiraTimersPaths.AppSettingsFileName)).Build();
		}
	}
}