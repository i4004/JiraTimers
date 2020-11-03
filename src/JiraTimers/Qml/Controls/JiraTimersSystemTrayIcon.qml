import QtQuick.Window 2.1
import Qt.labs.platform 1.1

SystemTrayIcon
{
	id: sysTray

	icon.source: "../../Images/Icon.png"
	tooltip: Qt.application.name

	visible: true

	onActivated:
	{
		if (reason == SystemTrayIcon.Trigger)
			processVisibility();
	}

	function processVisibility()
	{
		if (app.visible == false)
		{
			app.customMinimize = true;
			app.visible = true;

			if (app.visibility == Window.Minimized)
				app.visibility = Window.Windowed;
		}
		else
		{
			if (app.visibility == Window.Windowed)
				app.visible = false;
			else
				app.visibility = Window.Windowed;
		}
	}

	menu: Menu
	{
		MenuItem
		{
			text: qsTr("Quit")
			onTriggered:
			{
				sysTray.visible = false;

				app.saveWindowPositionAndSize();
				Qt.quit();
			}
		}
	}
}