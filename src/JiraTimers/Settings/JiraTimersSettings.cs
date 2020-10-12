using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class JiraTimersSettings : IJiraTimersSettings
	{
		public JiraTimersSettings(IConfiguration configuration)
		{
			JiraBaseUrl = configuration[nameof(JiraBaseUrl)];
		}

		public string JiraBaseUrl { get; set; }
	}
}