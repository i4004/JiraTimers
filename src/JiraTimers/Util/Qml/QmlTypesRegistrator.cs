using JiraTimers.IO;

namespace JiraTimers.Util.Qml
{
	public static class QmlTypesRegistrator
	{
		public static void Register<T>(string uri) => global::Qml.Net.Qml.RegisterType<T>(uri);

		public static void RegisterSingleton(string qmlFileLocalPath, string qmlTypeName, string uri)
			=> global::Qml.Net.Qml.RegisterSingletonType($"{Path.CurrentDirectory}/{qmlFileLocalPath}", qmlTypeName, uri);
	}
}