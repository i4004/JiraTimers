$exeFileName = "JiraTimers.exe"
$linkName = "JiraTimers.lnk"
$appPath = Join-Path (Split-Path -parent $MyInvocation.MyCommand.Definition) "app"
$programsPath = [environment]::GetFolderPath([environment+specialfolder]::Programs)
$exeFilePath = Join-Path $appPath $exeFileName
$shortcutFilePath = Join-Path $programsPath $linkName

Install-ChocolateyShortcut -shortcutFilePath $shortcutFilePath -targetPath $exeFilePath -WorkingDirectory $appPath
