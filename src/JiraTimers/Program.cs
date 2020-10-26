using System;
using System.IO;
using JiraTimers.Setup;
using Qml.Net;
using Qml.Net.Runtimes;
using Simplify.DI;

namespace JiraTimers
{
	public static class Program
	{
		[STAThread]
		public static int Main(string[] args)
		{
			DIContainer.Current.RegisterJiraTimers(args).Verify();

			SetupQT();

			return LaunchApp();
		}

		private static int LaunchApp()
		{
			using var scope = DIContainer.Current.BeginLifetimeScope();

			var app = scope.Resolver.Resolve<QGuiApplication>();

			scope.Resolver.Resolve<QQmlApplicationEngine>().Load("Qml/Main.qml");

			return app.Exec();
		}

		private static void SetupQT()
		{
			RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();

			SetupUI();
		}

		private static void SetupUI()
		{
			QCoreApplication.SetAttribute(ApplicationAttribute.EnableHighDpiScaling, true);
			QQuickStyle.SetStyle("Material");

			RegisterTheme();
		}

		private static void RegisterTheme()
		{
			var filePath = "file:///" + Directory.GetCurrentDirectory().Replace("\\", "/") + "/Qml/Theme.qml";
			Qml.Net.Qml.RegisterSingletonType(filePath, "Theme", "jira.timers.theme");
		}
	}
}