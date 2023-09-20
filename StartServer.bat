rem net stop GalaxySMS.ServiceHost.Console
taskkill /F /IM GalaxySMS.Admin.exe
taskkill /F /IM GalaxySMS.ClientApi.Sample.exe
taskkill /F /IM GalaxySMS.FacilityManager.exe

taskkill /F /IM GalaxySMS.MessageQueue.Handler.exe
taskkill /F /IM GalaxySMS.ServiceHost.Console.exe
taskkill /F /IM GalaxySMS.Api.exe

e:
cd "E:\Dev\GalaxySMS\GalaxySMS.ServiceHost.Console\bin\Release"
start GalaxySMS.ServiceHost.Console.exe
TIMEOUT 5
cd "E:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release"
start GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:galaxypanelmessage
start GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:galaxypanelmessagerecorder

cd "E:\Dev\GalaxySMS\GalaxySMS.Api\bin\Release\netcoreapp2.2\publish"
start GalaxySMS.Api.exe

rem pause