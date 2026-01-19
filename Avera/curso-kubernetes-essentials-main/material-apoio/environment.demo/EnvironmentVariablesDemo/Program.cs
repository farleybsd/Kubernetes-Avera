var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var app = builder.Build();
app.UseCustomSwagger();

app.MapGet("/configuration", (IConfiguration config) =>
{
    return config.AsEnumerable().ToDictionary(k => k.Key, v => v.Value);
});

app.MapGet("/configuration/{key}", (IConfiguration config, string key) =>
{
    var value = config[key];
    if (value != null)
    {
        return Results.Ok(new { Key = key, Value = value });
    }
    else
    {
        return Results.NotFound($"Configuracaoo com chave '{key}' nao encontrada.");
    }
});
app.Run();
