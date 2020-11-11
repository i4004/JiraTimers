using System;
using Qml.Net.Runtimes;

namespace JiraTimers.Setup.QT
{
	public static class QtRuntime
	{
		public static void Setup()
		{
			Console.WriteLine("Checking and downloading QT runtime if not installed...");

			RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();

			Console.WriteLine("QT runtime is OK.");
		}
	}
}