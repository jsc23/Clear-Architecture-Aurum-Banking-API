using Aurum.Api;
using Scalar.AspNetCore;
using Aurum.Application;
using Aurum.Infrastructure;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Aurum Banking API";
    config.Version = "v1";
});

builder.Services.AddCors(options => options.AddPolicy("NgOrigins",
    policy => policy.WithOrigins("http://localhost:7220")
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

var app = builder.Build();

app.UseOpenApi(options =>
{
    options.Path = "/openapi/{documentName}.json";
});

app.MapScalarApiReference(options =>
{
    options.Title = "Aurum Banking API";
    options.Theme = ScalarTheme.DeepSpace;
});

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseCors("NgOrigins");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();