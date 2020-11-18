﻿using System;
using System.Threading;
using JiraTimers.Json;
using Newtonsoft.Json;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class QmlItsTrackingIssue : IItsTrackingIssue
	{
		private Timer? _timer;

		[JsonConverter(typeof(ConcreteConverter<QmlItsIssue>))]
		public IItsIssue? Issue { get; set; }

		public DateTime TimerStartTime { get; set; }

		public TimeSpan ElapsedTime { get; set; }

		[NotifySignal]
		public string FormattedElapsedTime => ElapsedTime.ToString("hh\\:mm");

		public bool IsTimerRunning => _timer != null;

		public void StartTimer()
		{
			_timer = new Timer(OnTimer, null, 0, 1000);

			if (TimerStartTime == default)
				TimerStartTime = DateTime.Now;
		}

		public void StopTimer()
		{
			_timer = null;
		}

		public void ResetTimer()
		{
			_timer = null;

			TimerStartTime = default;
			ElapsedTime = default;
		}

		private void OnTimer(object? state)
		{
			ElapsedTime = ElapsedTime.Add(TimeSpan.FromSeconds(1));
		}
	}
}