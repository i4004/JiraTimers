import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Dialogs 1.3
import QtQuick.Layouts 1.3

import JiraTimers.Types 1.0

import "../../Windows/WindowManager.js"
as WindowManager

Column
{
	id: column

	anchors.top: parent.top
	anchors.left: parent.left
	anchors.right: parent.right
	anchors.topMargin: Theme.paddingMedium - 7

	property alias model: repeater.model

	property
	var list: scope.getItsTrackingIssuesList()

	property string itemToRemoveID

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
						id: textKey

						text: modelData.issue.key
						property string placeholderText: "Enter issue key here and press enter..."

						width: 150
						height: 50

						verticalAlignment: TextEdit.AlignVCenter

						color: Material.foreground
						selectionColor: Material.accent
						font.pointSize: 15
						font.capitalization: Font.AllUppercase

						selectByMouse: true

						Text
						{
							text: textKey.placeholderText
							color: Material.accent
							visible: !textKey.text
						}

						Keys.onReturnPressed:
						{
							var client = scope.getItsClientStore().client;
							var task = client.getIssueAsync(textKey.text);

							Net.await(task, function(result)
							{
								if (client.lastOperationStatus)
								{
									list.updateItem(modelData.issue.iD, result);
									refreshModel();
								}
								else
								{
									var window = WindowManager.openWindow("Windows/MessageDialog.qml", app);
									window.text = client.lastOperationResult;
								}
							});
						}
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

						enabled: false
						// enabled: textKey.text
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

						enabled: false
						// enabled: textKey.text
					}

					Button
					{
						text: "📅"

						font.pointSize: 12
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						enabled: false
					}

					Button
					{
						text: "↺"

						font.pointSize: 18
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						enabled: false
					}

					Button
					{
						text: "🗑"

						font.pointSize: 13
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: true

						onClicked:
						{
							itemToRemoveID = modelData.issue.iD;
							deleteConfirmationDialog.open();
						}
					}
				}
			}

			TextEdit
			{
				text: modelData.issue.summary

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

		onClicked:
		{
			list.createNewItem();
			refreshModel();
		}
	}

	MessageDialog
	{
		id: deleteConfirmationDialog

		icon: StandardIcon.Question
		standardButtons: StandardButton.Yes | StandardButton.No

		informativeText: "Are you sure to delete the item?"

		onYes:
		{
			list.removeItem(itemToRemoveID);
			refreshModel();
		}
	}

	function refreshModel()
	{
		model = Net.toListModel(list.items);
	}
}