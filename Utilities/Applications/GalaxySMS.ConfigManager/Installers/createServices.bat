REM run as Admin
sc create GCS.Screener.Api start= auto obj=".\GalaxyServiceAccount" password="GCS.5560" binPath= "c:\GCS\GCS.Screener\Api\GCS.Screener.Api.exe" 

sc create GCS.Screener.WebApp start= auto obj=".\GalaxyServiceAccount" password="GCS.5560" depend= GCS.Screener.Api binPath= "c:\GCS\GCS.Screener\UI\GCS.Screener.Server.exe" 
pause