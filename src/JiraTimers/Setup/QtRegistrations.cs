using Qml.Net;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class QtRegistrations
	{
		public static IDIRegistrator RegisterQt(this IDIRegistrator registrator, string[] args)
		{
			return registrator.Register(r => new QGuiApplication(args), LifetimeType.Singleton)
				.Register<QQmlApplicationEngine>(LifetimeType.Singleton);
		}
	}
}