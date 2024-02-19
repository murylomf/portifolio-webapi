using Portifolio.Webapi.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.ApplyMigrations();
app.Run();