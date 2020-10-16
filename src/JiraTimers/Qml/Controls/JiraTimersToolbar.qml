import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0

ToolBar
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
			icon.source: "../../Images/SettingsIcon.png"
			icon.color: Material.primary

			Layout.alignment: Qt.AlignRight
			Layout.rightMargin: Theme.paddingMedium
		}
	}
}