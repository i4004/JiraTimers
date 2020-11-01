import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0

ApplicationWindow
{
	id: messageDialog

	property alias text: messageBoxLabel.text

	title: qsTr("Information")

	minimumHeight: 200
	minimumWidth: 350
	maximumHeight: minimumHeight
	maximumWidth: minimumWidth

	flags: Qt.Dialog
	modality: Qt.ApplicationModal

	Material.theme: parent.Material.theme
	Material.primary: parent.Material.primary
	Material.accent: parent.Material.accent
	Material.foreground: parent.Material.foreground
	Material.background: parent.Material.background

	visible: true

	Label
	{
		id: messageBoxLabel

		anchors.margins: Theme.paddingMedium

		anchors.top: parent.top
		anchors.left: parent.left
		anchors.right: parent.right
		anchors.bottom: toolBar.top

		horizontalAlignment: Text.AlignHCenter
		wrapMode: Text.WordWrap
	}

	footer: ToolBar
	{
		id: toolBar

		Material.background: parent.Material.background

		Button
		{
			text: qsTr("Close")

			anchors.centerIn: parent

			highlighted: true

			onClicked: messageDialog.close()
		}
	}
}