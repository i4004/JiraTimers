import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1

import JiraTimers.Types 1.0

ThemedWindow
{
	id: messageDialog

	property alias text: messageBoxText.text

	title: qsTr("Information")

	minimumHeight: 300
	minimumWidth: 500

	flags: Qt.Dialog
	modality: Qt.ApplicationModal

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

			color: Material.foreground
			selectionColor: Material.accent
			font.pointSize: 12

			readOnly: true
			wrapMode: Text.WordWrap
			selectByMouse: true
		}
	}

	footer: ToolBar
	{
		id: toolBar

		Material.foreground: messageDialog.Material.foreground
		Material.background: messageDialog.Material.background

		Button
		{
			text: qsTr("Close")

			anchors.centerIn: parent

			highlighted: true

			onClicked: messageDialog.close()
		}
	}
}