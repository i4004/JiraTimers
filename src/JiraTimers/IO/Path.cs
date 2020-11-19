using System.IO;

namespace JiraTimers.IO
{
	public static class Path
	{
		private static string? _currentDirectory;

		/// <summary>
		/// Gets the multi-platform current directory.
		/// </summary>
		/// <value>
		/// The multi-platform current directory.
		/// </value>
		public static string CurrentDirectory => _currentDirectory ??= GetCurrentDirectory();

		private static string GetCurrentDirectory()
		{
			var filePath = "file:///" + Directory.GetCurrentDirectory().Replace("\\", "/");

			return filePath.Replace("////", "///");
		}
	}
}