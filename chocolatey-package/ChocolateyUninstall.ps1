$linkName = "JiraTimers.lnk"
$programsPath = [environment]::GetFolderPath([environment+specialfolder]::Programs)
$shortcutFilePath = Join-Path $programsPath $linkName

if (Test-Path $shortcutFilePath)
{
	Remove-Item $shortcutFilePath
}