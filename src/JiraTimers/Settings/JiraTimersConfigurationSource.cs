using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace JiraTimers.Settings
{
	public class JiraTimersConfigurationSource : JsonConfigurationSource
	{
		private const string AppSettingsDirectoryName = "JiraTimers";
		private const string AppSettingsFileName = "Settings.json";

		private string _appSettingsDirectoryPath;

		public JiraTimersConfigurationSource()
		{
			Optional = true;

			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);

			_appSettingsDirectoryPath = System.IO.Path.Combine(appDataPath, AppSettingsDirectoryName);
			Path = System.IO.Path.Combine(_appSettingsDirectoryPath, AppSettingsFileName);

			CreateAppSettingsDirectoryIfNotExists();
			CreateAppSettingsFileIfNotExists();
		}

		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			EnsureDefaults(builder);

			return new WritableJsonConfigurationProvider(this);
		}

		private void CreateAppSettingsDirectoryIfNotExists()
		{
			if (!Directory.Exists(_appSettingsDirectoryPath))
				Directory.CreateDirectory(_appSettingsDirectoryPath);
		}

		private void CreateAppSettingsFileIfNotExists()
		{
			if (!File.Exists(Path))
				File.AppendAllText(Path, "{}", Encoding.UTF8);
		}
	}
}