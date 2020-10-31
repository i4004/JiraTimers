using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class SecuredSettings : WritableAutoSaveSettings
	{
		public SecuredSettings(IConfiguration configuration) : base(configuration)
		{
		}
	}
}