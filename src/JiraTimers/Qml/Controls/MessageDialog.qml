import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0

ApplicationWindow
{
	id: messageDialog

	property alias text: messageBoxText.text

	title: qsTr("Information")

	minimumHeight: 300
	minimumWidth: 500

	flags: Qt.Dialog
	modality: Qt.ApplicationModal

	Material.theme: parent.Material.theme
	Material.primary: parent.Material.primary
	Material.accent: parent.Material.accent
	Material.foreground: parent.Material.foreground
	Material.background: parent.Material.background

	visible: true

	ScrollView
	{
		anchors.fill: parent
		contentWidth: -1

		ScrollBar.vertical.policy: ScrollBar.AsNeeded

		TextEdit
		{
			id: messageBoxText

			rightPadding: Theme.paddingMedium
			anchors.fill: parent

			horizontalAlignment: TextEdit.AlignHCenter

			color: parent.Material.foreground
			selectionColor: parent.Material.accent
			font.pointSize: 12

			readOnly: true
			wrapMode: Text.WordWrap
			selectByMouse: true
		}
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