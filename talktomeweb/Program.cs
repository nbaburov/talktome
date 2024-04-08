using Microsoft.AspNetCore.Http;
using SharedLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddHttpContextAccessor();
if (connectionString != null)
{
    builder.Services.AddScoped<UserService>(provider => new UserService(connectionString, provider.GetRequiredService<IHttpContextAccessor>()));
        builder.Services.AddScoped<PostService>(provider => new PostService(
        connectionString, 
        provider.GetRequiredService<UserService>()));
}

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
