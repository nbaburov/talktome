using Microsoft.AspNetCore.Http;
using SharedLibrary.Helpers;
using SharedLibrary.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Interface;
using SharedLibrary.Repository;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configuration and HttpContextAccessor
    var configuration = builder.Configuration;
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    // Configuration for IServiceConfig
    builder.Services.AddSingleton<IServiceConfig, WebServiceConfig>();

    // Registering the HashWrapper helper
    builder.Services.AddSingleton<HashWrapper>();

    // Registering the UserRepository
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    // Registering the services
    builder.Services.AddScoped<AuthService>();
    builder.Services.AddScoped<UserService>();

    builder.Services.AddScoped<ContentRepository>();
    builder.Services.AddScoped<PostService>();
    builder.Services.AddScoped<CommentService>();
    builder.Services.AddScoped<LikeService>();
    builder.Services.AddScoped<CategoryService>();

    builder.Services.AddScoped<ModerationRepository>();
    builder.Services.AddScoped<FlaggedUserService>();
    builder.Services.AddScoped<FlaggedPostService>();
    builder.Services.AddScoped<FlaggedCommentService>();

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
catch (System.AggregateException ex)
{
    Console.Error.WriteLine("☠️ Shutting down Web application.");
    Environment.Exit(1);
}
