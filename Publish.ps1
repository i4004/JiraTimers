$winReleasePath = "./src/JiraTimers/publish-win"
$nuspecFileName = "jiratimers.nuspec"

dotnet publish src/JiraTimers.sln -p:PublishProfile=Release-Win
Copy-Item -Path $nuspecFileName -Destination $winReleasePath/$nuspecFileName
cd $winReleasePath
choco pack