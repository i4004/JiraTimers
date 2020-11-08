import QtQuick 2.12

import jira.timers.theme 1.0
import JiraTimers.Net.Components 1.0

ScopedApplicationWindow
{
	id: themedWindow

	Component.onCompleted:
	{
		settings = scope.getSettings();

		Theme.setTheme(themedWindow, settings.isDarkTheme);
	}
}