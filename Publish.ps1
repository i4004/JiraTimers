
function GetVersion
{
	$assembly = [Reflection.Assembly]::Loadfile($dllPath)

	$assemblyName = $assembly.GetName()
	return $assemblyName.version
}


# Paths

$solutionFilePath = "src/JiraTimers.sln"
$projectPath = ".\src\JiraTimers"
$nuspecFilePath = Join-Path $projectPath "jiratimers.nuspec"
$winReleasePath = Join-Path $projectPath "publish-win"
$workingDirectory = Get-Location
$dllPath = Join-Path $workingDirectory $winReleasePath "JiraTimers.dll"

$publishProfileName = "Release-Win"
$version = GetVersion

# Publish
dotnet publish $solutionFilePath -p:PublishProfile=$publishProfileName

# Pach
choco pack $nuspecFilePath --version $version
