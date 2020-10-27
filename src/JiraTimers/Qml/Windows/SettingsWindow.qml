import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0
import "../Controls"

import JiraTimers.Net.Components 1.0

ScopedApplicationWindow
{
	id: window
	title: qsTr("JiraTimers Settings")

	minimumHeight: 500
	minimumWidth: 320
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
			text: qsTr("Connection")
		}

		TextField
		{
			id: jiraBaseUrlTextField

			Layout.preferredWidth: parent.width

			placeholderText: qsTr("Jira base URL")
		}

		TextField
		{
			Layout.preferredWidth: parent.width

			placeholderText: qsTr("User name")
		}

		TextField
		{
			Layout.preferredWidth: parent.width

			placeholderText: qsTr("Password")
		}

		SubHeader
		{
			text: qsTr("General")
		}

		CheckBox
		{
			text: qsTr("Minimize to system tray")
		}

		CheckBox
		{
			text: qsTr("Minimize on close")
		}
	}

	footer: DialogButtonBox
	{
		Button
		{
			text: qsTr("Save")

			highlighted: true

			DialogButtonBox.buttonRole: DialogButtonBox.AcceptRole

			onClicked:
			{
				var settings = scope.getSettings();

				settings.jiraBaseUrl = jiraBaseUrlTextField.text;

				window.close();
			}
		}
		Button
		{
			text: qsTr("Close")

			highlighted: true

			DialogButtonBox.buttonRole: DialogButtonBox.DestructiveRole

			onClicked: window.close()
		}
	}


	Component.onCompleted:
	{
		var settings = scope.getSettings();

		jiraBaseUrlTextField.text = settings.jiraBaseUrl;
	}
}