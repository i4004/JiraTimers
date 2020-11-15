using Qml.Net;

namespace JiraTimers.Setup.QT
{
	public class QtUI
	{
		public static void Setup()
		{
			QCoreApplication.SetAttribute(ApplicationAttribute.EnableHighDpiScaling, true);
			QQuickStyle.SetStyle("Material");
		}
	}
}