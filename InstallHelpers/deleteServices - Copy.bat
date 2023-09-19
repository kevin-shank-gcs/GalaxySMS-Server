echo off
net stop GalaxySMS.Api > %temp%\GalaxySMS_deleteServices.txt
net stop GalaxySMS.JobProcessor >> %temp%\GalaxySMS_deleteServices.txt
net stop GalaxySMS.Distributor >> %temp%\GalaxySMS_deleteServices.txt
net stop GalaxySMS.Recorder >> %temp%\GalaxySMS_deleteServices.txt
net stop GalaxySMS.Core >> %temp%\GalaxySMS_deleteServices.txt
net stop GalaxySMS.Cdn > %temp%\GalaxySMS_deleteServices.txt
net stop GalaxySMS.SignalR >> %temp%\GalaxySMS_deleteServices.txt

sc delete GalaxySMS.JobProcessor >> %temp%\GalaxySMS_deleteServices.txt
sc delete GalaxySMS.Recorder >> %temp%\GalaxySMS_deleteServices.txt
sc delete GalaxySMS.Distributor >> %temp%\GalaxySMS_deleteServices.txt
sc delete GalaxySMS.Core >> %temp%\GalaxySMS_deleteServices.txt
sc delete GalaxySMS.Api >> %temp%\GalaxySMS_deleteServices.txt
sc delete GalaxySMS.Cdn >> %temp%\GalaxySMS_deleteServices.txt
sc delete GalaxySMS.SignalR >> %temp%\GalaxySMS_deleteServices.txt

netsh http delete urlacl url=http://+:38000/ >> %temp%\GalaxySMS_deleteServices.txt
REM netsh http delete urlacl url=https://+:0/ >> %temp%\GalaxySMS_deleteServices.txt
netsh http delete urlacl url=http://+:38002/ >> %temp%\GalaxySMS_deleteServices.txt
REM netsh http delete urlacl url=https://+:0/ >> %temp%\GalaxySMS_deleteServices.txt
netsh http delete urlacl url=http://+:38004/ >> %temp%\GalaxySMS_deleteServices.txt
REM netsh http delete urlacl url=https://+:0/ >> %temp%\GalaxySMS_deleteServices.txt

notepad.exe %temp%\GalaxySMS_deleteServices.txt
pause
