using JiraTimers.DI;
using JiraTimers.Util.Qml;

namespace JiraTimers.Setup.Qml
{
	public static class NetTypesToQml
	{
		private const string QmlFilesFolderName = "UI";

		private const string TypesUri = nameof(JiraTimers) + ".Types";

		public static void Register()
		{
			QmlTypesRegistrator.Register<JiraTimersLifeTimeScope>(TypesUri);

			QmlTypesRegistrator.RegisterSingleton($"{QmlFilesFolderName}/AppInfo.qml", "AppInfo", TypesUri);
			QmlTypesRegistrator.RegisterSingleton($"{QmlFilesFolderName}/Theme.qml", "Theme", TypesUri);
		}
	}
}