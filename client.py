from socket import *
from constCS import *

s = socket(AF_INET, SOCK_STREAM)
s.connect((HOST, PORT))

# Exemplo de comandos que serão interpretados pelo server.py
commands = [
    "temperature;100;Celsius;Fahrenheit",
    "length;1;Meters;Miles",
    "weight;5;Kilograms;Pounds"
]

for cmd in commands:
    s.send(str.encode(cmd))
    data = s.recv(1024)
    print("Resposta:", bytes.decode(data))

s.close()
