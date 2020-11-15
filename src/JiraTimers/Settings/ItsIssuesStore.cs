using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using JiraTimers.IssueTrackingSystem;
using Newtonsoft.Json;

namespace JiraTimers.Settings
{
	public class ItsIssuesStore : IItsIssuesStore
	{
		private static IFileSystem _fileSystem;

		private readonly string _settingsFilePath;

		public ItsIssuesStore(string settingsFilePath)
		{
			_settingsFilePath = settingsFilePath;
		}

		public static IFileSystem FileSystem
		{
			get => _fileSystem ?? new FileSystem();
			set => _fileSystem = value ?? throw new ArgumentNullException(nameof(value));
		}

		public IList<IItsTrackingIssue> Load()
		{
			var result = JsonConvert.DeserializeObject<List<ItsTrackingIssue>>(ReadJson());

			return result.Cast<IItsTrackingIssue>().ToList();
		}

		public void Save(IList<IItsTrackingIssue> items)
		{
			WriteJson(items);
		}

		private string ReadJson()
		{
			return FileSystem.File.ReadAllText(_settingsFilePath, Encoding.UTF8);
		}

		private void WriteJson(IList<IItsTrackingIssue> items)
		{
			FileSystem.File.WriteAllText(_settingsFilePath, JsonConvert.SerializeObject(items, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			}
			), Encoding.UTF8);
		}
	}
}