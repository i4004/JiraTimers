using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace JiraTimers.Settings
{
	public class JiraTimersConfigurationSource : JsonConfigurationSource
	{
		public JiraTimersConfigurationSource()
		{
			Optional = true;

			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);

			Path = System.IO.Path.Combine(appDataPath, "JiraTimers", "Settings.json");
		}

		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			EnsureDefaults(builder);

			return new WritableJsonConfigurationProvider(this);
		}
	}
}