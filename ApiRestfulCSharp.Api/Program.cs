using ApiRestfulCSharp.Api.Configurations;
using ApiRestfulCSharp.Api.Extensions;
using ApiRestfulCSharp.Api.Middlewares;
using ApiRestfulCSharp.Application;
using ApiRestfulCSharp.Infrastructure;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<DomainExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalFallbackExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.ConfigureOptions<ConfigureApiVersioningOptions>();

builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithVersioning();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();