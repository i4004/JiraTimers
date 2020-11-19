using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using JiraTimers.IssueTrackingSystem.Impl.Qml;
using Newtonsoft.Json;

namespace JiraTimers.IssueTrackingSystem.Impl
{
	public class FileBasedItsIssuesStore : IItsIssuesStore
	{
		private static IFileSystem? _fileSystem;

		private readonly string _settingsFilePath;

		public FileBasedItsIssuesStore(string settingsFilePath)
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
			CreateStoreFileIfNotExists();

			var result = JsonConvert.DeserializeObject<List<QmlItsTrackingIssue>>(ReadJson());

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
			FileSystem.File.WriteAllText(_settingsFilePath, JsonConvert.SerializeObject(items), Encoding.UTF8);
		}

		private void CreateStoreFileIfNotExists()
		{
			if (!FileSystem.File.Exists(_settingsFilePath))
				FileSystem.File.AppendAllText(_settingsFilePath, "[]", Encoding.UTF8);
		}
	}
}