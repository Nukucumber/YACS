using CloudStorageService.Infrastructure;



var builder = WebApplication.CreateBuilder(args);

builder.Services.ServicesRegistration();

builder.Services.AddControllers();


var app = builder.Build();

app.MapControllers();

app.Run();