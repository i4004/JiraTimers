import QtQuick 2.9
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import Qt.labs.platform 1.1

ApplicationWindow
{
	id: app
	title: "JiraTimers"

	width: 360
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	Material.theme: Material.Light

	visible: true

	Component.onCompleted:
	{
		sysTray.showMessage("JiraTimers", "Hello!")
	}

	SystemTrayIcon
	{
		id: sysTray

		visible: true
		icon.source: "Images/TrayIcon.jpg"
		iconName: "icon name"
		tooltip: "tooltip"

		Component.onCompleted: showMessage("Message title", "Something important came up. Click this to know more.")

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
				text: "Quit"
				onTriggered: Qt.quit()
			}
		}
	}

	// onClosing:
	// {
	// 	close.accepted = false
	// 	app.visible = false
	// }
}