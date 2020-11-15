pragma Singleton

import QtQuick 2.8
import QtQuick.Controls.Material 2.1

QtObject
{
	readonly property int paddingMedium: 10

	readonly property int toolButtonWidth: 50
	readonly property int toolButtonHeight: 50

	readonly property int fontSize: 20

	function setTheme(app, isDark)
	{
		if (isDark)
			setDarkTheme(app);
		else
			setLightTheme(app);

		app.Material.accent = "#65469C";
	}

	function setLightTheme(app)
	{
		app.Material.theme = Material.Light;
		app.Material.primary = "#DAD4E0";
		app.Material.background = "#DFDFDF";
	}

	function setDarkTheme(app)
	{
		app.Material.theme = Material.Dark;
		app.Material.primary = "#3B3A3D";
		app.Material.background = "#2D2D2D";
	}
}