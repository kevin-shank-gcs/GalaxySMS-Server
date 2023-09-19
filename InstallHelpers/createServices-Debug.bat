echo off
%systemroot%\system32\sc create GalaxySMS.SignalR obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.SignalR\bin\Debug\net6.0\GalaxySMS.SignalR.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Cdn obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Cdn\bin\Debug\net6.0\GalaxySMS.Cdn.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Core depend= MSMQ obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Core\bin\Debug\GalaxySMS.Core.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Api obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "C:\Program Files (x86)\Galaxy Control Systems\GalaxySMS\Server\Api\GalaxySMS.Api.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Recorder depend= MSMQ obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Recorder\GalaxySMS.MessageQueue.Processor.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Distributor depend= MSMQ obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Distributor\GalaxySMS.MessageQueue.Processor.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.JobProcessor depend= MSMQ obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\JobProcessor\GalaxySMS.MessageQueue.Processor.exe" >> %temp%\GalaxySMS_createServices.txt

REM %systemroot%\system32\netsh http add urlacl url=http://+:38000/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:0/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=http://+:38002/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:0/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=http://+:38004/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:0/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt

icacls "C:\Program Files (x86)\Galaxy Control Systems\GalaxySMS\Server" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices.txt

REM %systemroot%\system32\sc start GalaxySMS.SignalR >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\sc start GalaxySMS.Cdn >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\sc start GalaxySMS.Core >> %temp%\GalaxySMS_createServices.txt
REM timeout /t 10 /nobreak
REM %systemroot%\system32\sc start GalaxySMS.Api >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\sc start GalaxySMS.Recorder >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\sc start GalaxySMS.Distributor >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\sc start GalaxySMS.JobProcessor >> %temp%\GalaxySMS_createServices.txt

REM start %temp%\GalaxySMS_createServices.txt

rem rem pause
