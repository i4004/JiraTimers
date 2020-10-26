using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class JiraTimersSettings : IJiraTimersSettings
	{
		private readonly IConfiguration _configuration;

		public JiraTimersSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string JiraBaseUrl
		{
			get => _configuration[nameof(JiraBaseUrl)];
			set => _configuration[nameof(JiraBaseUrl)] = value;
		}
	}
}