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
			app.visible = !app.visible
	}

	menu: Menu
	{
		MenuItem
		{
			text: qsTr("Quit")
			onTriggered: Qt.quit()
		}
	}
}