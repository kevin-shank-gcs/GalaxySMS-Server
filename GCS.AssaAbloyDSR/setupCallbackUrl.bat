netsh http delete urlacl url=http://+:9090/Callback
pause
netsh http add urlacl url=http://+:9090/Callback user=Everyone
pause