import QtQuick 2.12
import QtQuick.Layouts 1.3
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1

import "Controls"

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
		// TODO Temp
		// sysTray.showMessage("JiraTimers", "Hello!")
	}


	JiraTimersSystemTrayIcon
	{}
}