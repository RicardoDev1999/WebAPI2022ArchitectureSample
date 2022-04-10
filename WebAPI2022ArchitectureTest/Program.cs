using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MinimalApi.Endpoint.Extensions;
using WebAPI2022ArchitectureTest;
using WebAPI2022ArchitectureTest.Application;
using WebAPI2022ArchitectureTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressInferBindingSourcesForParameters = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI2022ArchitectureTest", Version = "v1" });
    c.EnableAnnotations();
});

// Apply our own Application Layer
builder.Services.AddApplication();

// Apply our own Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);

// Build App
var app = builder.Build();

await DatabaseSeeding.Run(app);

var isDev = app.Environment.IsDevelopment();
app.UseExceptionHandler(isDev ? "/error-dev" : "/error");

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI2022ArchitectureTest V1"));

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapEndpoints();

app.Run();