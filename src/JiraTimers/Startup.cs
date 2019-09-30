using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Simplify.Web.Owin;

namespace JiraTimers
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseSimplifyWeb();

			Bootstrap();
		}

		public async void Bootstrap()
		{
			var options = new BrowserWindowOptions
			{
				WebPreferences = new WebPreferences
				{
					WebSecurity = false
				}
			};

			await Electron.WindowManager.CreateWindowAsync(options);
		}
	}
}