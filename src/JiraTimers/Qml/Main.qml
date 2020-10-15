import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0
import "Controls"

ApplicationWindow
{
	id: app
	title: "JiraTimers"

	width: 520
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	Material.theme: Material.Light

	visible: true

	footer: ToolBar
	{
		Material.foreground: Material.foreground

		RowLayout
		{
			anchors.fill: parent

			Label
			{
				text: "Status bar"

				color: Material.background
				font.pixelSize: Theme.fontSize

				Layout.leftMargin: Theme.paddingMedium
				Layout.fillWidth: true
			}

			Button
			{
				icon.source: "../Images/SettingsIcon.png"
				icon.color: Material.primary

				Layout.alignment: Qt.AlignRight
				Layout.rightMargin: Theme.paddingMedium
			}
		}
	}

	JiraTimersSystemTrayIcon
	{}
}