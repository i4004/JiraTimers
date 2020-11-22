import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import JiraTimers.Types 1.0

import "../Controls"
import "../Windows/WindowManager.js"
as WindowManager

ThemedWindow
{
	id: window
	title: qsTr("Submit worklog")

	minimumHeight: 500
	minimumWidth: 440
	maximumHeight: minimumHeight
	maximumWidth: minimumWidth

	flags: Qt.Dialog
	modality: Qt.ApplicationModal

	visible: true

	property
	var issue

	ColumnLayout
	{
		anchors.top: parent.top
		anchors.left: parent.left
		anchors.right: parent.right
		anchors.topMargin: Theme.paddingMedium
		anchors.leftMargin: Theme.paddingMedium
		anchors.bottomMargin: Theme.paddingMedium
		anchors.rightMargin: Theme.paddingMedium

		SubHeader
		{
			text: qsTr("Work log comment (optional)")
		}

		TextEdit
		{
			id: commentTextEdit

			Layout.preferredWidth: parent.width

			color: Material.foreground
			selectionColor: Material.accent
			font.pointSize: 12

			wrapMode: Text.WordWrap
			selectByMouse: true
			focus: true
		}

		SubHeader
		{
			text: qsTr("Time Spent")
		}

		TextField
		{
			id: timeSpentTextField
		}

		SubHeader
		{
			text: qsTr("Start Time")
		}

		Label
		{
			id: startTimeLabel
		}

		// Row
		// {
		// 	Layout.preferredWidth: parent.width
		// 	height: 100

		// 	DatePicker
		// 	{
		// 		id: dateSelector
		// 		width: window.minimumWidth / 2
		// 	}

		// 	TimePicker
		// 	{
		// 		id: timeSelector

		// 		width: window.minimumWidth / 2
		// 		height: 100
		// 	}
		// }

		SubHeader
		{
			text: qsTr("Remaining Estimate")
		}

		ButtonGroup
		{
			id: radioGroup
		}

		RadioButton
		{
			text: "Adjust automatically"

			ButtonGroup.group: radioGroup

			checked: true

			onClicked: workLog.strategy = WorkLogStrategy.autoAdjustRemainingEstimate;
		}

		RadioButton
		{
			text: "Leave Unchanged"

			ButtonGroup.group: radioGroup

			onClicked: workLog.strategy = WorkLogStrategy.retainRemainingEstimate;
		}

		Row
		{
			RadioButton
			{
				text: "Set to"

				ButtonGroup.group: radioGroup

				onClicked: workLog.strategy = WorkLogStrategy.newRemainingEstimate;
			}

			TextField
			{
				id: newEstimateTextField
			}
		}

		// Row
		// {
		// 	RadioButton
		// 	{
		// 		text: "Reduce by"

		// 		ButtonGroup.group: radioGroup
		// 	}

		// 	TextField
		// 	{
		// 		id: reducedByTextField
		// 	}
		// }
	}

	footer: ToolBar
	{
		Material.foreground: parent.Material.foreground
		Material.background: parent.Material.background

		Button
		{
			text: qsTr("Close")

			anchors.right: saveButton.left
			anchors.rightMargin: Theme.paddingMedium

			highlighted: true

			DialogButtonBox.buttonRole: DialogButtonBox.DestructiveRole

			onClicked: window.close()
		}

		Button
		{
			id: saveButton

			text: qsTr("Submit")

			anchors.right: parent.right
			anchors.rightMargin: Theme.paddingMedium

			highlighted: true
			font.weight: Font.Bold

			DialogButtonBox.buttonRole: DialogButtonBox.AcceptRole

			enabled: timeSpentTextField.text
				&& (workLog.strategy != WorkLogStrategy.newRemainingEstimate
					|| (workLog.strategy == WorkLogStrategy.newRemainingEstimate && newEstimateTextField.text))

			onClicked:
			{
				var controller = scope.getItsTrackingIssuesListController();

				workLog.startDate = issue.startTime;

				if (workLog.strategy == WorkLogStrategy.newRemainingEstimate)
					workLog.newEstimate = newEstimateTextField.text;

				controller.logWork(issue.iD, workLog);

				window.close();
			}
		}
	}

	WorkLog
	{
		id: workLog

		timeSpent: timeSpentTextField.text;
		comment: commentTextEdit.text;
	}

	function setIssue(item)
	{
		issue = item;

		timeSpentTextField.text = issue.textElapsedTime;
		startTimeLabel.text = issue.formattedStartTime;
	}
}