using Microsoft.Extensions.Configuration;

namespace JiraTimers.Settings
{
	public class SecuredSettings : WritableAutoUpdateSettings
	{
		public SecuredSettings(IConfiguration configuration) : base(configuration)
		{
		}
	}
}