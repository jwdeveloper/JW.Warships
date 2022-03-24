using System.Reflection;
using Warships.Extentions;
using Warships.Hubs;
using MediatR;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.OpenApi.Models;
using Warships.common.Handlers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var serviceCollection = builder.Services;
serviceCollection.AddControllersWithViews();
serviceCollection.AddSignalR();
serviceCollection.RegisterServices();
serviceCollection.AddMediatR(typeof(SeekGameHandler).Assembly); 
serviceCollection.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://127.0.0.1:44406"));


    options.AddPolicy("signalr",
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(hostName => true));
});
serviceCollection.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Warships online",
        Version = "1.0.0",
        Description = "Simple online game"
    });
});
serviceCollection.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");


app.UseCors("CorsPolicy");
app.UseCors("signalr");
app.MapHub<LobbyHub>("/lobby", options=>
{
    options.Transports = HttpTransportType.WebSockets;
});
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json","Swagger demo");
});
app.Run();