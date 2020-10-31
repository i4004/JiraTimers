// Opens the new QML window
function openWindow(path, parent)
{
	var component = Qt.createComponent(path);

	if (component.status == Component.Error)
	{
		console.log(component.errorString());
		return;
	}

	var window = component.createObject(parent);
	window.show();

	return window;
}