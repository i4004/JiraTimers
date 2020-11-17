using System;
using System.Diagnostics;
using JiraTimers.Json;
using Newtonsoft.Json;
using Qml.Net;
using Simplify.System.Diagnostics;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class QmlItsTrackingIssue : IItsTrackingIssue
	{
		private OffsetStopwatch _stopwatch;

		public QmlItsTrackingIssue()
		{
		}

		[JsonConverter(typeof(ConcreteConverter<QmlItsIssue>))]
		public IItsIssue Issue { get; set; }

		[NotifySignal]
		public DateTime TimerStartTime { get; set; }

		[NotifySignal]
		public TimeSpan ElapsedTime
		{
			get => Stopwatch.Elapsed;
			set => _stopwatch = new OffsetStopwatch(value);
		}

		[NotifySignal]
		public string Time { get; set; }

		private Stopwatch Stopwatch
		{
			get
			{
				return _stopwatch ??= _stopwatch = new OffsetStopwatch();
			}
		}

		public void StartTimer()
		{
			if (TimerStartTime == default)
				TimerStartTime = DateTime.Now;

			Stopwatch.Start();
		}

		public void StopTimer()
		{
			Stopwatch.Stop();
		}

		public void ResetTimer()
		{
			TimerStartTime = default;

			Stopwatch.Reset();
		}
	}
}