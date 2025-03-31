[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/qjXMgXsV)
# ClientServerBasics (2.0)
Starter code for the basic client-server assignment


Este template corresponde ao exemplo da Fig. 2.3 do livro. O exercício consiste em acrescentar funcionalidade ao servidor para torná-lo mais útil. Essa funcionalidade deve ser acessível aos clientes. Por exemplo, o servidor pode ser uma espécie de calculadora remota. O cliente passa dois valores numéricos, juntamente com o nome de uma operação (ex.: add, subtract, multiply, divide) e o servidor executa a operação respectiva e retorna seu resultado para o cliente. Você pode implementar outro tipo de servidor (diferente da calculadora). O imporante é que ele ofereça pelo menos três operações diferentes que os clientes podem utilizar remotamente, passando dados para serem processados e recebendo o resultado desse processamento como resposta.

Tarefa individual.

Incluir um Readme descritivo do sistema implementado.

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

