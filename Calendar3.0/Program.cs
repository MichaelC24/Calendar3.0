using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Calendar3._0.Data;
namespace Calendar3._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CalendarContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CalendarContext") ?? throw new InvalidOperationException("Connection string 'CalendarContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
