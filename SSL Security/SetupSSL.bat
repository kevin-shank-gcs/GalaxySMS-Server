netsh http add urlacl url=http://+:8000/ user=Everyone
netsh http add urlacl url=https://+:8443/ user=Everyone
netsh http add sslcert ipport = 0.0.0.0:8443 certhash = 06bb701c0d4befecc9c3a00f66917d721d51f9db appid = {a94469c6-a1c1-4c07-93f0-e80e7871d723}
pause


netsh http add urlacl url=http://+:15000/ user=Everyone
netsh http add urlacl url=https://+:15001/ user=Everyone
netsh http add sslcert ipport = 0.0.0.0:15001 certhash = 06bb701c0d4befecc9c3a00f66917d721d51f9db appid = {a94469c6-a1c1-4c07-93f0-e80e7871d723}
netsh http add urlacl url=http://+:25000/ user=Everyone
netsh http add urlacl url=https://+:25001/ user=Everyone
netsh http add sslcert ipport = 0.0.0.0:25001 certhash = 06bb701c0d4befecc9c3a00f66917d721d51f9db appid = {a94469c6-a1c1-4c07-93f0-e80e7871d723}
