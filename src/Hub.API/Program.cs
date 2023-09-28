using System;
using Hub.API.Configuration;
using Hub.API.Services;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Demo.json") // Add your configuration source
    .Build();


builder.Logging.ClearProviders();

// if (builder.Environment.EnvironmentName != "Testing")
// {
//     builder.Host.UseLoggingSetup(configuration);
// }
// builder.Host.UseSerilog();

builder.Logging.AddSerilog(new LoggerConfiguration()
    .WriteTo.Debug()
    .WriteTo.File(Path.Combine(AppContext.BaseDirectory, "log.txt"))
    .ReadFrom.Configuration(configuration)
    .CreateLogger());

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext?.Request;
    var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
    return new UriService(uri);
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlDbContext(configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();