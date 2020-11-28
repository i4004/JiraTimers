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
$setupProjectPath = "src/JiraTimers.Setup/JiraTimers.Setup.vdproj"

"1/4: Build windows release..."
dotnet publish $solutionFilePath -p:PublishProfile=$publishProfileName

# Retrieve app version
$version = [Reflection.AssemblyName]::GetAssemblyName($dllPath).Version.ToString(3)

"2/4: Patch MSI project version..."
((Get-Content -Path $setupProjectPath -Raw) -replace '{version}', $version) | Set-Content -Path $setupProjectPath

"3/4: Build MSI version..."
& "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.com" $setupProjectPath /build Release /projectconfig Release

"4/4: Pack Choco package..."
choco pack $nuspecFilePath --version $version

exit $LastExitCode