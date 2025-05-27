var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/", () =>
{
    var response = new { rootAnswer = "111" };
    return response;
});


app.Run();
