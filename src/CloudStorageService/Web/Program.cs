namespace CloudStorageService.Web;

using CloudStorageService.Infrastructure;



class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Inject()
                        .AddControllers();


        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}