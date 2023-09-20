echo off

for /F "tokens=2-4 delims=/ " %%v in ('date /T') do (
set month=%%v
set day=%%w
set year=%%x)

for /F "tokens=1-3 delims=: " %%v in ('time /T') do (
set hour=%%v
set minute=%%w
set ampm=%%x)

echo on
mkdir %~dp0\%month%-%day%-%year%_%hour%_%minute%_%ampm%

call mssql-scripter -S .\SQL2016DEV -d GalaxySMS -U sa -P GCSsa5560 -f %month%-%day%-%year%_%hour%_%minute%_%ampm%\Create-GalaxySMS.sql --object-permissions
call mssql-scripter -S .\SQL2016DEV -d GalaxySMS-AuditActivity -U sa -P GCSsa5560 -f %month%-%day%-%year%_%hour%_%minute%_%ampm%\Create-GalaxySMS-AuditActivity.sql --object-permissions

pause
