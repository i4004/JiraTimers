# Paths

$solutionFilePath = "src/JiraTimers.sln"
$projectPath = ".\src\JiraTimers"
$nuspecFilePath = Join-Path $projectPath "jiratimers.nuspec"
$winReleasePath = Join-Path $projectPath "publish-win"
$workingDirectory = Get-Location
$fullReleasePath = Join-Path $workingDirectory $winReleasePath
$dllPath = Join-Path $fullReleasePath "JiraTimers.dll"
$publishProfileName = "Release-Win"

function GetVersion
{
	$assembly = [Reflection.Assembly]::Loadfile($dllPath)

	$assemblyName = $assembly.GetName()
	return $assemblyName.version
}

$version = GetVersion

# Publish
dotnet publish $solutionFilePath -p:PublishProfile=$publishProfileName

# Pach
choco pack $nuspecFilePath --version $version
