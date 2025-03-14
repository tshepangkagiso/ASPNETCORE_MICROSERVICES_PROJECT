using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ShirtsApp.Api.Data.Database_Config;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddControllers();

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

/*if (builder.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}
else
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}*/
    //Middleware
    app.UseHttpsRedirection();

//Application to accepted forwarded headers from nginx
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.MapControllers();

app.Run();


