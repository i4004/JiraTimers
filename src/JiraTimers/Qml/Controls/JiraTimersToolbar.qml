import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0

import "../WindowsManager.js"
as WindowsManager

ToolBar
{
	Material.foreground: parent.Material.foreground

	property alias text: toolbarMNessage.text

	function runBusyIndicator()
	{
		busyIndicator.run();
	}

	function stopBusyIndicator()
	{
		busyIndicator.stop();
	}

	RowLayout
	{
		anchors.fill: parent

		BusyIndicator
		{
			id: busyIndicator

			running: false
			visible: false

			function run()
			{
				running = true;
				visible = true;
			}

			function stop()
			{
				visible = false;
				running = false;
			}
		}

		Label
		{
			id: toolbarMNessage

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
}