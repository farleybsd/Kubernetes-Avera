var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/shutdown", () =>
{
    Console.WriteLine("Stopping application...");
    Results.Ok("Shutting down...");
});

app.Run();
