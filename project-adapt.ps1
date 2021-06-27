param([int]$action)
$ErrorActionPreference = "Stop"

$proj_dir = "C:\Users\mokin\source\repos\nethard-cloud-music\Nethard Music"
$old_proj_path = "$proj_dir\Nethard Music-vs2008.csproj"
$new_proj_path = "$proj_dir\Nethard Music.csproj"

if ($action -eq 0)
{
    $xml = [xml](Get-Content $old_proj_path)
    $xml.Project.SetAttribute("ToolsVersion", "Current")
    $xml.Project.PropertyGroup[0].LangVersion = "3.0"
    $xml.Save($new_proj_path)
}
elseif ($action -eq 1)
{
    $xml = [xml](Get-Content $new_proj_path)
    $xml.Project.SetAttribute("ToolsVersion", "3.5")
    $xml.Project.PropertyGroup[0].LangVersion = "Default"
    $xml.Save($old_proj_path)
}
else
{
    throw
}