using Culinu.Backend.Controllers;
using System.Diagnostics;

namespace Culinu.Backend
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = Configurator.ConfigureServices(args);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<CulinuContext>();
                if (Debugger.IsAttached)
                    await context.Database.EnsureDeletedAsync();
                
                await context.Database.EnsureCreatedAsync();
            }

            //app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();
            app.MapControllers();
            await app.RunAsync();
        }
    }
}