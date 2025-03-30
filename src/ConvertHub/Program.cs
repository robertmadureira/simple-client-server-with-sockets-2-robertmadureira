var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adicionar as rotas de conversão de unidades

app.MapGet("/convertTemperature", (double value, string fromUnit, string toUnit) =>
{
    var temperatureConversion = new TemperatureConversion(value, fromUnit, toUnit);
    return Results.Ok(new
    {
        OriginalValue = value,
        FromUnit = fromUnit,
        ToUnit = toUnit,
        ConvertedValue = temperatureConversion.ConvertedValue
    });
})
.WithName("ConvertTemperature")
.WithOpenApi();

app.MapGet("/convertLength", (double value, string fromUnit, string toUnit) =>
{
    var lengthConversion = new LengthConversion(value, fromUnit, toUnit);
    return Results.Ok(new
    {
        OriginalValue = value,
        FromUnit = fromUnit,
        ToUnit = toUnit,
        ConvertedValue = lengthConversion.ConvertedValue
    });
})
.WithName("ConvertLength")
.WithOpenApi();

app.MapGet("/convertWeight", (double value, string fromUnit, string toUnit) =>
{
    var weightConversion = new WeightConversion(value, fromUnit, toUnit);
    return Results.Ok(new
    {
        OriginalValue = value,
        FromUnit = fromUnit,
        ToUnit = toUnit,
        ConvertedValue = weightConversion.ConvertedValue
    });
})
.WithName("ConvertWeight")
.WithOpenApi();

app.Run();

// Definição dos records para conversões

public record TemperatureConversion(double Value, string FromUnit, string ToUnit)
{
    public double ConvertedValue => FromUnit switch
    {
        "Celsius" when ToUnit == "Fahrenheit" => Value * 9 / 5 + 32,
        "Celsius" when ToUnit == "Kelvin" => Value + 273.15,
        "Fahrenheit" when ToUnit == "Celsius" => (Value - 32) * 5 / 9,
        "Fahrenheit" when ToUnit == "Kelvin" => (Value - 32) * 5 / 9 + 273.15,
        "Kelvin" when ToUnit == "Celsius" => Value - 273.15,
        "Kelvin" when ToUnit == "Fahrenheit" => (Value - 273.15) * 9 / 5 + 32,
        _ => Value // Caso as unidades sejam iguais, retorna o valor original
    };
}

public record LengthConversion(double Value, string FromUnit, string ToUnit)
{
    public double ConvertedValue => FromUnit switch
    {
        "Meters" when ToUnit == "Kilometers" => Value / 1000,
        "Kilometers" when ToUnit == "Meters" => Value * 1000,
        "Miles" when ToUnit == "Meters" => Value * 1609.34,
        "Meters" when ToUnit == "Miles" => Value / 1609.34,
        "Yards" when ToUnit == "Meters" => Value * 0.9144,
        "Meters" when ToUnit == "Yards" => Value / 0.9144,
        _ => Value // Caso as unidades sejam iguais, retorna o valor original
    };
}

public record WeightConversion(double Value, string FromUnit, string ToUnit)
{
    public double ConvertedValue => FromUnit switch
    {
        "Grams" when ToUnit == "Kilograms" => Value / 1000,
        "Kilograms" when ToUnit == "Grams" => Value * 1000,
        "Pounds" when ToUnit == "Kilograms" => Value / 2.20462,
        "Kilograms" when ToUnit == "Pounds" => Value * 2.20462,
        _ => Value // Caso as unidades sejam iguais, retorna o valor original
    };
}
