from socket import *
from constCS import *
import requests
from sshtunnel import SSHTunnelForwarder

# Configurações do SSH e da API na AWS
AWS_HOST = "ec2-3-94-179-36.compute-1.amazonaws.com"
SSH_USERNAME = ""  
PEM_FILE_PATH = "" 
API_REMOTE_PORT = 8091  

def get_api_base_url():
    """
    Cria um túnel SSH para a instância AWS e retorna a URL base para acessar a API.
    """
    tunnel = SSHTunnelForwarder(
        (AWS_HOST, 22),
        ssh_username=SSH_USERNAME,
        ssh_pkey=PEM_FILE_PATH,
        remote_bind_address=('localhost', API_REMOTE_PORT)
    )
    tunnel.start()
    local_port = tunnel.local_bind_port
    base_url = f"http://localhost:{local_port}"
    return base_url, tunnel

def handle_conversion_request(request: str) -> str:
    try:
        # Exemplo de mensagem: "temperature;100;Celsius;Fahrenheit"
        parts = request.strip().split(";")
        conv_type = parts[0].lower()
        value = float(parts[1])
        from_unit = parts[2]
        to_unit = parts[3]

        # Define o endpoint de acordo com o tipo de conversão
        if conv_type == "temperature":
            endpoint = "/convertTemperature"
        elif conv_type == "length":
            endpoint = "/convertLength"
        elif conv_type == "weight":
            endpoint = "/convertWeight"
        else:
            return f"Tipo de conversão inválido: {conv_type}"

        # Cria o túnel SSH e define a URL base da API
        base_url, tunnel = get_api_base_url()

        # Realiza a requisição HTTP para a API
        response = requests.get(
            f"{base_url}{endpoint}",
            params={"value": value, "fromUnit": from_unit, "toUnit": to_unit},
            timeout=10  # tempo limite em segundos
        )
        tunnel.stop()  # encerra o túnel após a requisição

        if response.ok:
            json_data = response.json()
            return f"{json_data['OriginalValue']} {json_data['FromUnit']} = {json_data['ConvertedValue']} {json_data['ToUnit']}"
        else:
            return f"Erro ao acessar a API: {response.status_code}"

    except Exception as e:
        return f"Erro no processamento: {str(e)}"

# Código do servidor via socket
s = socket(AF_INET, SOCK_STREAM)
s.bind((HOST, PORT))
s.listen(1)
print("Aguardando conexão...")

(conn, addr) = s.accept()
print(f"Conectado a {addr}")

while True:
    data = conn.recv(1024)
    if not data:
        break
    request_text = bytes.decode(data)
    print("Recebido:", request_text)

    response_text = handle_conversion_request(request_text)
    conn.send(str.encode(response_text))

conn.close()
