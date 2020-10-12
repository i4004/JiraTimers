import QtQuick 2.12
import QtQuick.Layouts 1.3
import QtQuick.Controls 2.3

import "Controls"

// TODO
// import QtQuick.Controls.Material 2.1

ApplicationWindow
{
	id: app
	title: "JiraTimers"

	width: 360
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	// TODO
	// Material.theme: Material.Light

	visible: true

	Component.onCompleted:
	{
		// TODO Temp
		// sysTray.showMessage("JiraTimers", "Hello!")
	}

	JiraTimersSystemTrayIcon
	{}

	// onClosing:
	// {
	// 	close.accepted = false
	// 	app.visible = false
	// }
}