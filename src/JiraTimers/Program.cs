using System;
using JiraTimers.Setup.IOC;
using JiraTimers.Setup.Qml;
using JiraTimers.Setup.QT;
using Qml.Net;
using Simplify.DI;

namespace JiraTimers
{
	public static class Program
	{
		private const string StartupQmlFilePath = "UI/Main.qml";

		[STAThread]
		public static int Main(string[] args)
		{
			DIContainer.Current
				.RegisterJiraTimers(args)
				.Verify();

			QtRuntime.Setup();
			NetTypesToQml.Register();
			QtUI.Setup();

			return LaunchApp();
		}

		private static int LaunchApp()
		{
			using var scope = DIContainer.Current.BeginLifetimeScope();

			var app = scope.Resolver.Resolve<QGuiApplication>();
			var engine = scope.Resolver.Resolve<QQmlApplicationEngine>();

			engine.Load(StartupQmlFilePath);

			return app.Exec();
		}
	}
}