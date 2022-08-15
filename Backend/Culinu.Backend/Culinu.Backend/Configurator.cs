using Microsoft.EntityFrameworkCore;

namespace Culinu.Backend
{
    public class Configurator
    { 
         
        public static WebApplicationBuilder ConfigureServices(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CulinuContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            return builder;
        }
    }
}
