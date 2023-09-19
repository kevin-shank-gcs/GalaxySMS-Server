SC STOP GalaxySMS.Recorder
SC STOP GalaxySMS.Distributor
SC STOP GalaxySMS.JobProcessor

copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\*.*" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Distributor" 
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\*.*" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Recorder" 
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\*.*" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\JobProcessor" 

copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Distributor\GalaxySMS.MessageQueue.Processor.exe-distributor.config" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Distributor\GalaxySMS.MessageQueue.Processor.exe.config"
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Recorder\GalaxySMS.MessageQueue.Processor.exe-recorder.config" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\Recorder\GalaxySMS.MessageQueue.Processor.exe.config"
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\JobProcessor\GalaxySMS.MessageQueue.Processor.exe-jobprocessor.config" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Release\JobProcessor\GalaxySMS.MessageQueue.Processor.exe.config"
rem pause