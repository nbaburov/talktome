using Microsoft.AspNetCore.Http;
using SharedLibrary.Services;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Interface;
using System;
using System.Data.SqlClient;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Configuration and HttpContextAccessor
    var configuration = builder.Configuration;
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    // Configuration for IServiceConfig
    builder.Services.AddSingleton<IServiceConfig, WebServiceConfig>();

    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<PostService>();
    builder.Services.AddScoped<ModerationService>();

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

}
catch (SqlException ex)
{
    Console.Error.WriteLine("☠️ Shutting down Web application.");
    Environment.Exit(1);
}
