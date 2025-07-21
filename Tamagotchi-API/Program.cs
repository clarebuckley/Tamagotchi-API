using Tamagotchi_API.Data;
using Tamagotchi_API.Repositories;
using Tamagotchi_API.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHttpClient();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<IChecklistService, ChecklistService>();
        builder.Services.AddScoped<ChecklistRepository>();
        builder.Services.AddDbContext<ChecklistContext>();
        builder.Services.AddCors();

        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseRouting();
        app.MapControllers();

        app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

        app.Run();
    }
}