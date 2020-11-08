import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0

Column
{
	id: column

	anchors.top: parent.top
	anchors.left: parent.left
	anchors.right: parent.right
	anchors.topMargin: Theme.paddingMedium - 7

	property alias model: repeater.model

	Repeater
	{
		id: repeater

		Column
		{
			anchors.left: column.left
			anchors.right: column.right

			GridLayout
			{
				anchors.left: parent.left
				anchors.right: parent.right

				Flow
				{
					Layout.alignment: Qt.AlignLeft
					Layout.leftMargin: Theme.paddingMedium

					TextEdit
					{
						text: modelData.name

						width: 150
						height: 50

						verticalAlignment: TextEdit.AlignVCenter

						color: Material.foreground
						selectionColor: Material.accent
						font.pointSize: 15

						readOnly: true
						selectByMouse: true
					}
				}

				Flow
				{
					spacing: Theme.paddingMedium

					Layout.alignment: Qt.AlignRight
					Layout.rightMargin: Theme.paddingMedium

					Button
					{
						text: "↪"

						font.pointSize: 25
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: true
					}

					TextEdit
					{
						text: modelData.time

						height: 50
						width: 82

						verticalAlignment: TextEdit.AlignVCenter

						color: Material.foreground
						selectionColor: Material.accent
						font.pointSize: 15

						readOnly: true
						selectByMouse: true
					}

					Button
					{
						text: "▶"

						font.pointSize: 25
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: true
					}

					Button
					{
						text: "📅"

						font.pointSize: 12
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth
					}

					Button
					{
						text: "↺"

						font.pointSize: 18
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth
					}

					Button
					{
						text: "🗑"

						font.pointSize: 13
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: true
					}
				}
			}

			TextEdit
			{
				text: modelData.description

				anchors.left: parent.left
				anchors.leftMargin: Theme.paddingMedium

				color: Material.foreground
				selectionColor: Material.accent
				font.pointSize: 10

				readOnly: true
				selectByMouse: true
			}

			Rectangle
			{
				anchors.left: parent.left
				anchors.leftMargin: Theme.paddingMedium
				anchors.right: parent.right
				anchors.rightMargin: Theme.paddingMedium

				height: 15
				color: "transparent"
			}

			Rectangle
			{
				anchors.left: parent.left
				anchors.leftMargin: Theme.paddingMedium
				anchors.right: parent.right
				anchors.rightMargin: Theme.paddingMedium

				height: 1
				color: Material.accent
			}
		}
	}

	Button
	{
		text: "+"

		height: Theme.toolButtonHeight
		width: Theme.toolButtonWidth

		anchors.right: parent.right
		anchors.rightMargin: Theme.paddingMedium

		highlighted: true
	}
}