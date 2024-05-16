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
    builder.Services.AddSingleton<IServiceConfig>(serviceProvider =>
    {
        // Getting the IHttpContextAccessor instance from the service provider
        var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        // Creating a new WebServiceConfig using the current app's configuration and the HTTP context accessor we just grabbed
        return new WebServiceConfig(configuration, httpContextAccessor);
    });

    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<PostService>();
    builder.Services.AddScoped<ModerationService>();

    // Wrapping services with Lazy<T> for DI
    // Lazy<T> means they won’t be created until I actually need them. It's like lazy loading images
    // Each service is registered with AddTransient, meaning a new Lazy wrapper is provided each time one is asked for
    // but the service inside this wrapper will only be created the first time it's accessed during a request.
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

}
catch (SqlException ex)
{
    Console.Error.WriteLine("☠️ Shutting down Web application.");
    Environment.Exit(1);
}

