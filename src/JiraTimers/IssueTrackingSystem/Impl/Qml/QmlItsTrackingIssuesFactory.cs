using System;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class QmlItsTrackingIssuesFactory : IItsTrackingIssuesFactory
	{
		public IItsTrackingIssue Create()
		{
			return new QmlItsTrackingIssue
			{
				Issue = new QmlItsIssue
				{
					ID = Guid.NewGuid().ToString()
				}
			};
		}
	}
}