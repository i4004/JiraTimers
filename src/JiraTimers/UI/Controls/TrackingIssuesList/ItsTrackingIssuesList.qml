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
	// Properties

	id: column

	anchors.top: parent.top
	anchors.left: parent.left
	anchors.right: parent.right
	anchors.topMargin: Theme.paddingMedium - 7

	property alias model: repeater.model

	property
	var list: scope.getItsTrackingIssuesList()

	property
	var listController: scope.getItsTrackingIssuesListController()

	property string itemToRemoveID

	property bool hasIssues

	// Controls

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
							var task = listController.refreshIssueInfoAsync(modelData.issue.iD, textKey.text);

							Net.await(task, function(result)
							{
								if (result)
									refreshModel();
								else
								{
									var window = WindowManager.openWindow("MessageDialog.qml", app);
									window.text = scope.getItsClientStore().client.lastOperationResult;
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

						enabled: textKey.text

						onClicked: Qt.openUrlExternally(formatIssueUrl(textKey.text))
					}

					TextEdit
					{
						text: modelData.formattedElapsedTime

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
						text: modelData.isTimerRunning ? "▌▌" : "▶"
						font.pointSize: modelData.isTimerRunning ? 9 : 25

						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: true

						onClicked: startStopIssueTimer(modelData)
					}

					Button
					{
						text: "📅"

						font.pointSize: 12
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: isIssueContainsTimeToLog(modelData)

						enabled: modelData.issue.summary

						onClicked:
						{
							var window = WindowManager.openWindow("LogWorkWindow.qml", app);

							window.setIssue(modelData);
							window.workLogged.connect(refreshModel);
						}
					}

					Button
					{
						text: "↺"

						font.pointSize: 18
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						enabled: isIssueContainsTimeToLog(modelData)

						onClicked: resetIssueTimer(modelData)
					}

					Button
					{
						text: "🗑"

						font.pointSize: 13
						height: Theme.toolButtonHeight
						width: Theme.toolButtonWidth

						highlighted: false

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

		onClicked: createNewIssue()
	}

	MessageDialog
	{
		id: deleteConfirmationDialog

		icon: StandardIcon.Question
		standardButtons: StandardButton.Yes | StandardButton.No

		informativeText: "Are you sure to delete the item?"

		onYes: removeIssue()
	}

	Timer
	{
		interval: 60000
		running: true
		repeat: true

		onTriggered: refreshModel()
	}

	// Commands

	function createNewIssue()
	{
		listController.createNewIssue();

		refreshModel();
	}

	function removeIssue()
	{
		listController.removeIssue(itemToRemoveID);

		refreshModel();
	}

	function refreshModel()
	{
		hasIssues = list.items.count > 0;

		model = Net.toListModel(list.items);
	}

	function formatIssueUrl(issueKey)
	{
		return (scope.getSettings().jiraBaseUrl + "/browse/" + issueKey).replace("//", "/");
	}

	function startStopIssueTimer(issue)
	{
		if (issue.isTimerRunning)
			listController.stopIssueTimer(issue.issue.iD);
		else
			listController.startIssueTimer(issue.issue.iD);

		refreshModel();
	}

	function resetIssueTimer(issue)
	{
		listController.resetIssueTimer(issue.issue.iD);

		refreshModel();
	}

	function isIssueContainsTimeToLog(model)
	{
		return model.formattedElapsedTime != "00:00"
	}
}