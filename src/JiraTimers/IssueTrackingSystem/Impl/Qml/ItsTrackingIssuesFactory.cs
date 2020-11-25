using System;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class ItsTrackingIssuesFactory : IItsTrackingIssuesFactory
	{
		public IItsTrackingIssue Create() =>
			new ItsTrackingIssue
			{
				Issue = new ItsIssue
				{
					ID = Guid.NewGuid().ToString()
				}
			};
	}
}