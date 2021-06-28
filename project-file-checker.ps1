param([int]$action)

if ($action -eq 0)
{
    "" | Out-File "flag-old"
}

if ($action -eq 1)
{
    "" | Out-File "flag-new"
}

if ($action -eq 2)
{
    Remove-Item ("flag-old", "flag-new")
}