rem @echo off
cd d:\Dev\GalaxySMS\DataProcessors\GalaxySMS.MessageQueue.Handler\bin\debug

start "Panel Message Received Handler" GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:panel_msg

start "Panel Message Recorder Handler" GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:panel_msg_recorder

start "Panel Message Decoder Handler"  GalaxySMS.MessageQueue.Handler.exe -listenOnQueueName:panel_msg_decoder
pause
