import QtQuick 2.12
import QtQuick.Controls 2.3

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

	footer: JiraTimersToolbar
	{}

	JiraTimersSystemTrayIcon
	{}

	Component.onCompleted:
	{
		var settings = scope.getSettings();

		console.log(settings.isDarkTheme);
		Theme.setTheme(app, settings.isDarkTheme);
	}
}