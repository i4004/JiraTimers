using System.IO;
using System;
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
			// IOC container setup
			DIContainer.Current.RegisterJiraTimers().Verify();

			// QT setup
			RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();

			// UI setup

			QGuiApplication.SetAttribute(ApplicationAttribute.EnableHighDpiScaling, true);
			QQuickStyle.SetStyle("Material");
			RegisterTheme();

			// Launch

			using var application = new QGuiApplication(args);
			using var qmlEngine = new QQmlApplicationEngine();

			qmlEngine.Load("Qml/Main.qml");

			return application.Exec();
		}

		private static void RegisterTheme()
		{
			var filePath = "file:///" + Directory.GetCurrentDirectory().Replace("\\", "/") + "/Qml/Theme.qml";
			Qml.Net.Qml.RegisterSingletonType(filePath, "Theme", "jira.timers.theme");
		}
	}
}