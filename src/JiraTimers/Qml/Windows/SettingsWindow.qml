import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import jira.timers.theme 1.0
import "../Controls"

import "../WindowsManager.js"
as WindowsManager

import JiraTimers.Net.Components 1.0

ScopedApplicationWindow
{
	id: window
	title: qsTr("JiraTimers Settings")

	minimumHeight: 500
	minimumWidth: 350
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
			id: jiraUserName

			Layout.preferredWidth: parent.width

			placeholderText: qsTr("Jira user name")
		}

		TextField
		{
			id: jiraUserPassword

			Layout.preferredWidth: parent.width

			echoMode: TextInput.PasswordEchoOnEdit
			passwordCharacter: "*"
			placeholderText: qsTr("Jira user password")
		}

		SubHeader
		{
			text: qsTr("General")
		}

		CheckBox
		{
			id: minimizeToSystemTray

			text: qsTr("Minimize to system tray")
		}

		CheckBox
		{
			id: minimizeOnClose

			text: qsTr("Minimize on close")
		}

		SubHeader
		{
			text: qsTr("Appearance")
		}

		CheckBox
		{
			id: isDarkTheme

			text: qsTr("Dark Theme (need restart)")
		}
	}

	footer: ToolBar
	{
		Material.background: parent.Material.background

		Button
		{
			text: qsTr("Test connection")

			anchors.left: parent.left
			anchors.leftMargin: Theme.paddingMedium

			highlighted: true
			enabled: jiraBaseUrlTextField.text != "" && jiraUserName.text != "" && jiraUserPassword.text != ""

			onClicked:
			{
				var itsClientStore = scope.getItsClientStore();

				var result = itsClientStore.testConnection(jiraBaseUrlTextField.text, jiraUserName.text, jiraUserPassword.text);

				var window = WindowsManager.openWindow("Controls/MessageDialog.qml", parent);

				if (result == null)
					window.text = "Connection is OK!";
				else
					window.text = result;
			}
		}

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
			text: qsTr("Save")

			anchors.right: parent.right
			anchors.rightMargin: Theme.paddingMedium

			highlighted: true

			DialogButtonBox.buttonRole: DialogButtonBox.AcceptRole

			onClicked:
			{
				var settings = scope.getSettings();

				settings.jiraBaseUrl = jiraBaseUrlTextField.text;
				settings.jiraUserName = jiraUserName.text;
				settings.jiraUserPassword = jiraUserPassword.text;

				settings.minimizeToSystemTray = minimizeToSystemTray.checked;
				settings.minimizeOnClose = minimizeOnClose.checked;

				settings.isDarkTheme = isDarkTheme.checked;

				window.close();
			}
		}
	}

	Component.onCompleted:
	{
		var settings = scope.getSettings();

		jiraBaseUrlTextField.text = settings.jiraBaseUrl;
		jiraUserName.text = settings.jiraUserName;
		jiraUserPassword.text = settings.jiraUserPassword;

		minimizeToSystemTray.checked = settings.minimizeToSystemTray;
		minimizeOnClose.checked = settings.minimizeOnClose;

		isDarkTheme.checked = settings.isDarkTheme;
	}
}