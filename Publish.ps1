trap
{
	"Powershell execution error"
	write-output $_
	exit 1
}

# Paths

$solutionFilePath = "src/JiraTimers.sln"
$projectPath = "\src\JiraTimers"
$publishProfileName = "Release-Win"

$workingDirectory = Get-Location
$winReleasePath = Join-Path $projectPath "publish-win"
$fullReleasePath = Join-Path $workingDirectory $winReleasePath
$appDllPath = Join-Path $fullReleasePath "JiraTimers.dll"

$chocoPackageFilesPath = ".\chocolatey-package"
$nuspecFilePath = Join-Path $chocoPackageFilesPath "jiratimers.nuspec"
$verificationFilePath = Join-Path $chocoPackageFilesPath "VERIFICATION.txt"

$setupProjectPath = "src/JiraTimers.Setup/JiraTimers.Setup.vdproj"
$devenvPath = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.com"

# Build process

"1/8: Build windows release..."

dotnet publish $solutionFilePath -p:PublishProfile=$publishProfileName

if ($LastExitCode -ne 0)
{
	exit 0
}

"2/8: Retrieve app version"
$version = [Reflection.AssemblyName]::GetAssemblyName($appDllPath).Version.ToString(3)

"3/8: Patch MSI project version..."

((Get-Content -Path $setupProjectPath -Raw) -replace '{version}', $version) | Set-Content -Path $setupProjectPath

if ($LastExitCode -ne 0)
{
	exit 0
}

"4/8: Build MSI version..."

& $devenvPath $setupProjectPath /build Release /projectconfig Release

if ($LastExitCode -ne 0)
{
	exit 0
}

"5/8: Create zip archive"

$archiveName = "JiraTimers." + $version + ".zip"
$compressPath = $fullReleasePath + "/*"

Compress-Archive -Path $compressPath -DestinationPath $archiveName

if ($LastExitCode -ne 0)
{
	exit 0
}

"6/8: Checksum calculation"

$cheksum = (Get-FileHash -Path $archiveName -Algorithm SHA256).Hash

if ($LastExitCode -ne 0)
{
	exit 0
}

"7/8 Inject checksum to VERIFICATION.txt"

((Get-Content -Path $verificationFilePath -Raw) -replace '{checksum}', $cheksum) | Set-Content -Path $verificationFilePath

if ($LastExitCode -ne 0)
{
	exit 0
}

"8/8: Pack Choco package..."

choco pack $nuspecFilePath --version $version

exit $LastExitCode