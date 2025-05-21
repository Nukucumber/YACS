var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/", () =>
{
    var response = new { rootAnswer = "helloWorld" };
    return response;
});


app.Run();