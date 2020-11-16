import QtQuick 2.12
import QtQuick.Controls 2.3
import QtQuick.Window 2.1

import JiraTimers.Types 1.0

import "Controls"
import "Controls/TrackingIssuesList"
import "Windows"
import "Windows/WindowManager.js"
as WindowManager

ThemedWindow
{
	// Properties

	id: app
	title: AppInfo.name

	minimumWidth: 620
	minimumHeight: 300

	width: 620
	height: 520

	flags: Qt.Dialog | Qt.WindowTitleHint | Qt.WindowCloseButtonHint | Qt.WindowMinimizeButtonHint

	visible: false

	property
	var settings;

	property bool customMinimize: false;

	// Controls

	ItsTrackingIssuesList
	{
		id: trackingIssuesList

		anchors.fill: parent
	}

	Image
	{
		source: "../Images/GrayIcon.png"

		anchors.centerIn: parent
		z: -1

		visible: !trackingIssuesList.hasIssues
	}

	footer: JiraTimersToolbar
	{
		id: toolBar

		onSettingsChanged: tryCreateItsClient()
	}

	JiraTimersSystemTrayIcon
	{
		id: systemTrayIcon
	}

	// Events

	Component.onCompleted: initialize()

	onClosing:
	{
		if (processMinimizeInsteadOfClose())
			close.accepted = false;
		else
			saveWindowPositionAndSize();
	}

	onVisibilityChanged: processHideInsteadOfMinimize()

	// Commands

	function initialize()
	{
		settings = scope.getSettings();

		Theme.setTheme(app, settings.isDarkTheme);
		loadWindowPositionAndSize();

		visible = true;

		trackingIssuesList.refreshModel();

		tryCreateItsClient();
	}

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

	function tryCreateItsClient()
	{
		var itsClientStore = scope.getItsClientStore();

		if (!itsClientStore.readyToCreate())
			return;

		toolBar.runBusyIndicator();
		toolBar.text = "Connecting...";

		var task = itsClientStore.tryCreateItsClientAsync();

		Net.await(task, function(result)
		{
			toolBar.stopBusyIndicator();

			if (result == null)
			{
				toolBar.text = "Connected";
				return;
			}

			toolBar.text = "Not connected";

			var window = WindowManager.openWindow("MessageDialog.qml", app);
			window.text = result;
		})
	}
}