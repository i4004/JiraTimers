using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;
using JiraTimers.Configuration;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.IssueTrackingSystem.Impl;
using JiraTimers.IssueTrackingSystem.Impl.Qml;
using JiraTimers.Settings;
using Moq;
using NUnit.Framework;
using Simplify.Templates;

namespace JiraTimers.Tests.Settings
{
	[TestFixture]
	public class IssuesStoreTests
	{
		private const string TestFilePath = "TestData/Issues.json";

		private IItsIssuesStore _store;
		private Mock<IFileSystem> _fileSystem;

		[SetUp]
		public void Initialize()
		{
			_store = new FileBasedItsIssuesStore(JiraTimersPaths.GetIssuesSettingsFilePath());
			_fileSystem = new Mock<IFileSystem>();

			FileBasedItsIssuesStore.FileSystem = _fileSystem.Object;
		}

		[Test]
		public void Load_TwoIssues_AllPropertiesParsed()
		{
			// Arrange
			_fileSystem.Setup(x => x.File.ReadAllText(It.IsAny<string>(), It.IsAny<Encoding>()))
				.Returns(TemplateBuilder
					.FromCurrentAssembly(TestFilePath)
					.Build()
					.Get());

			// Act
			var result = _store.Load();

			// Asset

			Assert.AreEqual(2, result.Count);
			Assert.AreEqual("1", result[0].Issue.ID);
			Assert.AreEqual("ISS-1", result[0].Issue.Key);
			Assert.AreEqual("Sum 1", result[0].Issue.Summary);
		}

		[Test]
		public void Save_TwoIssues_CorrectJsonGenerated()
		{
			// Arrange

			var actual = "";
			var expected = TemplateBuilder.FromCurrentAssembly(TestFilePath).Build().Get();

			_fileSystem.Setup(x => x.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Encoding>()))
				.Callback((string path, string content, Encoding encoding) =>
		   {
			   actual = content;
		   });

			var items = new List<IItsTrackingIssue>
			{
				new QmlItsTrackingIssue{Issue = new QmlItsIssue
				{
					ID = "1",
					Key = "ISS-1",
					Summary = "Sum 1"
				}},
				new QmlItsTrackingIssue{Issue = new QmlItsIssue
				{
					ID = "2",
					Key = "ISS-2",
					Summary = "Sum 2"
				}}
			};

			// Act
			_store.Save(items);

			// Asset
			Assert.AreEqual(expected, actual);
		}
	}
}