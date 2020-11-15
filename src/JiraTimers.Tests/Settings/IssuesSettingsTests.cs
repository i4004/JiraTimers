using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;
using JiraTimers.Configuration;
using JiraTimers.IssueTrackingSystem;
using JiraTimers.Settings;
using Moq;
using NUnit.Framework;
using Simplify.Templates;

namespace JiraTimers.Tests.Settings
{
	[TestFixture]
	public class IssuesSettingsTests
	{
		private const string TestFilePath = "TestData/Issues.json";

		private IIssuesSettings _settings;
		private Mock<IFileSystem> _fileSystem;

		[SetUp]
		public void Initialize()
		{
			_settings = new IssuesSettings(JiraTimersPaths.GetIssuesSettingsFilePath());
			_fileSystem = new Mock<IFileSystem>();

			IssuesSettings.FileSystem = _fileSystem.Object;
		}

		[Test]
		public void Load_IssuesList_AllPropertiesParsed()
		{
			// Arrange
			_fileSystem.Setup(x => x.File.ReadAllText(It.IsAny<string>(), It.IsAny<Encoding>()))
				.Returns(TemplateBuilder
					.FromCurrentAssembly(TestFilePath)
					.Build()
					.Get());

			// Act
			var result = _settings.Load();

			// Asset

			Assert.AreEqual(2, result.Count);
		}

		[Test]
		public void Save_IssuesList_CorrectJsonGenerated()
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
				new ItsTrackingIssue{Issue = new ItsIssue
				{
					ID = "1",
					Key = "ISS-1",
					Summary = "Sum 1"
				}},
				new ItsTrackingIssue{Issue = new ItsIssue
				{
					ID = "2",
					Key = "ISS-2",
					Summary = "Sum 2"
				}}
			};

			// Act
			_settings.Save(items);

			// Asset
			Assert.AreEqual(expected, actual);
		}
	}
}