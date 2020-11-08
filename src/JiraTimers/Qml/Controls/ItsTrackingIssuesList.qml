import QtQuick 2.12

Column
{
	id: column
	anchors.left: parent.left
	anchors.right: parent.right

	property alias model: repeater.model

	Repeater
	{
		id: repeater

		// Rectangle
		// {
		// 	height: 40;
		// 	border.width: 1
		// 	color: "yellow"

		// 	anchors.left: parent.left
		// 	anchors.right: parent.right
		// }

		Text
		{
			text: "Name: " + modelData.name

			anchors.left: column.left
			anchors.right: column.right

			color: "#ffffff"
			font.pointSize: 16
		}
	}
}