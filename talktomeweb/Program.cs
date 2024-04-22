using Microsoft.AspNetCore.Http;
using SharedLibrary.Services;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Interface;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuration and HttpContextAccessor
var configuration = builder.Configuration;
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Configuration for IServiceConfig
builder.Services.AddSingleton<IServiceConfig>(serviceProvider =>
{
    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    return new WebServiceConfig(configuration, httpContextAccessor);
});

// Registering services with Lazy<T>
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<ModerationService>();

// Wrapping services with Lazy<T> for DI
builder.Services.AddTransient(provider => new Lazy<UserService>(() => provider.GetRequiredService<UserService>()));
builder.Services.AddTransient(provider => new Lazy<PostService>(() => provider.GetRequiredService<PostService>()));
builder.Services.AddTransient(provider => new Lazy<ModerationService>(() => provider.GetRequiredService<ModerationService>()));

// Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();  // The default HSTS value is 30 days
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
