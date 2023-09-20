netsh http add urlacl url=http://+:8000/ user=Everyone
netsh http add urlacl url=https://+:8443/ user=Everyone
rem The following appid is for UISelfHost.exe
rem netsh http add sslcert ipport=0.0.0.0:8443 certhash=06bb701c0d4befecc9c3a00f66917d721d51f9db appid={258ae4ca-f7c9-41e3-a46e-fb3a7e663b19}
rem The following appid is for the GCS.WebApi.WindowsService.exe
netsh http add sslcert ipport=0.0.0.0:8443 certhash=6833a2bf69a48b65090fd2cd097442f47f49d8ed appid={a94469c6-a1c1-4c07-93f0-e80e7871d723}
PAUSE