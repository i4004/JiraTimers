
$drop = Join-Path (Split-Path -parent $MyInvocation.MyCommand.Definition) "app"
$exeName = "JiraTimers.exe"
$exe = Join-Path $drop $exeName

Install-ChocolateyShortcut $exe
