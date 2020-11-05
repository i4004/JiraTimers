import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Window 2.1

import jira.timers.theme 1.0
import "Controls"

import "WindowsManager.js"
as WindowsManager

ScopedApplicationWindow
{
	id: app
	title: Qt.application.name

	minimumWidth: 400
	minimumHeight: 300

	width: 520
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	visible: false

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
		loadWindowPositionAndSize();

		visible = true;

		tryCreateCreateItsClient();
	}

	onClosing:
	{
		if (processMinimizeInsteadOfClose())
			close.accepted = false;
		else
			saveWindowPositionAndSize();
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

	function loadWindowPositionAndSize()
	{
		if (!settings.saveMainWindowPositionAndSize)
			return;

		var mainWindowX = settings.mainWindowX;
		var mainWindowY = settings.mainWindowY;
		var mainWindowWidth = settings.mainWindowWidth;
		var mainWindowHeight = settings.mainWindowHeight;

		if (mainWindowX == null || mainWindowY == null || mainWindowWidth == null || mainWindowHeight == null)
			return;

		x = mainWindowX;
		y = mainWindowY;
		width = mainWindowWidth;
		height = mainWindowHeight;
	}

	function saveWindowPositionAndSize()
	{
		if (!settings.saveMainWindowPositionAndSize)
			return;

		settings.mainWindowX = x;;
		settings.mainWindowY = y;
		settings.mainWindowWidth = width;
		settings.mainWindowHeight = height;
	}

	function tryCreateCreateItsClient()
	{
		var itsClientStore = scope.getItsClientStore();

		if (!itsClientStore.readyToConnect())
			return;

		var result = itsClientStore.tryCreateItsClient();

		if (result == null)
			return;

		var window = WindowsManager.openWindow("Controls/MessageDialog.qml", parent);

		window.text = result;
	}
}