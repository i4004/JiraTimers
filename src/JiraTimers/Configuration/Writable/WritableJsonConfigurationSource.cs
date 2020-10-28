using System.IO;
using System.Text;
using JiraTimers.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace JiraTimers.Configuration.Writable
{
	public class WritableJsonConfigurationSource : JsonConfigurationSource, IFilePathContainer
	{
		private readonly string _appSettingsDirectoryPath;

		public WritableJsonConfigurationSource(string appSettingsDirectoryPath, string appSettingsFileName)
		{
			_appSettingsDirectoryPath = appSettingsDirectoryPath;
			FilePath = System.IO.Path.Combine(_appSettingsDirectoryPath, appSettingsFileName);
			Path = appSettingsFileName;

			FileProvider = new PhysicalFileProvider(_appSettingsDirectoryPath);

			CreateAppSettingsDirectoryIfNotExists();
			CreateAppSettingsFileIfNotExists();
		}

		public string FilePath { get; }

		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			EnsureDefaults(builder);

			return new WritableJsonConfigurationProvider<WritableJsonConfigurationSource>(this);
		}

		private void CreateAppSettingsDirectoryIfNotExists()
		{
			if (!Directory.Exists(_appSettingsDirectoryPath))
				Directory.CreateDirectory(_appSettingsDirectoryPath);
		}

		private void CreateAppSettingsFileIfNotExists()
		{
			if (!File.Exists(FilePath))
				File.AppendAllText(FilePath, "{}", Encoding.UTF8);
		}
	}
}