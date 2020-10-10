import QtQuick 2.9
import QtQuick.Layouts 1.3
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import Qt.labs.platform 1.1

ApplicationWindow
{
	title: "JiraTimers"
	id: app

	width: 360
	height: 520
	visible: true

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	Component.onCompleted:
	{
		console.log("Window launched")
	}

	SystemTrayIcon
	{
		id: sysTray
		visible: true
		icon.mask: true
		icon.source: "Images/TrayIcon.jpg"

		onActivated:
		{
			console.log("Activated")

			window.show()
			window.raise()
			window.requestActivate()
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

	onClosing:
	{
		close.accepted = false
		app.visible = false
	}
}