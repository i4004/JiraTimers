using System;
using System.IO;
using JiraTimers.DI;
using JiraTimers.Setup;
using Qml.Net;
using Qml.Net.Runtimes;
using Simplify.DI;

namespace JiraTimers
{
	public static class Program
	{
		private const string StartupQmlFilePath = "Qml/Main.qml";

		[STAThread]
		public static int Main(string[] args)
		{
			DIContainer.Current.RegisterJiraTimers(args).Verify();

			SetupQT();
			SetupUI();
			RegisterQmlTypes();

			return LaunchApp();
		}

		private static void SetupQT()
		{
			Console.WriteLine("Checking and downloading QT runtime if not installed...");

			RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();

			Console.WriteLine("QT runtime is OK.");
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
			filePath = filePath.Replace("////", "///");

			Qml.Net.Qml.RegisterSingletonType(filePath, "Theme", "jira.timers.theme");
		}

		private static void RegisterQmlTypes()
		{
			Qml.Net.Qml.RegisterType<JiraTimersLifeTimeScope>(nameof(JiraTimers) + ".Net.Components");
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