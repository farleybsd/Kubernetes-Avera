using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Lê o arquivo de configuração
builder.Configuration.AddJsonFile(ConfigMapFileProvider.FromRelativePath(builder.Configuration["CotacaoFilePath"]), "cotacoes.json", false, true);
builder.Services.Configure<Dictionary<string, decimal>>(builder.Configuration.GetSection("Moedas"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var app = builder.Build();
app.UseCustomSwagger();


app.MapGet("conversoes", ([FromServices] IConfiguration configuration) =>
{
    var cotacoes = configuration.GetSection("Moedas").Get<Dictionary<string, decimal>>();
    return Results.Ok(cotacoes);
});

app.MapGet("dolar/{moeda}/{valor}", (
    [FromServices] IConfiguration configuration,
    string moeda,
    decimal valor) =>
{
    var cotacoes = configuration.GetSection("Moedas").Get<Dictionary<string, decimal>>();
    if (!cotacoes.ContainsKey(moeda.ToUpper()))
        return Results.NotFound();

    var taxaDeConversao = cotacoes[moeda.ToUpper()];
    var valorConvertido = Math.Round(valor / taxaDeConversao, 2);

    return Results.Ok(valorConvertido);
});

app.MapGet("taxa-cambio", (
    [FromServices] IConfiguration configuration,
    string moedaOrigem,
    string moedaDestino,
    decimal valor) =>
{
    var cotacoes = configuration.GetSection("Moedas").Get<Dictionary<string, decimal>>();

    if (!cotacoes.ContainsKey(moedaOrigem.ToUpper()))
        return Results.NotFound("Moeda de origem não encontrada.");

    if (!cotacoes.ContainsKey(moedaDestino.ToUpper()))
        return Results.NotFound("Moeda de destino não encontrada.");

    var taxaDeConversaoOrigem = cotacoes[moedaOrigem.ToUpper()];
    var valorEmDolar = valor / taxaDeConversaoOrigem;

    var taxaDeConversaoDestino = cotacoes[moedaDestino.ToUpper()];
    var valorConvertido = valorEmDolar * taxaDeConversaoDestino;

    return Results.Ok(valorConvertido);
});


app.Run();
