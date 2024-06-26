using System.Reflection;
using Application;
using Application.Common.Interfaces;
using DienstManager.Components;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>( options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDatabase")));

builder.Services.AddApplication();

builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Logging.AddSerilog(new LoggerConfiguration()
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

try
{
    app.Run();
}
finally
{
    Log.CloseAndFlush();
    await Task.Delay(5000);
}