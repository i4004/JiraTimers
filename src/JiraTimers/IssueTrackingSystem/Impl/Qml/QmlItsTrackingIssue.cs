using System;
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

		public DateTime? StartTime { get; set; }

		public TimeSpan ElapsedTime { get; set; }

		[NotifySignal]
		public string FormattedElapsedTime => ElapsedTime.ToString("hh\\:mm");

		public string TextElapsedTime => ((ElapsedTime.Days > 0 ? $"{ElapsedTime.Days}d" : "")
										  + (ElapsedTime.Hours > 0 ? $" {ElapsedTime.Hours}h" : "")
										  + (ElapsedTime.Minutes > 0 ? $" {ElapsedTime.Minutes}m" : ""))
			.Trim();

		[NotifySignal]
		public bool IsTimerRunning
		{
			get => _timer != null;
			set
			{
				if (value)
					StartTimer();
			}
		}

		public void StartTimer()
		{
			_timer = new Timer(OnTimer, null, 0, 1000);

			if (StartTime == default)
				StartTime = DateTime.Now;
		}

		public void StopTimer()
		{
			_timer?.Dispose();
			_timer = null;
		}

		public void ResetTimer()
		{
			StopTimer();

			StartTime = default;
			ElapsedTime = default;
		}

		private void OnTimer(object? state) => ElapsedTime = ElapsedTime.Add(TimeSpan.FromSeconds(1));
	}
}