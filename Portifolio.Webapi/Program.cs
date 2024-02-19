using Carter;
using Carter.OpenApi;
using Portifolio.Webapi;
using Portifolio.Webapi.Common.Extensions;
using Portifolio.Webapi.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = AppSettings.Configuration();

builder.Services
    .AddWebApi(configuration)
    .AddSwagger();


var app = builder.Build();

app.MapGet("/hello", () => "Hello World!").WithTags("Ged")
    .WithName("hello")
    .IncludeInOpenApi();

app.ApplyMigrations();
app.UseSwagger();
app.UseSwaggerUI();
app.MapCarter();
app.Run();