using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MinimalApi.Endpoint.Extensions;
using WebAPI2022ArchitectureTest.Business.Interfaces;
using WebAPI2022ArchitectureTest.Business.Services;
using WebAPI2022ArchitectureTest.Mappings;

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

builder.Services.AddAutoMapper(typeof(WebAPI2022ArchitectureTest.Mappings.AutoMappings).Assembly);

// App DI
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddSingleton<IAppHashIdService, AppHashIdService>();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
#pragma warning disable CS8604 // Possible null reference argument.
    cfg.AddProfile(new AutoMappings(provider.GetService<IAppHashIdService>()));
#pragma warning restore CS8604 // Possible null reference argument.
}).CreateMapper());

// Build App

var app = builder.Build();

var isDev = app.Environment.IsDevelopment();
app.UseExceptionHandler(isDev ? "/error-dev" : "/error");

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI2022ArchitectureTest V1"));

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapEndpoints();

app.Run();
