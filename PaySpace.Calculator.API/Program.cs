using PaySpace.Calculator.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ApplicationsServices(builder.Configuration);

var app = builder.Build();

app.UseApplication();

app.Run();