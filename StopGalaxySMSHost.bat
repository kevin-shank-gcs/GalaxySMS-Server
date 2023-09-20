rem net stop GalaxySMS.ServiceHost.Console
taskkill /F /IM GalaxySMS.MessageQueue.Handler.exe
taskkill /F /IM GalaxySMS.ServiceHost.Console.exe
taskkill /F /IM GalaxySMS.Api.exe
