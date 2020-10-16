import Qt.labs.platform 1.1

SystemTrayIcon
{
	id: sysTray

	icon.source: "../../Images/Icon.png"
	tooltip: "JiraTimers"

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
			text: "Quit"
			onTriggered: Qt.quit()
		}
	}
}