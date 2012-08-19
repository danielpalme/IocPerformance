param($rootPath, $toolsPath, $package, $project)

$projectPath = Split-Path $project.FullName

$filePath = Join-Path $projectPath "ServiceContainer.cs"

if (Test-Path $filePath)
{
	$project.ProjectItems.Item("ServiceContainer.cs").Delete()
}

