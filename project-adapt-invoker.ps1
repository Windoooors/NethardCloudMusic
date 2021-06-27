$proj_dir = "Nethard Music"
$old_proj_path = "$proj_dir/Nethard Music-vs2008.csproj"
$new_proj_path = "$proj_dir/Nethard Music.csproj"

$script_path = "project-adapt.ps1"

$diff = git diff-tree --no-commit-id --name-only -r HEAD

$old_edited = $diff.contains($old_proj_path)
$new_edited = $diff.contains($new_proj_path)

if ($old_edited -and $new_edited)
{
    throw "Cannot merge automatically."
}

if ($old_edited)
{
    Invoke-Expression ".\$script_path 0"
}
elseif ($new_edited)
{
    Invoke-Expression ".\$script_path 1"
}