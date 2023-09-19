SC STOP GalaxySMS.Recorder-Debug
SC STOP GalaxySMS.Distributor-Debug
SC STOP GalaxySMS.JobProcessor-Debug

copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\*.*" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Distributor" 
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\*.*" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Recorder" 
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\*.*" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\JobProcessor" 

copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Distributor\GalaxySMS.MessageQueue.Processor.exe-distributor.config" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Distributor\GalaxySMS.MessageQueue.Processor.exe.config"
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Recorder\GalaxySMS.MessageQueue.Processor.exe-recorder.config" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\Recorder\GalaxySMS.MessageQueue.Processor.exe.config"
copy "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\JobProcessor\GalaxySMS.MessageQueue.Processor.exe-jobprocessor.config" "D:\Dev\GalaxySMS\GalaxySMS.MessageQueue.Processor\bin\Debug\JobProcessor\GalaxySMS.MessageQueue.Processor.exe.config"
rem pause