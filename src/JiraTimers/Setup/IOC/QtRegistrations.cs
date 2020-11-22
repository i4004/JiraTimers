using Qml.Net;
using Simplify.DI;

namespace JiraTimers.Setup.IOC
{
	public static class QtRegistrations
	{
		public static IDIRegistrator RegisterQt(this IDIRegistrator registrator, string[] args) =>
			registrator.Register(r => new QGuiApplication(args), LifetimeType.Singleton)
				.Register<QQmlApplicationEngine>(LifetimeType.Singleton);
	}
}