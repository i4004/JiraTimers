import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0
import "Controls"

ApplicationWindow
{
	id: window
	title: "JiraTimers Settings"

	minimumHeight: 320
	minimumWidth: 320
	maximumHeight: minimumHeight
	maximumWidth: minimumWidth

	flags: Qt.Dialog

	Material.theme: Material.Light

	visible: true

	footer: DialogButtonBox
	{
		Button
		{
			text: qsTr("Save")
			DialogButtonBox.buttonRole: DialogButtonBox.AcceptRole

			onClicked: window.close()
		}
		Button
		{
			text: qsTr("Close")
			DialogButtonBox.buttonRole: DialogButtonBox.DestructiveRole

			onClicked: window.close()
		}
	}
}