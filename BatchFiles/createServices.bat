echo on
%systemroot%\system32\sc create GalaxySMS.Recorder start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Recorder\GalaxySMS.MessageQueue.Processor.exe" > %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Distributor start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\GalaxySMS.MessageQueue.Processor.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Core start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Core\bin\Release\GalaxySMS.Core.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Api start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Api\bin\Release\net5.0\GalaxySMS.Api.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.Cdn start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Cdn\bin\Release\net6.0\GalaxySMS.Cdn.exe" >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc create GalaxySMS.SignalR start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.SignalR\bin\Release\net6.0\GalaxySMS.SignalR.exe" >> %temp%\GalaxySMS_createServices.txt

%systemroot%\system32\netsh http add urlacl url=http://+:38000/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:SIGNALR_HTTPS_PORT/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\netsh http add urlacl url=http://+:38002/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:API_HTTPS_PORT/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\netsh http add urlacl url=http://+:38004/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:CDN_HTTPS_PORT/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices.txt

icacls "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.Core\bin\Release" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.Api\bin\Release\net5.0" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.Cdn\bin\Release\net6.0" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.SignalR\bin\Release\net6.0" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices.txt

%systemroot%\system32\sc start GalaxySMS.Core >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc start GalaxySMS.SignalR >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc start GalaxySMS.Recorder >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc start GalaxySMS.Distributor >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc start GalaxySMS.Api >> %temp%\GalaxySMS_createServices.txt
%systemroot%\system32\sc start GalaxySMS.Cdn >> %temp%\GalaxySMS_createServices.txt

start %temp%\GalaxySMS_createServices.txt

pause
