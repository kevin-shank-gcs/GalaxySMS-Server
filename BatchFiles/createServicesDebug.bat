echo on
%systemroot%\system32\sc create GalaxySMS.Recorder-Debug start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Recorder\GalaxySMS.MessageQueue.Processor.exe" > %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc create GalaxySMS.Distributor-Debug start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\GalaxySMS.MessageQueue.Processor.exe" >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc create GalaxySMS.Core-Debug start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Core\bin\Debug\GalaxySMS.Core.exe" >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc create GalaxySMS.Api-Debug start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Api\bin\Debug\net5.0\GalaxySMS.Api.exe" >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc create GalaxySMS.Cdn-Debug start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.Cdn\bin\Debug\net6.0\GalaxySMS.Cdn.exe" >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc create GalaxySMS.SignalR-Debug start= auto obj=".\GCSServiceAccount" password="G@laxyServ1ce" binPath= "D:\Dev\GalaxySMS\GalaxySMS.SignalR\bin\Debug\net6.0\GalaxySMS.SignalR.exe" >> %temp%\GalaxySMS_createServices-Debug.txt

REM %systemroot%\system32\netsh http add urlacl url=http://+:38000/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices-Debug.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:SIGNALR_HTTPS_PORT/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices-Debug.txt
REM %systemroot%\system32\netsh http add urlacl url=http://+:38002/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices-Debug.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:API_HTTPS_PORT/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices-Debug.txt
REM %systemroot%\system32\netsh http add urlacl url=http://+:38004/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices-Debug.txt
REM %systemroot%\system32\netsh http add urlacl url=https://+:CDN_HTTPS_PORT/ user=GCSServiceAccount >> %temp%\GalaxySMS_createServices-Debug.txt

icacls "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices-Debug.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Recorder" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices-Debug.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.Core\bin\Debug" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices-Debug.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.Api\bin\Debug\net5.0" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices-Debug.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.Cdn\bin\Debug\net6.0" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices-Debug.txt
icacls "D:\Dev\GalaxySMS\GalaxySMS.SignalR\bin\Debug\net6.0" /T /C /inheritance:e /grant GCSServiceAccount:(F) >> %temp%\GalaxySMS_createServices-Debug.txt

%systemroot%\system32\sc start GalaxySMS.Core-Debug >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc start GalaxySMS.SignalR-Debug >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc start GalaxySMS.Recorder-Debug >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc start GalaxySMS.Distributor-Debug >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc start GalaxySMS.Api-Debug >> %temp%\GalaxySMS_createServices-Debug.txt
%systemroot%\system32\sc start GalaxySMS.Cdn-Debug >> %temp%\GalaxySMS_createServices-Debug.txt

start %temp%\GalaxySMS_createServices-Debug.txt

pause
