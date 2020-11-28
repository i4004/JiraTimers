trap
{
	"Powershell execution error"
	write-output $_
	exit 1
}

# Paths

$solutionFilePath = "src/JiraTimers.sln"
$localProjectPath = ".\src\JiraTimers"
$projectPath = "\src\JiraTimers"
$nuspecFilePath = Join-Path $localProjectPath "jiratimers.nuspec"
$winReleasePath = Join-Path $projectPath "publish-win"
$workingDirectory = Get-Location
$fullReleasePath = Join-Path $workingDirectory $winReleasePath
$dllPath = Join-Path $fullReleasePath "JiraTimers.dll"
$publishProfileName = "Release-Win"

# Publish
dotnet publish $solutionFilePath -p:PublishProfile=$publishProfileName

$version = [Reflection.AssemblyName]::GetAssemblyName($dllPath).Version.ToString()

# Pach
choco pack $nuspecFilePath --version $version

exit $LastExitCode