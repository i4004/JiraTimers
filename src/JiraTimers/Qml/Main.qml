import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Window 2.1

import jira.timers.theme 1.0
import "Controls"

ScopedApplicationWindow
{
	id: app
	title: Qt.application.name

	width: 520
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	visible: true

	property
	var settings;

	property bool customMinimize: false;

	footer: JiraTimersToolbar
	{}

	JiraTimersSystemTrayIcon
	{
		id: systemTrayIcon
	}

	Component.onCompleted:
	{
		settings = scope.getSettings();

		Theme.setTheme(app, settings.isDarkTheme);
	}

	onClosing:
	{
		if (processMinimizeInsteadOfClose())
			close.accepted = false;
	}

	onVisibilityChanged: processHideInsteadOfMinimize()

	function processMinimizeInsteadOfClose()
	{
		if (settings.minimizeOnClose)
		{
			customMinimize = true;
			showMinimized();

			return true;
		}
		else
			systemTrayIcon.visible = false;

		return false;
	}

	function processHideInsteadOfMinimize()
	{
		if (customMinimize != true && visibility == Window.Minimized && settings.minimizeToSystemTray)
			visible = false;

		customMinimize = false;
	}
}