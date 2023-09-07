# In case of execution policy issues, run with command: powershell.exe -executionpolicy bypass -file .\AddMigrations.ps1

param (
    [Parameter(Mandatory=$true)] [string]$migrationLabel
)

cd $PSScriptRoot

&dotnet ef migrations --verbose add $migrationLabel --startup-project ..\..\CAD.Demo\ --output-dir Migrations --context CompanyDbContext
