import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0
import "../WindowsManager.js"
as WindowsManager

import JiraTimers.Net.Components 1.0

ToolBar
{
	// id: toolBar
	Material.foreground: parent.Material.foreground

	property
	var itsClientStore

	RowLayout
	{
		anchors.fill: parent

		Label
		{
			id: toolbarMNessage
			// text: jiraClientStore.isConnected

			font.pixelSize: Theme.fontSize

			Layout.leftMargin: Theme.paddingMedium
			Layout.fillWidth: true
		}

		Button
		{
			icon.source: "../../Images/SettingsIcon.png"

			highlighted: true

			Layout.alignment: Qt.AlignRight
			Layout.rightMargin: Theme.paddingMedium

			onClicked:
			{
				var window = WindowsManager.openWindow("Windows/SettingsWindow.qml", parent);
			}
		}
	}

	JiraTimersLifeTimeScope
	{
		id: scope
	}

	Component.onCompleted:
	{
		itsClientStore = scope.getItsClientStore();
		toolbarMNessage.text = itsClientStore.isConnected ? "Connected" : "Not connected";
	}

	Component.onDestruction: scope.dispose()
}