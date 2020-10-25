using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace JiraTimers.Settings
{
	public class JiraTimersConfigurationSource : JsonConfigurationSource
	{
		private const string AppSettingsFolderName = "JiraTimers";

		public JiraTimersConfigurationSource()
		{
			Optional = true;

			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);

			Path = System.IO.Path.Combine(appDataPath, AppSettingsFolderName, "Settings.json");

			CreateAppSettingsFileIfNotExists(appDataPath);
		}

		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			EnsureDefaults(builder);

			return new WritableJsonConfigurationProvider(this);
		}

		private void CreateAppSettingsFileIfNotExists()
		{
			if (!File.Exists(Path))
				File.AppendAllText(Path, null, Encoding.UTF8);
		}
	}
}