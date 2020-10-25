using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace JiraTimers.Settings
{
	public class WritableJsonConfigurationProvider : JsonConfigurationProvider
	{
		public WritableJsonConfigurationProvider(JsonConfigurationSource source) : base(source)
		{
			FullFilePath = Source.FileProvider.GetFileInfo(source.Path).PhysicalPath;
		}

		public string FullFilePath { get; }

		public override void Set(string key, string value)
		{
			base.Set(key, value);

			dynamic jsonObj = JsonConvert.DeserializeObject(ReadJson());
			jsonObj[key] = value;

			WriteJson(jsonObj);
		}

		private string ReadJson()
		{
			return File.ReadAllText(FullFilePath);
		}

		private void WriteJson(dynamic jsonObj)
		{
			string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
			File.WriteAllText(FullFilePath, output);
		}
	}
}