using System.IO;
using JiraTimers.IO;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace JiraTimers.Configuration.Writable
{
	public class WritableJsonConfigurationProvider<T> : JsonConfigurationProvider
		where T : JsonConfigurationSource, IFilePathContainer
	{
		private readonly IFilePathContainer _container;

		public WritableJsonConfigurationProvider(T source) : base(source)
		{
			_container = source;
		}

		public override void Set(string key, string value)
		{
			base.Set(key, value);

			dynamic jsonObj = JsonConvert.DeserializeObject(ReadJson());
			jsonObj[key] = value;

			WriteJson(jsonObj);
		}

		private string ReadJson()
		{
			return File.ReadAllText(_container.FilePath);
		}

		private void WriteJson(dynamic jsonObj)
		{
			string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
			File.WriteAllText(_container.FilePath, output);
		}
	}
}