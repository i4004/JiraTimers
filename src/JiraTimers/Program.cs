﻿using Qml.Net;
using Qml.Net.Runtimes;

namespace JiraTimers
{
	public static class Program
	{
		public static int Main(string[] args)
		{
			RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();

			QQuickStyle.SetStyle("Material");

			using var application = new QGuiApplication(args);
			using var qmlEngine = new QQmlApplicationEngine();

			qmlEngine.Load("Pages/Main.qml");

			return application.Exec();
		}
	}
}