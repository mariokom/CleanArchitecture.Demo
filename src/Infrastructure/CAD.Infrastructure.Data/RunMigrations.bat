cd %~dp0

powershell.exe -executionpolicy bypass -File "./AddMigrations.ps1"

pause;