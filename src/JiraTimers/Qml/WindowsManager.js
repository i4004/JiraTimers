// Opens the new QML window
function openWindow(path)
{
	var component = Qt.createComponent(path);

	if (component.status == Component.Error)
	{
		console.log(component.errorString());
		return;
	}

	var window = component.createObject(app);
	window.show();

	return window;
}