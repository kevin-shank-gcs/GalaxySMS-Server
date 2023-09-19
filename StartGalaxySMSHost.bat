rem net stop GalaxySMS.ServiceHost.Console
taskkill /F /IM GalaxySMS.MessageQueue.Handler.exe
taskkill /F /IM GalaxySMS.ServiceHost.Console.exe
taskkill /F /IM GalaxySMS.Api.exe

start E:\Dev\GalaxySMS\GalaxySMS.ServiceHost.Console\bin\Release\GalaxySMS.ServiceHost.Console.exe
timeout 4
start E:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release\GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:galaxypanelmessage
start E:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release\GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:galaxypanelmessagerecorder
e:
cd E:\Dev\GalaxySMS\GalaxySMS.Api\bin\Debug\netcoreapp2.2\publish
start E:\Dev\GalaxySMS\GalaxySMS.Api\bin\Debug\netcoreapp2.2\publish\GalaxySMS.Api.exe
rem start E:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug\GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:galaxypanelmessagedecoder
rem pause