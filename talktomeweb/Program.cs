using Microsoft.AspNetCore.Http;
using SharedLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString != null)
{
    builder.Services.AddScoped<UserService>(provider => new UserService(connectionString, provider.GetRequiredService<IHttpContextAccessor>()));
}

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor(); // Register HttpContextAccessor as a service

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
