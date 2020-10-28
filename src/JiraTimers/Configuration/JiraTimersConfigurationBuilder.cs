using System;
using JiraTimers.Configuration.Writable;
using Microsoft.Extensions.Configuration;

namespace JiraTimers.Configuration
{
	public static class JiraTimersConfigurationBuilder
	{
		private const string AppSettingsDirectoryName = nameof(JiraTimers);
		private const string AppSettingsFileName = "Settings.json";

		public static IConfigurationRoot Build()
		{
			var configurationBuilder = new ConfigurationBuilder();

			return configurationBuilder
				.Add(new WritableJsonConfigurationSource(GetAppSettingsDirectoryPath(), AppSettingsFileName)).Build();
		}

		private static string GetAppSettingsDirectoryPath()
		{
			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
			return System.IO.Path.Combine(appDataPath, AppSettingsDirectoryName);
		}
	}
}