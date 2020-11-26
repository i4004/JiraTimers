
$drop = Join-Path (Split-Path -parent $MyInvocation.MyCommand.Definition) "app"
$exeName = "JiraTimers.exe"
$exePath = Join-Path $drop $exeName

Install-ChocolateyShortcut $exePath
