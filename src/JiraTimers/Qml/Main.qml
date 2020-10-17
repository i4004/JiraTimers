import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0
import "Controls"

ApplicationWindow
{
	id: app
	title: Qt.application.name

	width: 520
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	// Material.theme: Material.Light
	// Material.primary: "#DAD4E0"

	Material.theme: Material.Dark
	Material.primary: "#3B3A3D"
	Material.foreground: "white"

	Material.accent: "#7D2CCE"

	visible: true

	footer: JiraTimersToolbar
	{}

	JiraTimersSystemTrayIcon
	{}
}