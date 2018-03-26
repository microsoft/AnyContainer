function ExitIfFailed()
{
    if ($LASTEXITCODE -ne 0)
    {
        Write-Host "An error occurred. Stopping build." -foregroundcolor "red"
        Pause
        exit
    }
}

function CopyNupkg($projectFolder)
{
    $releaseFolder = $projectFolder + "/bin/Release"
    $nupkgFiles = Get-ChildItem -Path $releaseFolder -Filter *.nupkg -File
    foreach ($file in $nupkgFiles)
    {
        Copy-Item $file.FullName -Destination "Packages"
    }
}

$VSFolder = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional"
$MsBuildExe = "$VSFolder\MSBuild\15.0\Bin\MSBuild.exe"


& $MsBuildExe AnyContainer.sln /t:pack "/p:Configuration=Release;Platform=Any CPU"; ExitIfFailed

if (!(Test-Path -Path "Packages"))
{
    New-Item -ItemType Directory -Path "Packages"
}

$projectFolders = Get-ChildItem -Path .\ -Directory -Name
foreach ($pFolder in $projectFolders)
{
    if ($pFolder.StartsWith("AnyContainer"))
    {
        CopyNupkg $pFolder
    }
}