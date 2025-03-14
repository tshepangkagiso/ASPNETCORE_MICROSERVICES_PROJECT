using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using ShirtApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpClient("ShirtsApi", client =>
{
    client.BaseAddress = new Uri("https://shirtsapp.api.com:44391");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IWebApiExecutor, WebApiExecutor>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();


//Application to accepted forwarded headers from nginx
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
