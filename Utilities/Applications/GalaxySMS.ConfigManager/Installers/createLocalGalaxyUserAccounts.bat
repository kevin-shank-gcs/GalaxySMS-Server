REM This must be run as and Administrator

cd INSTALLFOLDER

REM Create Groups
net localgroup GCSAdmins /add
net localgroup GCSClients /add

net user /add GalaxyServiceAccount GCS.5560
net localgroup GCSAdmins GalaxyServiceAccount /add


net user /add GalaxyClientAccount GCS.5560
net localgroup GCSClients GalaxyClientAccount /add

"C:\GCS\GCS.Screener\Install\ntrights" +r SeServiceLogonRight -u "GalaxyServiceAccount"
"C:\GCS\GCS.Screener\Install\ntrights" +r SeServiceLogonRight -u "GalaxyClientAccount"
pause