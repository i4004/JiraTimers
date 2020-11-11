import QtQuick 2.12

import JiraTimers.Types 1.0

ScopedApplicationWindow
{
	id: themedWindow

	Component.onCompleted:
	{
		settings = scope.getSettings();

		Theme.setTheme(themedWindow, settings.isDarkTheme);
	}
}