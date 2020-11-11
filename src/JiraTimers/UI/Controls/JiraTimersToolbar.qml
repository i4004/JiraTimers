import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import JiraTimers.Types 1.0

import "../Windows/WindowManager.js"
as WindowManager

ToolBar
{
	Material.foreground: parent.Material.foreground

	property alias text: toolbarNessage.text

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

			Layout.maximumWidth: 45
			Layout.maximumHeight: 45

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
			id: toolbarNessage

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
				var window = WindowManager.openWindow("SettingsWindow.qml", parent);
			}
		}
	}
}