import QtQuick 2.12
import QtQuick.Controls 2.3

import JiraTimers.Net.Components 1.0

ApplicationWindow
{
	property alias scope: scope

	JiraTimersLifeTimeScope
	{
		id: scope
	}

	onClosing: scope.dispose()
}