$ErrorActionPreference = "Stop"

$script_path = "project-adapt.ps1"

$old_edited = Test-Path "flag-old"
$new_edited = Test-Path "flag-new"

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