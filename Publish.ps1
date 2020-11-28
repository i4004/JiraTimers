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
$devenvOutputLogFileName = "DevenvOutput.log"
$setupProjectPath = "src/JiraTimers.Setup/JiraTimers.Setup.vdproj"

# Publish
dotnet publish $solutionFilePath -p:PublishProfile=$publishProfileName

# Build MSI version
& "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.com" $setupProjectPath /build Release /projectconfig Release /Out $devenvOutputLogFileName

# Build Choco

$version = [Reflection.AssemblyName]::GetAssemblyName($dllPath).Version.ToString()
choco pack $nuspecFilePath --version $version

exit $LastExitCode