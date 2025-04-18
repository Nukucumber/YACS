using CloudStorageService.Infrastructure;



var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Infrastructure.json");

builder.Services
.InfraOptionsRegistration(builder.Configuration)
.ServicesRegistration()
.AddControllers();


var app = builder.Build();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();