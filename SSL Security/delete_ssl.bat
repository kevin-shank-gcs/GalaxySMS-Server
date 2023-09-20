netsh http delete urlacl url=http://+:8000/
netsh http delete urlacl url=https://+:8443/
netsh http delete sslcert ipport=0.0.0.0:8443  
PAUSE