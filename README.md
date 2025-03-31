[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/qjXMgXsV)
# ClientServerBasics (2.0)
Starter code for the basic client-server assignment

-----------------------------------------------------------------------------

# Projeto de Integração de API com Comunicação via Sockets e Túnel SSH

Este projeto demonstra como integrar uma API de conversão de unidades (implementada em C#) com um servidor e cliente Python que se comunicam via sockets. O servidor Python, ao receber um comando do cliente, estabelece um túnel SSH com uma instância AWS para consumir a API e retornar o resultado ao cliente.

## Arquivos do Projeto

- **server.py**: Servidor Python que recebe requisições via socket, cria um túnel SSH para a instância AWS e consome a API.
- **client.py**: Cliente Python que envia comandos formatados ao servidor.
- **constCS.py**: Configurações de conexão para a comunicação entre cliente e servidor.
- **Arquivo .pem**: Chave privada para conexão SSH com a instância AWS.

## Pré-requisitos

- Python 3.x instalado.
- Instalar os pacotes necessários:

  ```bash
  pip install requests sshtunnel


-----------------------------------------------------------------------------

# API de Conversão de Unidades

Esta API permite realizar conversões entre diferentes unidades de temperatura, comprimento e peso. As conversões podem ser feitas de qualquer unidade válida para outra, desde que as unidades de origem e destino sejam compatíveis. O objetivo é facilitar a conversão de valores em aplicações que lidam com diferentes sistemas de unidades.

## Funcionalidades

A API oferece três principais funcionalidades de conversão:

1. **Temperatura**: Converte entre as unidades **Celsius**, **Fahrenheit** e **Kelvin**.
2. **Comprimento**: Converte entre as unidades **Metros**, **Quilômetros**, **Milhas** e **Jardas**.
3. **Peso**: Converte entre as unidades **Gramas**, **Quilogramas** e **Libras**.

## Estrutura dos Modelos

### 1. `TemperatureConversion`

A conversão de temperatura é realizada através da classe `TemperatureConversion`. Ela recebe três parâmetros:
- `Value`: o valor numérico da temperatura a ser convertida.
- `FromUnit`: a unidade de origem (Celsius, Fahrenheit, Kelvin).
- `ToUnit`: a unidade de destino (Celsius, Fahrenheit, Kelvin).

O cálculo de conversão é feito com base nas fórmulas padrão para conversão entre as unidades de temperatura.

#### Exemplos de uso:
- Celsius para Fahrenheit: \( \text{Valor} \times \frac{9}{5} + 32 \)
- Fahrenheit para Celsius: \( (\text{Valor} - 32) \times \frac{5}{9} \)
- Kelvin para Celsius: \( \text{Valor} - 273.15 \)

### 2. `LengthConversion`

A conversão de comprimento é realizada através da classe `LengthConversion`. Ela recebe três parâmetros:
- `Value`: o valor numérico do comprimento a ser convertido.
- `FromUnit`: a unidade de origem (Metros, Quilômetros, Milhas, Jardas).
- `ToUnit`: a unidade de destino (Metros, Quilômetros, Milhas, Jardas).

O cálculo de conversão é realizado com base nas equivalências entre as unidades de comprimento.

#### Exemplos de uso:
- Metros para Quilômetros: \( \text{Valor} \div 1000 \)
- Quilômetros para Metros: \( \text{Valor} \times 1000 \)
- Milhas para Metros: \( \text{Valor} \times 1609.34 \)
- Metros para Jardas: \( \text{Valor} \div 0.9144 \)

### 3. `WeightConversion`

A conversão de peso é realizada através da classe `WeightConversion`. Ela recebe três parâmetros:
- `Value`: o valor numérico do peso a ser convertido.
- `FromUnit`: a unidade de origem (Gramas, Quilogramas, Libras).
- `ToUnit`: a unidade de destino (Gramas, Quilogramas, Libras).

O cálculo de conversão é feito com base nas equivalências entre as unidades de peso.

#### Exemplos de uso:
- Gramas para Quilogramas: \( \text{Valor} \div 1000 \)
- Quilogramas para Libras: \( \text{Valor} \times 2.20462 \)

## Exemplo de Implementação

### Conversão de Temperatura

```csharp
var temperatureConversion = new TemperatureConversion(25, "Celsius", "Fahrenheit");
Console.WriteLine(temperatureConversion.ConvertedValue);  // 77

