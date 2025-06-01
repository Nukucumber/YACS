using System.Text.Json;

namespace CloudStorageService.Web;


class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        var app = builder.Build();

        app.MapGet("/", () =>
        {
            return JsonSerializer.SerializeToDocument("hiHello");
        });

        app.Run();
    }
}