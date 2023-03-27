param (
    [Parameter(Mandatory=$true)] [string]$migrationLabel
)

cd $PSScriptRoot

&dotnet ef migrations --verbose add $migrationLabel --startup-project ..\..\Unic.Demo\ --output-dir Migrations --context AppDbContext
