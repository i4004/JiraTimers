import QtQuick 2.0
import QtQuick.Controls.Material 2.1

Item
{
	id: root

	// public
	function set(date)
	{ // e.g. new Date(0, 0, 0,  0, 0)) // 12:00 AM
		var hour = date.getHours() + (!date.getHours() ? 12 : date.getHours() <= 12 ? 0 : -12) //24 hour to AM/PM
		repeater.itemAt(0).positionViewAtIndex(12 * (repetitions - 1) / 2 + hour - 1, ListView.Center) // hour
		repeater.itemAt(1).positionViewAtIndex(60 / interval * (repetitions - 1) / 2 + date.getMinutes() / interval, ListView.Center) // minute
		repeater.itemAt(2).positionViewAtIndex((rows - 1) / 2 + (date.getHours() < 12 ? 0 : 1), ListView.Center) // am/pm

		for (var column = 0; column < repeater.count; column++) select(repeater.itemAt(column))
	}

	signal clicked(date date); //onClicked: print('onClicked', date.toTimeString())

	property int interval: 1 // 30 20 15 10 5 2 1 minutes

	// private
	width: 500;height: 200 // default size
	clip: true

	onHeightChanged: resizeTimer.start() // resize
	Timer
	{
		id: resizeTimer;interval: 1000;onTriggered: set(get())
	} // ensure same value is selected after resize

	property int rows: 3 // number of rows on the screen     (must be odd). Also change model ''
	property int repetitions: 5 // number of times data is repeated (must be odd)

	Row
	{
		Repeater
		{
			id: repeater

			model: [12 * repetitions, 60 / interval * repetitions, ['', 'AM', 'PM', '']] // 1-12 hour, 0-59 minute, am/pm

			delegate: ListView
			{ // hours minutes am/pm
				id: view

				property int column: index // outer index
				width: root.width / 3;height: root.height
				snapMode: ListView.SnapToItem

				model: modelData

				delegate: Item
				{
					width: root.width / 3;height: root.height / rows

					Text
					{
						text: view.get(index)
						font.pixelSize: Math.min(0.5 * parent.width, parent.height)
						anchors
						{
							verticalCenter: parent.verticalCenter
							right: column == 0 ? parent.right : undefined
							horizontalCenter: column == 1 ? parent.horizontalCenter : undefined
							left: column == 2 ? parent.left : undefined
							rightMargin: 0.2 * parent.width
						}
						opacity: view.currentIndex == index ? 1 : 0.3

						color: Material.foreground
					}
				}

				onMovementEnded:
				{
					select(view);timer.restart()
				}
				onFlickEnded:
				{
					select(view);timer.restart()
				}
				Timer
				{
					id: timer;interval: 1;onTriggered: clicked(root.get())
				} // emit only once

				function get(index)
				{ // returns e.g. '00' given row
					if (column == 0) return index % 12 + 1 // hour
					else if (column == 1) return ('0' + (index * interval) % 60).slice(-2) // minute
					else return model[index] // AM/PM
				}
			}
		}
	}

	Text
	{ // colon
		text: ':'
		font.pixelSize: Math.min(0.5 * root.width / 3, root.height / rows)
		anchors
		{
			verticalCenter: parent.verticalCenter
		}
		x: root.width / 3 - width / 4
	}

	function select(view)
	{
		view.currentIndex = view.indexAt(0, view.contentY + 0.5 * view.height)
	} // index at vertical center

	function get()
	{ // returns e.g. '12:00 AM'
		var hour = repeater.itemAt(0).get(repeater.itemAt(0).currentIndex) // integer
		var am = repeater.itemAt(2).get(repeater.itemAt(2).currentIndex) == 'AM' // boolean
		return new Date(0, 0, 0,
			hour == 12 ? (am ? 0 : 12) : (am ? hour : hour + 12), // hour
			repeater.itemAt(1).get(repeater.itemAt(1).currentIndex)) // minute
	}

	// Component.onCompleted: set(new Date(0, 0, 0,  0, 0)) // 12:00 AM otherwise defaults to index 0 selected
}