call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Debug"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderHandler\bin\Debug"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderSubHandler\bin\Debug"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Debug"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Debug"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Debug"

call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Release"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderHandler\bin\Release"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderSubHandler\bin\Release"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Release"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Release"
call "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\ReferencedFiles\copy_files_to_folders_params.bat" "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Release"

copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\*.dll" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Release"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\*.dll" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Debug"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\Dist-GalaxySMS.MessageQueue.Handler.exe.config" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Debug"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\Dist-GalaxySMS.MessageQueue.Handler.exe.config" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Release"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\Recorder-GalaxySMS.MessageQueue.Handler.exe.config" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Debug"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\Recorder-GalaxySMS.MessageQueue.Handler.exe.config" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Release"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\JobProc-GalaxySMS.MessageQueue.Handler.exe.config" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Debug"
copy "D:\\Dev\\GalaxySMS\\GalaxySMS.MessageQueue.Handler\\ReferencedFiles\\JobProc-GalaxySMS.MessageQueue.Handler.exe.config" "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Release"

if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Debug\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderHandler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderHandler\bin\Debug\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderSubHandler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderSubHandler\bin\Debug\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Debug\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Debug\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Debug\Logfiles
if not exist "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Debug\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Debug\Logfiles

if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageHandler\bin\Release\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderHandler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderHandler\bin\Release\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderSubHandler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageDecoderSubHandler\bin\Release\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderHandler\bin\Release\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Release\Logfiles
if not exist "D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.GalaxyJobHandler\bin\Release\Logfiles
if not exist "D:\\Dev\GalaxySMS\GalaxySMS.MessageQueue.Handler\bin\Release\Logfiles" mkdir D:\\Dev\GalaxySMS\Hosting\GalaxySMS.PanelMessageRecorderSubHandler\bin\Release\Logfiles

exit 0