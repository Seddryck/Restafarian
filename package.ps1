if (Test-Path "./.publish") {
    Remove-Item -Recurse -Force "./.publish"
}

$projects = @(
  "src/Restafarian.Core/Restafarian.Core.csproj",
  "src/Restafarian.Cli/Restafarian.Cli.csproj"
)
$frameworks = @("net8.0", "net9.0")
$runtimes = ("win-x64", "linux-x64")

foreach ($project in $projects) {
    foreach ($framework in $frameworks) {
        foreach ($runtime in $runtimes) {
            Write-Host "Building $project for $framework on $runtime ..."
            dotnet build $project -p:version="$env:GitVersion_SemVer" -c Release -f $framework -r $runtime /p:ContinuousIntegrationBuild=true --nologo
            if ($project -like "*Restafarian.Cli*") {
                Write-Host "Packaging .exe artifacts $project for $framework on $runtime..."
                dotnet publish $project -c Release -f $framework -r $runtime --no-self-contained -o ./.publish/$framework/$runtime --no-build --nologo
                7z a ./.publish/Restafarian-$env:GitVersion_SemVer-$framework-$runtime.zip ./.publish/$framework/$runtime/*.*
            }
        }
    }
    Write-Host "Packaging Nuget $project ..."
    dotnet pack $project -p:version="$env:GitVersion_SemVer" -c Release --include-symbols --no-build --nologo
}    
